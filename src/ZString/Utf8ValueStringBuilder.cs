using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder : IDisposable, IBufferWriter<byte>, IResettableBufferWriter<byte>
    {
        public delegate bool TryFormat<T>(T value, Span<byte> destination, out int written, StandardFormat format);

        const int ThreadStaticBufferSize = 64444;
        const int DefaultBufferSize = 65536; // use 64K default buffer.
        static Encoding UTF8NoBom = new UTF8Encoding(false);

        static byte newLine1;
        static byte newLine2;
        static bool crlf;

        static Utf8ValueStringBuilder()
        {
            var newLine = UTF8NoBom.GetBytes(Environment.NewLine);
            if (newLine.Length == 1)
            {
                // cr or lf
                newLine1 = newLine[0];
                crlf = false;
            }
            else
            {
                // crlf(windows)
                newLine1 = newLine[0];
                newLine2 = newLine[1];
                crlf = true;
            }
        }

        [ThreadStatic]
        static byte[]? scratchBuffer;

        [ThreadStatic]
        internal static bool scratchBufferUsed;

        byte[]? buffer;
        int index;
        bool disposeImmediately;

        /// <summary>Length of written buffer.</summary>
        public int Length => index;

        /// <summary>Get the written buffer data.</summary>
        public ReadOnlySpan<byte> AsSpan() => buffer.AsSpan(0, index);

        /// <summary>Get the written buffer data.</summary>
        public ReadOnlyMemory<byte> AsMemory() => buffer.AsMemory(0, index);

        /// <summary>Get the written buffer data.</summary>
        public ArraySegment<byte> AsArraySegment() => new ArraySegment<byte>(buffer, 0, index);

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="disposeImmediately">
        /// If true uses thread-static buffer that is faster but must return immediately.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This exception is thrown when <c>new StringBuilder(disposeImmediately: true)</c> or <c>ZString.CreateUtf8StringBuilder(notNested: true)</c> is nested.
        /// See the README.md
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf8ValueStringBuilder(bool disposeImmediately)
        {
            if (disposeImmediately && scratchBufferUsed)
            {
                ThrowNestedException();
            }

            byte[]? buf;
            if (disposeImmediately)
            {
                buf = scratchBuffer;
                if (buf == null)
                {
                    buf = scratchBuffer = new byte[ThreadStaticBufferSize];
                }
                scratchBufferUsed = true;
            }
            else
            {
                buf = ArrayPool<byte>.Shared.Rent(DefaultBufferSize);
            }

            buffer = buf;
            index = 0;
            this.disposeImmediately = disposeImmediately;
        }

        /// <summary>
        /// Return the inner buffer to pool.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (buffer != null)
            {
                if (buffer.Length != ThreadStaticBufferSize)
                {
                    ArrayPool<byte>.Shared.Return(buffer);
                }
                buffer = null;
                index = 0;
                if (disposeImmediately)
                {
                    scratchBufferUsed = false;
                }
            }
        }

        public void Clear()
        {
            index = 0;
        }

        public void TryGrow(int sizeHint)
        {
            if (buffer!.Length < index + sizeHint)
            {
                Grow(sizeHint);
            }
        }

        public void Grow(int sizeHint)
        {
            var nextSize = buffer!.Length * 2;
            if (sizeHint != 0)
            {
                nextSize = Math.Max(nextSize, index + sizeHint);
            }

            var newBuffer = ArrayPool<byte>.Shared.Rent(nextSize);

            buffer.CopyTo(newBuffer, 0);
            if (buffer.Length != ThreadStaticBufferSize)
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }

            buffer = newBuffer;
        }

        /// <summary>Appends the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine()
        {
            if (crlf)
            {
                if (buffer!.Length - index < 2) Grow(2);
                buffer[index] = newLine1;
                buffer[index + 1] = newLine2;
                index += 2;
            }
            else
            {
                if (buffer!.Length - index < 1) Grow(1);
                buffer[index] = newLine1;
                index += 1;
            }
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Append(char value)
        {
            var maxLen = UTF8NoBom.GetMaxByteCount(1);
            if (buffer!.Length - index < maxLen)
            {
                Grow(maxLen);
            }

            fixed (byte* bp = &buffer[index])
            {
                index += UTF8NoBom.GetBytes(&value, 1, bp, maxLen);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(char value, int repeatCount)
        {
            if (repeatCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(repeatCount));
            }

            if (value <= 0x7F) // ASCII
            {
                GetSpan(repeatCount).Fill((byte)value);
                Advance(repeatCount);
            }
            else
            {
                var maxLen = UTF8NoBom.GetMaxByteCount(1);
                Span<byte> utf8Bytes = stackalloc byte[maxLen];
                ReadOnlySpan<char> chars = stackalloc char[1] { value };

                int len = UTF8NoBom.GetBytes(chars, utf8Bytes);

                TryGrow(len * repeatCount);

                for (int i = 0; i < repeatCount; i++)
                {
                    utf8Bytes.CopyTo(GetSpan(len));
                    Advance(len);
                }
            }
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(char value)
        {
            Append(value);
            AppendLine();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(string value, int startIndex, int count)
        {
            if (value == null)
            {
                if (startIndex == 0 && count == 0)
                {
                    return;
                }
                else
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }

            Append(value.AsSpan(startIndex, count));
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(string value)
        {
            Append(value.AsSpan());
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(string value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends a contiguous region of arbitrary memory to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ReadOnlySpan<char> value)
        {
            var maxLen = UTF8NoBom.GetMaxByteCount(value.Length);
            if (buffer!.Length - index < maxLen)
            {
                Grow(maxLen);
            }

            index += UTF8NoBom.GetBytes(value, buffer.AsSpan(index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(ReadOnlySpan<char> value)
        {
            Append(value);
            AppendLine();
        }

        public void AppendLiteral(ReadOnlySpan<byte> value)
        {
            if ((buffer!.Length - index) < value.Length)
            {
                Grow(value.Length);
            }

            value.CopyTo(buffer.AsSpan(index));
            index += value.Length;
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        public void Append<T>(T value)
        {
            if (!FormatterCache<T>.TryFormatDelegate(value, buffer.AsSpan(index), out var written, default))
            {
                Grow(written);
                if (!FormatterCache<T>.TryFormatDelegate(value, buffer.AsSpan(index), out written, default))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        public void AppendLine<T>(T value)
        {
            Append(value);
            AppendLine();
        }

        // Output

        /// <summary>Copy inner buffer to the bufferWriter.</summary>
        public void CopyTo(IBufferWriter<byte> bufferWriter)
        {
            var destination = bufferWriter.GetSpan(index);
            TryCopyTo(destination, out var written);
            bufferWriter.Advance(written);
        }

        /// <summary>Copy inner buffer to the destination span.</summary>
        public bool TryCopyTo(Span<byte> destination, out int bytesWritten)
        {
            if (destination.Length < index)
            {
                bytesWritten = 0;
                return false;
            }

            bytesWritten = index;
            buffer.AsSpan(0, index).CopyTo(destination);
            return true;
        }

        /// <summary>Write inner buffer to stream.</summary>
        public Task WriteToAsync(Stream stream)
        {
            return stream.WriteAsync(buffer, 0, index);
        }

        /// <summary>Write inner buffer to stream.</summary>
        public Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
        {
            return stream.WriteAsync(buffer, 0, index, cancellationToken);
        }

        /// <summary>Encode the innner utf8 buffer to a System.String.</summary>
        public override string ToString()
        {
            if (index == 0)
                return string.Empty;

            return UTF8NoBom.GetString(buffer, 0, index);
        }

        // IBufferWriter

        /// <summary>IBufferWriter.GetMemory.</summary>
        public Memory<byte> GetMemory(int sizeHint)
        {
            if ((buffer!.Length - index) < sizeHint)
            {
                Grow(sizeHint);
            }

            return buffer.AsMemory(index);
        }

        /// <summary>IBufferWriter.GetSpan.</summary>
        public Span<byte> GetSpan(int sizeHint)
        {
            if ((buffer!.Length - index) < sizeHint)
            {
                Grow(sizeHint);
            }

            return buffer.AsSpan(index);
        }

        /// <summary>IBufferWriter.Advance.</summary>
        public void Advance(int count)
        {
            index += count;
        }

        void IResettableBufferWriter<byte>.Reset()
        {
            index = 0;
        }

        void ThrowArgumentException(string paramName)
        {
            throw new ArgumentException("Can't format argument.", paramName);
        }

        void ThrowFormatException()
        {
            throw new FormatException("Index (zero based) must be greater than or equal to zero and less than the size of the argument list.");
        }

        static void ThrowNestedException()
        {
            throw new NestedStringBuilderCreationException(nameof(Utf8ValueStringBuilder));
        }

        private void AppendFormatInternal<T>(T arg, int width, StandardFormat format, string argName)
        {
            if (width <= 0) // leftJustify
            {
                width *= -1;

                if (!FormatterCache<T>.TryFormatDelegate(arg, buffer.AsSpan(index), out var charsWritten, format))
                {
                    Grow(charsWritten);
                    if (!FormatterCache<T>.TryFormatDelegate(arg, buffer.AsSpan(index), out charsWritten, format))
                    {
                        ThrowArgumentException(argName);
                    }
                }

                index += charsWritten;

                int padding = width - charsWritten;
                if (width > 0 && padding > 0)
                {
                    Append(' ', padding);  // TODO Fill Method is too slow.
                }
            }
            else // rightJustify
            {
                if (typeof(T) == typeof(string))
                {
                    var s = Unsafe.As<string>(arg);
                    int padding = width - s.Length;
                    if (padding > 0)
                    {
                        Append(' ', padding);  // TODO Fill Method is too slow.
                    }

                    Append(s);
                }
                else
                {
                    Span<byte> s = stackalloc byte[typeof(T).IsValueType ? Unsafe.SizeOf<T>() * 8 : 1024];

                    if (!FormatterCache<T>.TryFormatDelegate(arg, s, out var charsWritten, format))
                    {
                        s = stackalloc byte[s.Length * 2];
                        if (!FormatterCache<T>.TryFormatDelegate(arg, s, out charsWritten, format))
                        {
                            ThrowArgumentException(argName);
                        }
                    }

                    int padding = width - charsWritten;
                    if (padding > 0)
                    {
                        Append(' ', padding);  // TODO Fill Method is too slow.
                    }

                    s.CopyTo(GetSpan(charsWritten));
                    Advance(charsWritten);
                }
            }
        }

        /// <summary>
        /// Register custom formatter
        /// </summary>
        public static void RegisterTryFormat<T>(TryFormat<T> formatMethod)
        {
            FormatterCache<T>.TryFormatDelegate = formatMethod;
        }

        static TryFormat<T?> CreateNullableFormatter<T>() where T : struct
        {
            return new TryFormat<T?>((T? x, Span<byte> destination, out int written, StandardFormat format) =>
            {
                if (x == null)
                {
                    written = 0;
                    return true;
                }
                return FormatterCache<T>.TryFormatDelegate(x.Value, destination, out written, format);
            });
        }

        /// <summary>
        /// Supports the Nullable type for a given struct type.
        /// </summary>
        public static void EnableNullableFormat<T>() where T : struct
        {
            RegisterTryFormat<T?>(CreateNullableFormatter<T>());
        }

        public static class FormatterCache<T>
        {
            public static TryFormat<T> TryFormatDelegate;
            static FormatterCache()
            {
                var formatter = (TryFormat<T>?)CreateFormatter(typeof(T));
                if (formatter == null)
                {
                    if (typeof(T).IsEnum)
                    {
                        formatter = new TryFormat<T>(EnumUtil<T>.TryFormatUtf8);
                    }
                    else
                    {
                        formatter = new TryFormat<T>(TryFormatDefault);
                    }
                }

                TryFormatDelegate = formatter;
            }

            static bool TryFormatDefault(T value, Span<byte> dest, out int written, StandardFormat format)
            {
                if (value == null)
                {
                    written = 0;
                    return true;
                }

                var s = typeof(T) == typeof(string) ? Unsafe.As<string>(value) :
                    (value is IFormattable formattable && format != default) ? formattable.ToString(format.ToString(), null) :
                    value.ToString();

                // also use this length when result is false.
                written = UTF8NoBom.GetMaxByteCount(s.Length);
                if (dest.Length < written)
                {
                    return false;
                }

                written = UTF8NoBom.GetBytes(s.AsSpan(), dest);
                return true;

            }
        }
    }
}
