// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Globalization
{
    internal static class TimeSpanFormat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong DivRem(ulong a, ulong b, out ulong result)
        {
            ulong div = a / b;
            result = a - (div * b);
            return div;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint DivRem(uint a, uint b, out uint result)
        {
            uint div = a / b;
            result = a - (div * b);
            return div;
        }

        /// <summary>Main method called from TimeSpan.TryFormat.</summary>
        internal static bool TryFormat(TimeSpan value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider formatProvider)
        {
            if (format.Length == 0)
            {
                return TryFormatStandard(value, StandardFormat.C, null, destination, out charsWritten);
            }

            if (format.Length == 1)
            {
                char c = format[0];
                if (c == 'c' || ((c | 0x20) == 't'))
                {
                    return TryFormatStandard(value, StandardFormat.C, null, destination, out charsWritten);
                }
            }

            charsWritten = 0;
            return false;
        }

        private enum StandardFormat { C, G, g }

        private static bool TryFormatStandard(TimeSpan value, StandardFormat format, string decimalSeparator, Span<char> destination, out int charsWritten)
        {
            Debug.Assert(format == StandardFormat.C || format == StandardFormat.G || format == StandardFormat.g);

            // First, calculate how large an output buffer is needed to hold the entire output.
            int requiredOutputLength = 8; // start with "hh:mm:ss" and adjust as necessary

            uint fraction;
            ulong totalSecondsRemaining;
            {
                // Turn this into a non-negative TimeSpan if possible.
                long ticks = value.Ticks;
                if (ticks < 0)
                {
                    requiredOutputLength = 9; // requiredOutputLength + 1 for the leading '-' sign
                    ticks = -ticks;
                    if (ticks < 0)
                    {
                        Debug.Assert(ticks == long.MinValue /* -9223372036854775808 */);

                        // We computed these ahead of time; they're straight from the decimal representation of Int64.MinValue.
                        fraction = 4775808;
                        totalSecondsRemaining = 922337203685;
                        goto AfterComputeFraction;
                    }
                }

                totalSecondsRemaining = DivRem((ulong)ticks, TimeSpan.TicksPerSecond, out ulong fraction64);
                fraction = (uint)fraction64;
            }

        AfterComputeFraction:
            // Only write out the fraction if it's non-zero, and in that
            // case write out the entire fraction (all digits).
            Debug.Assert(fraction < 10_000_000);
            int fractionDigits = 0;
            switch (format)
            {
                case StandardFormat.C:
                    // "c": Write out a fraction only if it's non-zero, and write out all 7 digits of it.
                    if (fraction != 0)
                    {
                        fractionDigits = DateTimeFormat.MaxSecondsFractionDigits;
                        requiredOutputLength += fractionDigits + 1; // digits plus leading decimal separator
                    }
                    break;

                case StandardFormat.G:
                    // "G": Write out a fraction regardless of whether it's 0, and write out all 7 digits of it.
                    fractionDigits = DateTimeFormat.MaxSecondsFractionDigits;
                    requiredOutputLength += fractionDigits + 1; // digits plus leading decimal separator
                    break;

                default:
                    // "g": Write out a fraction only if it's non-zero, and write out only the most significant digits.
                    Debug.Assert(format == StandardFormat.g);
                    if (fraction != 0)
                    {
                        fractionDigits = DateTimeFormat.MaxSecondsFractionDigits - FormattingHelpers.CountDecimalTrailingZeros(fraction, out fraction);
                        requiredOutputLength += fractionDigits + 1; // digits plus leading decimal separator
                    }
                    break;
            }

            ulong totalMinutesRemaining = 0, seconds = 0;
            if (totalSecondsRemaining > 0)
            {
                // Only compute minutes if the TimeSpan has an absolute value of >= 1 minute.
                totalMinutesRemaining = DivRem(totalSecondsRemaining, 60 /* seconds per minute */, out seconds);
                Debug.Assert(seconds < 60);
            }

            ulong totalHoursRemaining = 0, minutes = 0;
            if (totalMinutesRemaining > 0)
            {
                // Only compute hours if the TimeSpan has an absolute value of >= 1 hour.
                totalHoursRemaining = DivRem(totalMinutesRemaining, 60 /* minutes per hour */, out minutes);
                Debug.Assert(minutes < 60);
            }

            // At this point, we can switch over to 32-bit DivRem since the data has shrunk far enough.
            Debug.Assert(totalHoursRemaining <= uint.MaxValue);

            uint days = 0, hours = 0;
            if (totalHoursRemaining > 0)
            {
                // Only compute days if the TimeSpan has an absolute value of >= 1 day.
                days = DivRem((uint)totalHoursRemaining, 24 /* hours per day */, out hours);
                Debug.Assert(hours < 24);
            }

            int hourDigits = 2;
            if (format == StandardFormat.g && hours < 10)
            {
                // "g": Only writing a one-digit hour, rather than expected two-digit hour
                hourDigits = 1;
                requiredOutputLength--;
            }

            int dayDigits = 0;
            if (days > 0)
            {
                dayDigits = FormattingHelpers.CountDigits(days);
                Debug.Assert(dayDigits <= 8);
                requiredOutputLength += dayDigits + 1; // for the leading "d."
            }
            else if (format == StandardFormat.G)
            {
                // "G": has a leading "0:" if days is 0
                requiredOutputLength += 2;
                dayDigits = 1;
            }

            if (destination.Length < requiredOutputLength)
            {
                charsWritten = 0;
                return false;
            }

            // Write leading '-' if necessary
            int idx = 0;
            if (value.Ticks < 0)
            {
                destination[idx++] = '-';
            }

            // Write day and separator, if necessary
            if (dayDigits != 0)
            {
                WriteDigits(days, destination.Slice(idx, dayDigits));
                idx += dayDigits;
                destination[idx++] = format == StandardFormat.C ? '.' : ':';
            }

            // Write "[h]h:mm:ss
            Debug.Assert(hourDigits == 1 || hourDigits == 2);
            if (hourDigits == 2)
            {
                WriteTwoDigits(hours, destination.Slice(idx));
                idx += 2;
            }
            else
            {
                destination[idx++] = (char)('0' + hours);
            }
            destination[idx++] = ':';
            WriteTwoDigits((uint)minutes, destination.Slice(idx));
            idx += 2;
            destination[idx++] = ':';
            WriteTwoDigits((uint)seconds, destination.Slice(idx));
            idx += 2;

            // Write fraction and separator, if necessary
            if (fractionDigits != 0)
            {
                Debug.Assert(format == StandardFormat.C || decimalSeparator != null);
                if (format == StandardFormat.C)
                {
                    destination[idx++] = '.';
                }
                else if (decimalSeparator.Length == 1)
                {
                    destination[idx++] = decimalSeparator[0];
                }
                else
                {
                    decimalSeparator.AsSpan().CopyTo(destination);
                    idx += decimalSeparator.Length;
                }
                WriteDigits(fraction, destination.Slice(idx, fractionDigits));
                idx += fractionDigits;
            }

            Debug.Assert(idx == requiredOutputLength);
            charsWritten = requiredOutputLength;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteTwoDigits(uint value, Span<char> buffer)
        {
            Debug.Assert(buffer.Length >= 2);
            uint temp = '0' + value;
            value /= 10;
            buffer[1] = (char)(temp - (value * 10));
            buffer[0] = (char)('0' + value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteDigits(uint value, Span<char> buffer)
        {
            Debug.Assert(buffer.Length > 0);

            for (int i = buffer.Length - 1; i >= 1; i--)
            {
                uint temp = '0' + value;
                value /= 10;
                buffer[i] = (char)(temp - (value * 10));
            }

            Debug.Assert(value < 10);
            buffer[0] = (char)('0' + value);
        }
    }
}
