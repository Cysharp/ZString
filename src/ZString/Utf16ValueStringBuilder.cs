using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public partial struct Utf16ValueStringBuilder : IDisposable, IBufferWriter<char>, IResettableBufferWriter<char>
    {
        public delegate bool TryFormat<T>(T value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format);

        const int ThreadStaticBufferSize = 31111;
        const int DefaultBufferSize = 32768; // use 32K default buffer.

        static char newLine1;
        static char newLine2;
        static bool crlf;

        static Utf16ValueStringBuilder()
        {
            var newLine = Environment.NewLine.ToCharArray();
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
        static char[] scratchBuffer;

        char[] buffer;
        int index;

        /// <summary>Length of written buffer.</summary>
        public int Length => index;
        /// <summary>Get the written buffer data.</summary>
        public ReadOnlySpan<char> AsSpan() => buffer.AsSpan(0, index);
        /// <summary>Get the written buffer data.</summary>
        public ReadOnlyMemory<char> AsMemory() => buffer.AsMemory(0, index);
        /// <summary>Get the written buffer data.</summary>
        public ArraySegment<char> AsArraySegment() => new ArraySegment<char>(buffer, 0, index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder(bool disposeImmediately)
        {
            char[] buf;
            if (disposeImmediately)
            {
                buf = scratchBuffer;
                if (buf == null)
                {
                    buf = scratchBuffer = new char[ThreadStaticBufferSize];
                }
            }
            else
            {
                buf = ArrayPool<char>.Shared.Rent(DefaultBufferSize);
            }

            buffer = buf;
            index = 0;
        }

        /// <summary>
        /// Return the inner buffer to pool.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (buffer.Length != ThreadStaticBufferSize)
            {
                if (buffer != null)
                {
                    ArrayPool<char>.Shared.Return(buffer);
                }
            }
            buffer = null;
            index = 0;
        }

        public void Clear()
        {
            index = 0;
        }

        public void TryGrow(int sizeHint)
        {

            if (buffer.Length < index + sizeHint)
            {
                Grow(sizeHint);
            }
        }

        public void Grow(int sizeHint)
        {
            var nextSize = buffer.Length * 2;
            if (sizeHint != 0)
            {
                nextSize = Math.Max(nextSize, index + sizeHint);
            }

            var newBuffer = ArrayPool<char>.Shared.Rent(nextSize);

            buffer.CopyTo(newBuffer, 0);
            if (buffer.Length != ThreadStaticBufferSize)
            {
                ArrayPool<char>.Shared.Return(buffer);
            }

            buffer = newBuffer;
        }

        /// <summary>Appends the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine()
        {
            if (crlf)
            {
                if (buffer.Length - index < 2) Grow(2);
                buffer[index] = newLine1;
                buffer[index + 1] = newLine2;
                index += 2;
            }
            else
            {
                if (buffer.Length - index < 1) Grow(1);
                buffer[index] = newLine1;
                index += 1;
            }
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(char value)
        {
            if (buffer.Length - index < 1)
            {
                Grow(1);
            }

            buffer[index++] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(char value, int repeatCount)
        {
            if (repeatCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(repeatCount));
            }

            GetSpan(repeatCount).Fill(value);
            Advance(repeatCount);
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(char value)
        {
            Append(value);
            AppendLine();
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
            if (buffer.Length - index < value.Length)
            {
                Grow(value.Length);
            }

            value.CopyTo(buffer.AsSpan(index));
            index += value.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(ReadOnlySpan<char> value)
        {
            Append(value);
            AppendLine();
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

        /// <summary>
        /// Replaces all instances of one character with another in this builder.
        /// </summary>
        /// <param name="oldChar">The character to replace.</param>
        /// <param name="newChar">The character to replace <paramref name="oldChar"/> with.</param>
        public void Replace(char oldChar, char newChar) => Replace(oldChar, newChar, 0, Length);

        /// <summary>
        /// Replaces all instances of one character with another in this builder.
        /// </summary>
        /// <param name="oldChar">The character to replace.</param>
        /// <param name="newChar">The character to replace <paramref name="oldChar"/> with.</param>
        /// <param name="startIndex">The index to start in this builder.</param>
        /// <param name="count">The number of characters to read in this builder.</param>
        public void Replace(char oldChar, char newChar, int startIndex, int count)
        {
            int currentLength = Length;
            if ((uint)startIndex > (uint)currentLength)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || startIndex > currentLength - count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            int endIndex = startIndex + count;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (buffer[i] == oldChar)
                {
                    buffer[i] = newChar;
                }
            }
        }

        /// <summary>
        /// Replaces all instances of one string with another in this builder.
        /// </summary>
        /// <param name="oldValue">The string to replace.</param>
        /// <param name="newValue">The string to replace <paramref name="oldValue"/> with.</param>
        /// <remarks>
        /// If <paramref name="newValue"/> is <c>null</c>, instances of <paramref name="oldValue"/>
        /// are removed from this builder.
        /// </remarks>
        public void Replace(string oldValue, string newValue) => Replace(oldValue, newValue, 0, Length);

        /// <summary>
        /// Replaces all instances of one string with another in part of this builder.
        /// </summary>
        /// <param name="oldValue">The string to replace.</param>
        /// <param name="newValue">The string to replace <paramref name="oldValue"/> with.</param>
        /// <param name="startIndex">The index to start in this builder.</param>
        /// <param name="count">The number of characters to read in this builder.</param>
        /// <remarks>
        /// If <paramref name="newValue"/> is <c>null</c>, instances of <paramref name="oldValue"/>
        /// are removed from this builder.
        /// </remarks>
        public void Replace(string oldValue, string newValue, int startIndex, int count)
        {
            int currentLength = Length;

            if ((uint)startIndex > (uint)currentLength)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || startIndex > currentLength - count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (oldValue == null)
            {
                throw new ArgumentNullException(nameof(oldValue));
            }

            if (oldValue.Length == 0)
            {
                throw new ArgumentException("oldValue.Length is 0", nameof(oldValue));
            }

            newValue = newValue ?? string.Empty;

            var readOnlySpan = AsSpan();
            int endIndex = startIndex + count;
            int matchCount = 0;

            for (int i = startIndex; i < endIndex; i += oldValue.Length)
            {
                var span = readOnlySpan.Slice(i, endIndex - i);
                var pos = span.IndexOf(oldValue.AsSpan(), StringComparison.Ordinal);
                if (pos == -1)
                {
                    break;
                }
                i += pos;
                matchCount++;
            }

            if (matchCount == 0)
                return;

            var newBuffer = ArrayPool<char>.Shared.Rent(Math.Max(DefaultBufferSize, Length + (newValue.Length - oldValue.Length) * matchCount));

            buffer.AsSpan(0, startIndex).CopyTo(newBuffer);
            int newBufferIndex = startIndex;

            for (int i = startIndex; i < endIndex; i += oldValue.Length)
            {
                var span = readOnlySpan.Slice(i, endIndex - i);
                var pos = span.IndexOf(oldValue.AsSpan(), StringComparison.Ordinal);
                if (pos == -1)
                {
                    var remain = readOnlySpan.Slice(i);
                    remain.CopyTo(newBuffer.AsSpan(newBufferIndex));
                    newBufferIndex += remain.Length;
                    break;
                }
                readOnlySpan.Slice(i, pos).CopyTo(newBuffer.AsSpan(newBufferIndex));
                newValue.AsSpan().CopyTo(newBuffer.AsSpan(newBufferIndex + pos));
                newBufferIndex += pos + newValue.Length;
                i += pos;
            }

            if (buffer.Length != ThreadStaticBufferSize)
            {
                ArrayPool<char>.Shared.Return(buffer);
            }
            buffer = newBuffer;
            index = newBufferIndex;
        }

        /// <summary>
        /// Removes a range of characters from this builder.
        /// </summary>
        /// <remarks>
        /// This method does not reduce the capacity of this builder.
        /// </remarks>
        public void Remove(int startIndex, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (length > Length - startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (Length == length && startIndex == 0)
            {
                index = 0;
                return;
            }

            if (length == 0)
            {
                return;
            }

            buffer.AsSpan(startIndex + length).CopyTo(buffer.AsSpan(startIndex));
            index -= length;
        }

        // Output

        /// <summary>Copy inner buffer to the destination span.</summary>
        public bool TryCopyTo(Span<char> destination, out int charsWritten)
        {
            if (destination.Length < index)
            {
                charsWritten = 0;
                return false;
            }

            charsWritten = index;
            buffer.AsSpan(0, index).CopyTo(destination);
            return true;
        }

        /// <summary>Converts the value of this instance to a System.String.</summary>
        public override string ToString()
        {
            return new string(buffer, 0, index);
        }

        // IBufferWriter

        /// <summary>IBufferWriter.GetMemory.</summary>
        public Memory<char> GetMemory(int sizeHint)
        {
            if ((buffer.Length - index) < sizeHint)
            {
                Grow(sizeHint);
            }

            return buffer.AsMemory(index);
        }

        /// <summary>IBufferWriter.GetSpan.</summary>
        public Span<char> GetSpan(int sizeHint)
        {
            if ((buffer.Length - index) < sizeHint)
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

        void IResettableBufferWriter<char>.Reset()
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

        /// <summary>
        /// Register custom formatter
        /// </summary>
        public static void RegisterTryFormat<T>(TryFormat<T> formatMethod)
        {
            FormatterCache<T>.TryFormatDelegate = formatMethod;
        }

        public static class FormatterCache<T>
        {
            public static TryFormat<T> TryFormatDelegate;
            static FormatterCache()
            {
                var formatter = (TryFormat<T>)CreateFormatter(typeof(T));
                if (formatter == null)
                {
                    if (typeof(T).IsEnum)
                    {
                        formatter = new TryFormat<T>(EnumUtil<T>.TryFormatUtf16);
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        formatter = new TryFormat<T>(TryFormatString);
                    }
                    else
                    {
                        formatter = new TryFormat<T>(TryFormatDefault);
                    }
                }

                TryFormatDelegate = formatter;
            }

            static bool TryFormatString(T value, Span<char> dest, out int written, ReadOnlySpan<char> format)
            {
                var s = value as string;

                if (s == null)
                {
                    written = 0;
                    return true;
                }

                // also use this length when result is false.
                written = s.Length;
                return s.AsSpan().TryCopyTo(dest);
            }

            static bool TryFormatDefault(T value, Span<char> dest, out int written, ReadOnlySpan<char> format)
            {
                if (value == null)
                {
                    written = 0;
                    return true;
                }

                var s = value.ToString();

                // also use this length when result is false.
                written = s.Length;
                return s.AsSpan().TryCopyTo(dest);
            }
        }
    }
}