using System;
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

// ReSharper disable MergeCastWithTypeCheck

#if NET6_0_OR_GREATER

namespace Cysharp.Text
{
    [DebuggerDisplay("{_buffer[.._index]}")]
    [InterpolatedStringHandler]
    public ref struct ZStringInterpolatedStringHandler
    {
        private const int ThreadStaticBufferSize = 31111;
        private const int DefaultBufferSize      = 32768; // use 32K default buffer.

        [ThreadStatic]
        private static char[]? _scratchBuffer;

        private readonly bool _disposeImmediately;
        private static   bool _scratchBufferUsed;

        private          char[]           _bufferArray;
        private          Span<char>       _buffer;
        private          int              _index;
        private readonly IFormatProvider? _provider;
        private readonly bool             _hasCustomFormatter;

        public int Length => _index;

        public ZStringInterpolatedStringHandler(
            int              literalLength,
            int              formattedCount,
            IFormatProvider? provider           = null,
            bool             disposeImmediately = true)
        {
            if (disposeImmediately && _scratchBufferUsed) { ThrowNestedException(); }

            _provider = provider;
            _index    = 0;

            if (disposeImmediately && literalLength <= ThreadStaticBufferSize)
            {
                _bufferArray       = _scratchBuffer ??= new char[ThreadStaticBufferSize];
                _scratchBufferUsed = true;
            }
            else { _bufferArray = ArrayPool<char>.Shared.Rent(DefaultBufferSize); }

            _buffer = formattedCount == 0 ? _bufferArray.AsSpan()[..literalLength] : _bufferArray.AsSpan();

            _disposeImmediately = disposeImmediately;
            _hasCustomFormatter = provider is not null && HasCustomFormatter(provider);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string s) => AppendLiteral(s.AsSpan());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(ReadOnlySpan<char> value)
        {
            if (value.Length == 0) { return; }

            if (_buffer.Length - _index < value.Length) { Grow(value.Length); }

            value.CopyTo(_buffer[_index..]);
            _index += value.Length;
        }

        #region AppendFormatted

        // Design note:
        // The compiler requires a AppendFormatted overload for anything that might be within an interpolation expression;
        // if it can't find an appropriate overload, for handlers in general it'll simply fail to compile.
        // (For target-typing to string where it uses DefaultInterpolatedStringHandler implicitly, it'll instead fall back to
        // its other mechanisms, e.g. using string.Format.  This fallback has the benefit that if we miss a case,
        // interpolated strings will still work, but it has the downside that a developer generally won't know
        // if the fallback is happening and they're paying more.)
        //
        // At a minimum, then, we would need an overload that accepts:
        //     (object value, int alignment = 0, string? format = null)
        // Such an overload would provide the same expressiveness as string.Format.  However, this has several
        // shortcomings:
        // - Every value type in an interpolation expression would be boxed.
        // - ReadOnlySpan<char> could not be used in interpolation expressions.
        // - Every AppendFormatted call would have three arguments at the call site, bloating the IL further.
        // - Every invocation would be more expensive, due to lack of specialization, every call needing to account
        //   for alignment and format, etc.
        //
        // To address that, we could just have overloads for T and ReadOnlySpan<char>:
        //     (T)
        //     (T, int alignment)
        //     (T, string? format)
        //     (T, int alignment, string? format)
        //     (ReadOnlySpan<char>)
        //     (ReadOnlySpan<char>, int alignment)
        //     (ReadOnlySpan<char>, string? format)
        //     (ReadOnlySpan<char>, int alignment, string? format)
        // but this also has shortcomings:
        // - Some expressions that would have worked with an object overload will now force a fallback to string.Format
        //   (or fail to compile if the handler is used in places where the fallback isn't provided), because the compiler
        //   can't always target type to T, e.g. `b switch { true => 1, false => null }` where `b` is a bool can successfully
        //   be passed as an argument of type `object` but not of type `T`.
        // - Reference types get no benefit from going through the generic code paths, and actually incur some overheads
        //   from doing so.
        // - Nullable value types also pay a heavy price, in particular around interface checks that would generally evaporate
        //   at compile time for value types but don't (currently) if the Nullable<T> goes through the same code paths
        //   (see https://github.com/dotnet/runtime/issues/50915).
        //
        // We could try to take a more elaborate approach for DefaultInterpolatedStringHandler, since it is the most common handler
        // and we want to minimize overheads both at runtime and in IL size, e.g. have a complete set of overloads for each of:
        //     (T, ...) where T : struct
        //     (T?, ...) where T : struct
        //     (object, ...)
        //     (ReadOnlySpan<char>, ...)
        //     (string, ...)
        // but this also has shortcomings, most importantly:
        // - If you have an unconstrained T that happens to be a value type, it'll now end up getting boxed to use the object overload.
        //   This also necessitates the T? overload, since nullable value types don't meet a T : struct constraint, so without those
        //   they'd all map to the object overloads as well.
        // - Any reference type with an implicit cast to ROS<char> will fail to compile due to ambiguities between the overloads. string
        //   is one such type, hence needing dedicated overloads for it that can be bound to more tightly.
        //
        // A middle ground we've settled on, which is likely to be the right approach for most other handlers as well, would be the set:
        //     (T, ...) with no constraint
        //     (ReadOnlySpan<char>) and (ReadOnlySpan<char>, int)
        //     (object, int alignment = 0, string? format = null)
        //     (string) and (string, int)
        // This would address most of the concerns, at the expense of:
        // - Most reference types going through the generic code paths and so being a bit more expensive.
        // - Nullable types being more expensive until https://github.com/dotnet/runtime/issues/50915 is addressed.
        //   We could choose to add a T? where T : struct set of overloads if necessary.
        // Strings don't require their own overloads here, but as they're expected to be very common and as we can
        // optimize them in several ways (can copy the contents directly, don't need to do any interface checks, don't
        // need to pay the shared generic overheads, etc.) we can add overloads specifically to optimize for them.
        //
        // Hole values are formatted according to the following policy:
        // 1. If an IFormatProvider was supplied and it provides an ICustomFormatter, use ICustomFormatter.Format (even if the value is null).
        // 2. If the type implements ISpanFormattable, use ISpanFormattable.TryFormat.
        // 3. If the type implements IFormattable, use IFormattable.ToString.
        // 4. Otherwise, use object.ToString.
        // This matches the behavior of string.Format, StringBuilder.AppendFormat, etc.  The only overloads for which this doesn't
        // apply is ReadOnlySpan<char>, which isn't supported by either string.Format nor StringBuilder.AppendFormat, but more
        // importantly which can't be boxed to be passed to ICustomFormatter.Format.

        #region AppendFormatted T

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        /// <typeparam name="T">The type of the value to write.</typeparam>
        public void AppendFormatted<T>(T value)
        {
            // This method could delegate to AppendFormatted with a null format, but explicitly passing
            // default as the format to TryFormat helps to improve code quality in some cases when TryFormat is inlined,
            // e.g. for Int32 it enables the JIT to eliminate code in the inlined method based on a length check on the format.

            // If there's a custom formatter, always use it.
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, null);
                return;
            }

            if (value is null) { return; }

            // Check first for IFormattable, even though we'll prefer to use ISpanFormattable, as the latter
            // requires the former.  For value types, it won't matter as the type checks devolve into
            // JIT-time constants.  For reference types, they're more likely to implement IFormattable
            // than they are to implement ISpanFormattable: if they don't implement either, we save an
            // interface check over first checking for ISpanFormattable and then for IFormattable, and
            // if it only implements IFormattable, we come out even: only if it implements both do we
            // end up paying for an extra interface check.
            string? s;
            if (value is IFormattable)
            {
                // If the value can format itself directly into our buffer, do so.

                if (value is ISpanFormattable)
                {
                    int charsWritten;
                    while (!((ISpanFormattable)value).TryFormat(_buffer[_index..],
                               out charsWritten,
                               default,
                               _provider)) // constrained call avoiding boxing for value types
                    {
                        Grow(0);
                    }

                    _index += charsWritten;
                    return;
                }

                // constrained call avoiding boxing for value types
                s = ((IFormattable)value).ToString(null, _provider);
            }
            else { s = value.ToString(); }

            if (s is not null) { AppendLiteral(s); }
        }

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        /// <param name="format">The format string.</param>
        /// <typeparam name="T">The type of the value to write.</typeparam>
        public void AppendFormatted<T>(T value, string? format)
        {
            // If there's a custom formatter, always use it.
            if (_hasCustomFormatter)
            {
                AppendCustomFormatter(value, format);
                return;
            }

            if (value is null) { return; }

            // Check first for IFormattable, even though we'll prefer to use ISpanFormattable, as the latter
            // requires the former.  For value types, it won't matter as the type checks devolve into
            // JIT-time constants.  For reference types, they're more likely to implement IFormattable
            // than they are to implement ISpanFormattable: if they don't implement either, we save an
            // interface check over first checking for ISpanFormattable and then for IFormattable, and
            // if it only implements IFormattable, we come out even: only if it implements both do we
            // end up paying for an extra interface check.
            string? s;
            if (value is IFormattable)
            {
                // If the value can format itself directly into our buffer, do so.

                if (value is ISpanFormattable)
                {
                    int charsWritten;
                    while (!((ISpanFormattable)value).TryFormat(_buffer[_index..],
                               out charsWritten,
                               format,
                               _provider)) // constrained call avoiding boxing for value types
                    {
                        Grow(0);
                    }

                    _index += charsWritten;
                    return;
                }

                s = ((IFormattable)value).ToString(format,
                    _provider); // constrained call avoiding boxing for value types
            }
            else { s = value.ToString(); }

            if (s is not null) { AppendLiteral(s); }
        }

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        /// <param name="alignment">
        ///     Minimum number of characters that should be written for this value.  If the value is negative,
        ///     it indicates left-aligned and the required minimum is the absolute value.
        /// </param>
        /// <typeparam name="T">The type of the value to write.</typeparam>
        public void AppendFormatted<T>(T value, int alignment)
        {
            var startingPos = _index;
            AppendFormatted(value);
            if (alignment != 0) { AppendOrInsertAlignmentIfNeeded(startingPos, alignment); }
        }

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        /// <param name="format">The format string.</param>
        /// <param name="alignment">
        ///     Minimum number of characters that should be written for this value.  If the value is negative,
        ///     it indicates left-aligned and the required minimum is the absolute value.
        /// </param>
        /// <typeparam name="T">The type of the value to write.</typeparam>
        public void AppendFormatted<T>(T value, int alignment, string? format)
        {
            var startingPos = _index;
            AppendFormatted(value, format);
            if (alignment != 0) { AppendOrInsertAlignmentIfNeeded(startingPos, alignment); }
        }

        #endregion

        #region AppendFormatted ReadOnlySpan<char>

        /// <summary>Writes the specified character span to the handler.</summary>
        /// <param name="value">The span to write.</param>
        public void AppendFormatted(ReadOnlySpan<char> value)
        {
            // Fast path for when the value fits in the current buffer
            if (value.TryCopyTo(_buffer[_index..])) { _index += value.Length; }
            else { AppendLiteral(value); }
        }

        /// <summary>Writes the specified string of chars to the handler.</summary>
        /// <param name="value">The span to write.</param>
        /// <param name="alignment">
        ///     Minimum number of characters that should be written for this value.  If the value is negative,
        ///     it indicates left-aligned and the required minimum is the absolute value.
        /// </param>
        /// <param name="format">The format string.</param>
        public void AppendFormatted(ReadOnlySpan<char> value, int alignment, string? format = null)
        {
            var leftAlign = false;
            if (alignment < 0)
            {
                leftAlign = true;
                alignment = -alignment;
            }

            var paddingRequired = alignment - value.Length;
            if (paddingRequired <= 0)
            {
                // The value is as large or larger than the required amount of padding,
                // so just write the value.
                AppendFormatted(value);
                return;
            }

            // Write the value along with the appropriate padding.
            EnsureCapacityForAdditionalChars(value.Length + paddingRequired);
            if (leftAlign)
            {
                value.CopyTo(_buffer[_index..]);
                _index += value.Length;
                _buffer.Slice(_index, paddingRequired).Fill(' ');
                _index += paddingRequired;
            }
            else
            {
                _buffer.Slice(_index, paddingRequired).Fill(' ');
                _index += paddingRequired;
                value.CopyTo(_buffer[_index..]);
                _index += value.Length;
            }
        }

        #endregion

        #region AppendFormatted string

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        public void AppendFormatted(string? value)
        {
            // Fast-path for no custom formatter and a non-null string that fits in the current destination buffer.
            if (!_hasCustomFormatter && value is not null && value.TryCopyTo(_buffer[_index..]))
            {
                _index += value.Length;
            }
            else { AppendFormattedSlow(value); }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AppendCustomFormatter<T>(T value, string? format)
        {
            // This case is very rare, but we need to handle it prior to the other checks in case
            // a provider was used that supplied an ICustomFormatter which wanted to intercept the particular value.
            // We do the cast here rather than in the ctor, even though this could be executed multiple times per
            // formatting, to make the cast pay for play.
            Debug.Assert(_hasCustomFormatter);
            Debug.Assert(_provider != null);

            var formatter = (ICustomFormatter?)_provider.GetFormat(typeof(ICustomFormatter));
            Debug.Assert(formatter != null,
                "An incorrectly written provider said it implemented ICustomFormatter, and then didn't");

            if (formatter.Format(format, value, _provider) is string customFormatted)
            {
                AppendLiteral(customFormatted);
            }
        }

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        /// <remarks>
        ///     Slow path to handle a custom formatter, potentially null value, or a string that doesn't fit in the current
        ///     buffer.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AppendFormattedSlow(string? value)
        {
            if (_hasCustomFormatter) { AppendCustomFormatter(value, null); }
            else if (value is not null)
            {
                EnsureCapacityForAdditionalChars(value.Length);
                value.CopyTo(_buffer[_index..]);
                _index += value.Length;
            }
        }

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        /// <param name="alignment">
        ///     Minimum number of characters that should be written for this value.  If the value is negative,
        ///     it indicates left-aligned and the required minimum is the absolute value.
        /// </param>
        /// <param name="format">The format string.</param>
        public void AppendFormatted(string? value, int alignment, string? format = null) =>
            // Format is meaningless for strings and doesn't make sense for someone to specify.  We have the overload
            // simply to disambiguate between ROS<char> and object, just in case someone does specify a format, as
            // string is implicitly convertible to both. Just delegate to the T-based implementation.
            AppendFormatted<string?>(value, alignment, format);

        #endregion

        #region AppendFormatted object

        /// <summary>Writes the specified value to the handler.</summary>
        /// <param name="value">The value to write.</param>
        /// <param name="alignment">
        ///     Minimum number of characters that should be written for this value.  If the value is negative,
        ///     it indicates left-aligned and the required minimum is the absolute value.
        /// </param>
        /// <param name="format">The format string.</param>
        public void AppendFormatted(object? value, int alignment = 0, string? format = null) =>
            // This overload is expected to be used rarely, only if either a) something strongly typed as object is
            // formatted with both an alignment and a format, or b) the compiler is unable to target type to T. It
            // exists purely to help make cases from (b) compile. Just delegate to the T-based implementation.
            AppendFormatted<object?>(value, alignment, format);

        #endregion

        #endregion

        private void Grow(int sizeHint)
        {
            var nextSize = _buffer.Length * 2;
            if (sizeHint != 0) { nextSize = Math.Max(nextSize, _index + sizeHint); }

            var newBufferArray = ArrayPool<char>.Shared.Rent(nextSize);
            var newBuffer      = _bufferArray.AsSpan();

            _buffer.CopyTo(newBuffer);

            if (!_disposeImmediately || _bufferArray.Length != ThreadStaticBufferSize)
            {
                _bufferArray.AsSpan().Clear();
                ArrayPool<char>.Shared.Return(_bufferArray);
            }

            _bufferArray = newBufferArray;
            _buffer      = _bufferArray.AsSpan();
        }

        internal void CopyTo(Span<char> span) { _buffer[.._index].CopyTo(span); }

        internal void GetString(ref Utf8ValueStringBuilder builder) { builder.Append(_buffer[.._index]); }

        internal void GetString(ref Utf16ValueStringBuilder builder) { builder.Append(_buffer[.._index]); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (_disposeImmediately) { _scratchBufferUsed = false; }
            else { ArrayPool<char>.Shared.Return(_bufferArray); }

            _scratchBuffer?.AsSpan().Clear();
        }

        private static void ThrowNestedException()
        {
            throw new NestedStringBuilderCreationException(nameof(Utf16ValueStringBuilder));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] // only used in a few hot path call sites
        private static bool HasCustomFormatter(IFormatProvider provider)
        {
            Debug.Assert(provider is not null);
            Debug.Assert(provider is not CultureInfo || provider.GetFormat(typeof(ICustomFormatter)) is null,
                "Expected CultureInfo to not provide a custom formatter");
            return provider.GetType() != typeof(CultureInfo) && // optimization to avoid GetFormat in the majority case
                provider.GetFormat(typeof(ICustomFormatter)) != null;
        }

        private void AppendOrInsertAlignmentIfNeeded(int startingPos, int alignment)
        {
            Debug.Assert(startingPos >= 0 && startingPos <= _index);
            Debug.Assert(alignment != 0);

            var charsWritten = _index - startingPos;

            var leftAlign = false;
            if (alignment < 0)
            {
                leftAlign = true;
                alignment = -alignment;
            }

            var paddingNeeded = alignment - charsWritten;
            if (paddingNeeded <= 0) { return; }

            EnsureCapacityForAdditionalChars(paddingNeeded);

            if (leftAlign) { _buffer.Slice(_index, paddingNeeded).Fill(' '); }
            else
            {
                _buffer.Slice(startingPos, charsWritten).CopyTo(_buffer.Slice(startingPos + paddingNeeded));
                _buffer.Slice(startingPos, paddingNeeded).Fill(' ');
            }

            _index += paddingNeeded;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EnsureCapacityForAdditionalChars(int additionalChars)
        {
            if (_buffer.Length - _index < additionalChars) { Grow(additionalChars); }
        }

    }
}

#endif
