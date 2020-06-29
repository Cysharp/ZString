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

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(string value)
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