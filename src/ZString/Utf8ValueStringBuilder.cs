using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder : IDisposable
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

        public int Length => index;
        public ReadOnlySpan<byte> AsSpan() => buffer.AsSpan(0, index);

        internal void Init(bool disposeImmediately)
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

        public void Dispose()
        {
            if (buffer.Length != ThreadStaticBufferSize)
            {
                ArrayPool<byte>.Shared.Return(buffer);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendNewLine()
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(string value)
        {
            Append(value);
            AppendNewLine();
        }

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

        public void AppendLine<T>(T value)
        {
            Append(value);
            AppendNewLine();
        }

        // Output

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

        public Task CopyToAsync(Stream stream)
        {
            return stream.WriteAsync(buffer, 0, index);
        }

        public override string ToString()
        {
            return UTF8NoBom.GetString(buffer, 0, index);
        }

        // IBufferWriter like interface.

        public Span<byte> GetWritableBuffer(int sizeHint = 0)
        {
            if ((buffer.Length - index) < sizeHint)
            {
                Grow(sizeHint);
            }

            return buffer.AsSpan(index);
        }

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