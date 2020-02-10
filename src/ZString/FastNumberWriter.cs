using System;
using System.Collections.Generic;
using System.Text;

namespace Cysharp.Text
{
    internal static class FastNumberWriter
    {
        // Faster than .NET Core .TryFormat without format string.

        public static bool TryWriteInt64(Span<char> buffer, out int charsWritten, long value)
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

        public static bool TryWriteUInt64(Span<char> buffer, out int charsWritten, ulong value)
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
