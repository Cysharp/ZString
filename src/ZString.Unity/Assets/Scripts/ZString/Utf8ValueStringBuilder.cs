using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder : IDisposable, IBufferWriter<byte>
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
        static byte[] scratchBuffer;

        byte[] buffer;
        int index;

        /// <summary>Length of written buffer.</summary>
        public int Length => index;

        /// <summary>Get the written buffer data.</summary>
        public ReadOnlySpan<byte> AsSpan() => buffer.AsSpan(0, index);

        /// <summary>Get the written buffer data.</summary>
        public ReadOnlyMemory<byte> AsMemory() => buffer.AsMemory(0, index);

        /// <summary>Get the written buffer data.</summary>
        public ArraySegment<byte> AsArraySegment() => new ArraySegment<byte>(buffer, 0, index);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf8ValueStringBuilder(bool disposeImmediately)
        {
            byte[] buf;
            if (disposeImmediately)
            {
                buf = scratchBuffer;
                if (buf == null)
                {
                    buf = scratchBuffer = new byte[ThreadStaticBufferSize];
                }
            }
            else
            {
                buf = ArrayPool<byte>.Shared.Rent(DefaultBufferSize);
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
                    ArrayPool<byte>.Shared.Return(buffer);
                }
            }
            buffer = null;
            index = 0;
        }

        void TryGrow(int sizeHint)
        {
            if (buffer.Length < index + sizeHint)
            {
                Grow(sizeHint);
            }
        }

        void Grow(int sizeHint = 0)
        {
            var nextSize = buffer.Length * 2;
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
        public unsafe void Append(char value)
        {
            var maxLen = UTF8NoBom.GetMaxByteCount(1);
            if (buffer.Length - index < maxLen)
            {
                Grow(maxLen);
            }

            fixed (byte* bp = &buffer[index])
            {
                index += UTF8NoBom.GetBytes(&value, 1, bp, maxLen);
            }
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
            var maxLen = UTF8NoBom.GetMaxByteCount(value.Length);
            if (buffer.Length - index < maxLen)
            {
                Grow(maxLen);
            }

            index += UTF8NoBom.GetBytes(value, 0, value.Length, buffer, index);
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
                Grow();
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

        /// <summary>Encode the innner utf8 buffer to a System.String.</summary>
        public override string ToString()
        {
            return UTF8NoBom.GetString(buffer, 0, index);
        }

        // IBufferWriter

        /// <summary>IBufferWriter.GetMemory.</summary>
        public Memory<byte> GetMemory(int sizeHint)
        {
            if ((buffer.Length - index) < sizeHint)
            {
                Grow(sizeHint);
            }

            return buffer.AsMemory(index);
        }

        /// <summary>IBufferWriter.GetSpan.</summary>
        public Span<byte> GetSpan(int sizeHint)
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

        static class FormatterCache<T>
        {
            public static TryFormat<T> TryFormatDelegate;
            static FormatterCache()
            {
                var formatter = (TryFormat<T>)CreateFormatter(typeof(T));
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

                var s = value.ToString();

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