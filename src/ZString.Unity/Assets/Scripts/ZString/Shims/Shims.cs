using Cysharp.Text.Internal;
using System;
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

    public static class ShimsExtensions
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

        public static bool TryFormat(this System.Single value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return DoubleToStringConverter.TryFormat(destination, value, out charsWritten);
        }

        public static bool TryFormat(this System.Double value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return DoubleToStringConverter.TryFormat(destination, value, out charsWritten);
        }

        public static bool TryFormat(this System.Guid value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
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

        public static bool TryFormat(this System.SByte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteInt64(destination, out charsWritten, value);
        }

        public static bool TryFormat(this System.Int16 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteInt64(destination, out charsWritten, value);
        }

        public static bool TryFormat(this System.Int32 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteInt64(destination, out charsWritten, value);
        }

        public static bool TryFormat(this System.Int64 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteInt64(destination, out charsWritten, value);
        }

        public static bool TryFormat(this System.Byte value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteUInt64(destination, out charsWritten, value);
        }

        public static bool TryFormat(this System.UInt16 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteUInt64(destination, out charsWritten, value);
        }

        public static bool TryFormat(this System.UInt32 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteUInt64(destination, out charsWritten, value);
        }

        public static bool TryFormat(this System.UInt64 value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default)
        {
            return TryWriteUInt64(destination, out charsWritten, value);
        }

        static string GetFormat(ReadOnlySpan<char> format)
        {
            if (format.Length == 0)
            {
                return null;
            }
            return format.ToString();
        }

        static bool TryWriteInt64(Span<char> buffer, out int charsWritten, long value)
        {
            var offset = 0;
            charsWritten = 0;
            long num1 = value, num2, num3, num4, num5, div;

            if (value < 0)
            {
                if (value == long.MinValue) // -9223372036854775808
                {
                    if (buffer.Length < 20) { return false; }
                    buffer[offset++] = (char)'-';
                    buffer[offset++] = (char)'9';
                    buffer[offset++] = (char)'2';
                    buffer[offset++] = (char)'2';
                    buffer[offset++] = (char)'3';
                    buffer[offset++] = (char)'3';
                    buffer[offset++] = (char)'7';
                    buffer[offset++] = (char)'2';
                    buffer[offset++] = (char)'0';
                    buffer[offset++] = (char)'3';
                    buffer[offset++] = (char)'6';
                    buffer[offset++] = (char)'8';
                    buffer[offset++] = (char)'5';
                    buffer[offset++] = (char)'4';
                    buffer[offset++] = (char)'7';
                    buffer[offset++] = (char)'7';
                    buffer[offset++] = (char)'5';
                    buffer[offset++] = (char)'8';
                    buffer[offset++] = (char)'0';
                    buffer[offset++] = (char)'8';
                    charsWritten = offset;
                    return true;
                }

                if (buffer.Length < 1) { return false; }
                buffer[offset++] = (char)'-';
                num1 = unchecked(-value);
            }

            // WriteUInt64(inlined)

            if (num1 < 10000)
            {
                if (num1 < 10) { if (buffer.Length < 1) { return false; } goto L1; }
                if (num1 < 100) { if (buffer.Length < 2) { return false; } goto L2; }
                if (num1 < 1000) { if (buffer.Length < 3) { return false; } goto L3; }
                if (buffer.Length < 4) { return false; }
                goto L4;
            }
            else
            {
                num2 = num1 / 10000;
                num1 -= num2 * 10000;
                if (num2 < 10000)
                {
                    if (num2 < 10) { if (buffer.Length < 5) { return false; } goto L5; }
                    if (num2 < 100) { if (buffer.Length < 6) { return false; } goto L6; }
                    if (num2 < 1000) { if (buffer.Length < 7) { return false; } goto L7; }
                    if (buffer.Length < 8) { return false; }
                    goto L8;
                }
                else
                {
                    num3 = num2 / 10000;
                    num2 -= num3 * 10000;
                    if (num3 < 10000)
                    {
                        if (num3 < 10) { if (buffer.Length < 9) { return false; } goto L9; }
                        if (num3 < 100) { if (buffer.Length < 10) { return false; } goto L10; }
                        if (num3 < 1000) { if (buffer.Length < 11) { return false; } goto L11; }
                        if (buffer.Length < 12) { return false; }
                        goto L12;
                    }
                    else
                    {
                        num4 = num3 / 10000;
                        num3 -= num4 * 10000;
                        if (num4 < 10000)
                        {
                            if (num4 < 10) { if (buffer.Length < 13) { return false; } goto L13; }
                            if (num4 < 100) { if (buffer.Length < 14) { return false; } goto L14; }
                            if (num4 < 1000) { if (buffer.Length < 15) { return false; } goto L15; }
                            if (buffer.Length < 16) { return false; }
                            goto L16;
                        }
                        else
                        {
                            num5 = num4 / 10000;
                            num4 -= num5 * 10000;
                            if (num5 < 10000)
                            {
                                if (num5 < 10) { if (buffer.Length < 17) { return false; } goto L17; }
                                if (num5 < 100) { if (buffer.Length < 18) { return false; } goto L18; }
                                if (num5 < 1000) { if (buffer.Length < 19) { return false; } goto L19; }
                                if (buffer.Length < 20) { return false; }
                                goto L20;
                            }
                            L20:
                            buffer[offset++] = (char)('0' + (div = (num5 * 8389L) >> 23));
                            num5 -= div * 1000;
                            L19:
                            buffer[offset++] = (char)('0' + (div = (num5 * 5243L) >> 19));
                            num5 -= div * 100;
                            L18:
                            buffer[offset++] = (char)('0' + (div = (num5 * 6554L) >> 16));
                            num5 -= div * 10;
                            L17:
                            buffer[offset++] = (char)('0' + (num5));
                        }
                        L16:
                        buffer[offset++] = (char)('0' + (div = (num4 * 8389L) >> 23));
                        num4 -= div * 1000;
                        L15:
                        buffer[offset++] = (char)('0' + (div = (num4 * 5243L) >> 19));
                        num4 -= div * 100;
                        L14:
                        buffer[offset++] = (char)('0' + (div = (num4 * 6554L) >> 16));
                        num4 -= div * 10;
                        L13:
                        buffer[offset++] = (char)('0' + (num4));
                    }
                    L12:
                    buffer[offset++] = (char)('0' + (div = (num3 * 8389L) >> 23));
                    num3 -= div * 1000;
                    L11:
                    buffer[offset++] = (char)('0' + (div = (num3 * 5243L) >> 19));
                    num3 -= div * 100;
                    L10:
                    buffer[offset++] = (char)('0' + (div = (num3 * 6554L) >> 16));
                    num3 -= div * 10;
                    L9:
                    buffer[offset++] = (char)('0' + (num3));
                }
                L8:
                buffer[offset++] = (char)('0' + (div = (num2 * 8389L) >> 23));
                num2 -= div * 1000;
                L7:
                buffer[offset++] = (char)('0' + (div = (num2 * 5243L) >> 19));
                num2 -= div * 100;
                L6:
                buffer[offset++] = (char)('0' + (div = (num2 * 6554L) >> 16));
                num2 -= div * 10;
                L5:
                buffer[offset++] = (char)('0' + (num2));
            }
            L4:
            buffer[offset++] = (char)('0' + (div = (num1 * 8389L) >> 23));
            num1 -= div * 1000;
            L3:
            buffer[offset++] = (char)('0' + (div = (num1 * 5243L) >> 19));
            num1 -= div * 100;
            L2:
            buffer[offset++] = (char)('0' + (div = (num1 * 6554L) >> 16));
            num1 -= div * 10;
            L1:
            buffer[offset++] = (char)('0' + (num1));

            charsWritten = offset;
            return true;
        }

        static bool TryWriteUInt64(Span<char> buffer, out int charsWritten, ulong value)
        {
            ulong num1 = value, num2, num3, num4, num5, div;
            charsWritten = 0;
            var offset = 0;

            if (num1 < 10000)
            {
                if (num1 < 10) { if (buffer.Length < 1) { return false; } goto L1; }
                if (num1 < 100) { if (buffer.Length < 2) { return false; } goto L2; }
                if (num1 < 1000) { if (buffer.Length < 3) { return false; } goto L3; }
                if (buffer.Length < 4) { return false; }
                goto L4;
            }
            else
            {
                num2 = num1 / 10000;
                num1 -= num2 * 10000;
                if (num2 < 10000)
                {
                    if (num2 < 10) { if (buffer.Length < 5) { return false; } goto L5; }
                    if (num2 < 100) { if (buffer.Length < 6) { return false; } goto L6; }
                    if (num2 < 1000) { if (buffer.Length < 7) { return false; } goto L7; }
                    if (buffer.Length < 8) { return false; }
                    goto L8;
                }
                else
                {
                    num3 = num2 / 10000;
                    num2 -= num3 * 10000;
                    if (num3 < 10000)
                    {
                        if (num3 < 10) { if (buffer.Length < 9) { return false; } goto L9; }
                        if (num3 < 100) { if (buffer.Length < 10) { return false; } goto L10; }
                        if (num3 < 1000) { if (buffer.Length < 11) { return false; } goto L11; }
                        if (buffer.Length < 12) { return false; }
                        goto L12;
                    }
                    else
                    {
                        num4 = num3 / 10000;
                        num3 -= num4 * 10000;
                        if (num4 < 10000)
                        {
                            if (num4 < 10) { if (buffer.Length < 13) { return false; } goto L13; }
                            if (num4 < 100) { if (buffer.Length < 14) { return false; } goto L14; }
                            if (num4 < 1000) { if (buffer.Length < 15) { return false; } goto L15; }
                            if (buffer.Length < 16) { return false; }
                            goto L16;
                        }
                        else
                        {
                            num5 = num4 / 10000;
                            num4 -= num5 * 10000;
                            if (num5 < 10000)
                            {
                                if (num5 < 10) { if (buffer.Length < 17) { return false; } goto L17; }
                                if (num5 < 100) { if (buffer.Length < 18) { return false; } goto L18; }
                                if (num5 < 1000) { if (buffer.Length < 19) { return false; } goto L19; }
                                if (buffer.Length < 20) { return false; }
                                goto L20;
                            }
                            L20:
                            buffer[offset++] = (char)('0' + (div = (num5 * 8389UL) >> 23));
                            num5 -= div * 1000;
                            L19:
                            buffer[offset++] = (char)('0' + (div = (num5 * 5243UL) >> 19));
                            num5 -= div * 100;
                            L18:
                            buffer[offset++] = (char)('0' + (div = (num5 * 6554UL) >> 16));
                            num5 -= div * 10;
                            L17:
                            buffer[offset++] = (char)('0' + (num5));
                        }
                        L16:
                        buffer[offset++] = (char)('0' + (div = (num4 * 8389UL) >> 23));
                        num4 -= div * 1000;
                        L15:
                        buffer[offset++] = (char)('0' + (div = (num4 * 5243UL) >> 19));
                        num4 -= div * 100;
                        L14:
                        buffer[offset++] = (char)('0' + (div = (num4 * 6554UL) >> 16));
                        num4 -= div * 10;
                        L13:
                        buffer[offset++] = (char)('0' + (num4));
                    }
                    L12:
                    buffer[offset++] = (char)('0' + (div = (num3 * 8389UL) >> 23));
                    num3 -= div * 1000;
                    L11:
                    buffer[offset++] = (char)('0' + (div = (num3 * 5243UL) >> 19));
                    num3 -= div * 100;
                    L10:
                    buffer[offset++] = (char)('0' + (div = (num3 * 6554UL) >> 16));
                    num3 -= div * 10;
                    L9:
                    buffer[offset++] = (char)('0' + (num3));
                }
                L8:
                buffer[offset++] = (char)('0' + (div = (num2 * 8389UL) >> 23));
                num2 -= div * 1000;
                L7:
                buffer[offset++] = (char)('0' + (div = (num2 * 5243UL) >> 19));
                num2 -= div * 100;
                L6:
                buffer[offset++] = (char)('0' + (div = (num2 * 6554UL) >> 16));
                num2 -= div * 10;
                L5:
                buffer[offset++] = (char)('0' + (num2));
            }
            L4:
            buffer[offset++] = (char)('0' + (div = (num1 * 8389UL) >> 23));
            num1 -= div * 1000;
            L3:
            buffer[offset++] = (char)('0' + (div = (num1 * 5243UL) >> 19));
            num1 -= div * 100;
            L2:
            buffer[offset++] = (char)('0' + (div = (num1 * 6554UL) >> 16));
            num1 -= div * 10;
            L1:
            buffer[offset++] = (char)('0' + (num1));

            charsWritten = offset;
            return true;
        }
    }
}