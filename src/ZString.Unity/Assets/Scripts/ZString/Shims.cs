#if NETSTANDARD

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cysharp.Text
{
    internal static class Int32
    {
        /// <summary>0 ~ 9</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNumber(char c)
        {
            return '0' <= c && c <= '9';
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Parse(ReadOnlySpan<char> s)
        {
            var value = 0L;
            var sign = 1;

            if (s[0] == '-')
            {
                sign = -1;
            }

            for (int i = ((sign == -1) ? 1 : 0); i < s.Length; i++)
            {
                if (!IsNumber(s[i]))
                {
                    goto END;
                }

                // long.MinValue causes overflow so use unchecked.
                value = unchecked(value * 10 + ((byte)s[i] - '0'));
            }

            END:
            return checked((int)(unchecked(value * sign)));
        }
    }

    internal static class ShimsExtensions
    {
        public static unsafe int GetBytes(this Encoding encoding, ReadOnlySpan<char> span, Span<byte> bytes)
        {
            if (span.Length == 0) return 0;
            fixed (char* src = span)
            fixed (byte* dest = bytes)
            {
                return encoding.GetBytes(src, span.Length, dest, bytes.Length);
            }
        }

        public static bool TryFormat(this System.Guid value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return Unsafe.As<Guid, GuidEx>(ref value).TryFormat(destination, out charsWritten, format);
        }

        public static bool TryFormat(this System.TimeSpan value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            var f = GetFormat(format);
            var span = ((f == null) ? value.ToString() : value.ToString(f)).AsSpan();
            if (span.TryCopyTo(destination))
            {
                charsWritten = span.Length;
                return true;
            }
            else
            {
                charsWritten = 0;
                return false;
            }
        }

        public static bool TryFormat(this System.DateTime value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            var f = GetFormat(format);
            var span = ((f == null) ? value.ToString() : value.ToString(f)).AsSpan();
            if (span.TryCopyTo(destination))
            {
                charsWritten = span.Length;
                return true;
            }
            else
            {
                charsWritten = 0;
                return false;
            }
        }

        public static bool TryFormat(this System.DateTimeOffset value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            var f = GetFormat(format);
            var span = ((f == null) ? value.ToString() : value.ToString(f)).AsSpan();
            if (span.TryCopyTo(destination))
            {
                charsWritten = span.Length;
                return true;
            }
            else
            {
                charsWritten = 0;
                return false;
            }
        }

        public static bool TryFormat(this System.Decimal value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return Number.TryFormatDecimal(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
        }

        public static bool TryFormat(this System.Single value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return Number.TryFormatSingle(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
        }

        public static bool TryFormat(this System.Double value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return Number.TryFormatDouble(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
        }

        public static bool TryFormat(this System.SByte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
            }
            else
            {
                if (value < 0 && format.Length > 0 && (format[0] == 'X' || format[0] == 'x'))
                {
                    uint temp = (uint)(value & 0x000000FF);
                    return Number.TryFormatUInt32(temp, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
                }
                return Number.TryFormatInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        public static bool TryFormat(this System.Int16 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
            }
            else
            {
                if (value < 0 && format.Length > 0 && (format[0] == 'X' || format[0] == 'x'))
                {
                    uint temp = (uint)(value & 0x0000FFFF);
                    return Number.TryFormatUInt32(temp, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
                }
                return Number.TryFormatInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        public static bool TryFormat(this System.Int32 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
            }
            else
            {
                return Number.TryFormatInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        public static bool TryFormat(this System.Int64 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteInt64(destination, out charsWritten, value);
            }
            else
            {
                return Number.TryFormatInt64(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        public static bool TryFormat(this System.Byte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
            }
            else
            {
                return Number.TryFormatUInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        public static bool TryFormat(this System.UInt16 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
            }
            else
            {
                return Number.TryFormatUInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        public static bool TryFormat(this System.UInt32 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
            }
            else
            {
                return Number.TryFormatUInt32(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        public static bool TryFormat(this System.UInt64 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            if (format.Length == 0)
            {
                return FastNumberWriter.TryWriteUInt64(destination, out charsWritten, value);
            }
            else
            {
                return Number.TryFormatUInt64(value, format, NumberFormatInfo.CurrentInfo, destination, out charsWritten);
            }
        }

        static string? GetFormat(ReadOnlySpan<char> format)
        {
            if (format.Length == 0)
            {
                return null;
            }

            return format.ToString();
        }
    }
}

#endif