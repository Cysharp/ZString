// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace System
{
    //This class contains only static members and does not require the serializable attribute.
    internal static
    class DateTimeFormat
    {
        internal const int MaxSecondsFractionDigits = 7;
        internal static readonly TimeSpan NullOffset = TimeSpan.MinValue;

        private const int DEFAULT_ALL_DATETIMES_SIZE = 132;

        internal static readonly DateTimeFormatInfo InvariantFormatInfo = CultureInfo.InvariantCulture.DateTimeFormat;
        internal static readonly string[] InvariantAbbreviatedMonthNames = InvariantFormatInfo.AbbreviatedMonthNames;
        internal static readonly string[] InvariantAbbreviatedDayNames = InvariantFormatInfo.AbbreviatedDayNames;
        internal const string Gmt = "GMT";

        internal static bool TryFormat(DateTime dateTime, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider) =>
            TryFormat(dateTime, destination, out charsWritten, format, provider, NullOffset);

        internal static bool TryFormat(DateTime dateTime, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider, TimeSpan offset)
        {
            if (format.Length == 1)
            {
                // Optimize for these standard formats that are not affected by culture.
                switch (format[0])
                {
                    // Round trip format
                    case 'o':
                    case 'O':
                        return TryFormatO(dateTime, offset, destination, out charsWritten);

                    // RFC1123
                    case 'r':
                    case 'R':
                        return TryFormatR(dateTime, offset, destination, out charsWritten);
                }
            }

            charsWritten = 0;
            return false;
        }

        // Roundtrippable format. One of
        //   012345678901234567890123456789012
        //   ---------------------------------
        //   2017-06-12T05:30:45.7680000-07:00
        //   2017-06-12T05:30:45.7680000Z           (Z is short for "+00:00" but also distinguishes DateTimeKind.Utc from DateTimeKind.Local)
        //   2017-06-12T05:30:45.7680000            (interpreted as local time wrt to current time zone)
        private static bool TryFormatO(DateTime dateTime, TimeSpan offset, Span<char> destination, out int charsWritten)
        {
            const int MinimumBytesNeeded = 27;

            int charsRequired = MinimumBytesNeeded;
            DateTimeKind kind = DateTimeKind.Local;

            if (offset == NullOffset)
            {
                kind = dateTime.Kind;
                if (kind == DateTimeKind.Local)
                {
                    offset = TimeZoneInfo.Local.GetUtcOffset(dateTime);
                    charsRequired += 6;
                }
                else if (kind == DateTimeKind.Utc)
                {
                    charsRequired += 1;
                }
            }
            else
            {
                charsRequired += 6;
            }

            if (destination.Length < charsRequired)
            {
                charsWritten = 0;
                return false;
            }
            charsWritten = charsRequired;

            // Hoist most of the bounds checks on destination.
            { var unused = destination[MinimumBytesNeeded - 1]; }

            WriteFourDecimalDigits((uint)dateTime.Year, destination, 0);
            destination[4] = '-';
            WriteTwoDecimalDigits((uint)dateTime.Month, destination, 5);
            destination[7] = '-';
            WriteTwoDecimalDigits((uint)dateTime.Day, destination, 8);
            destination[10] = 'T';
            WriteTwoDecimalDigits((uint)dateTime.Hour, destination, 11);
            destination[13] = ':';
            WriteTwoDecimalDigits((uint)dateTime.Minute, destination, 14);
            destination[16] = ':';
            WriteTwoDecimalDigits((uint)dateTime.Second, destination, 17);
            destination[19] = '.';
            WriteDigits((uint)((ulong)dateTime.Ticks % (ulong)TimeSpan.TicksPerSecond), destination.Slice(20, 7));

            if (kind == DateTimeKind.Local)
            {
                char sign;
                if (offset < default(TimeSpan) /* a "const" version of TimeSpan.Zero */)
                {
                    sign = '-';
                    offset = TimeSpan.FromTicks(-offset.Ticks);
                }
                else
                {
                    sign = '+';
                }

                // Writing the value backward allows the JIT to optimize by
                // performing a single bounds check against buffer.
                WriteTwoDecimalDigits((uint)offset.Minutes, destination, 31);
                destination[30] = ':';
                WriteTwoDecimalDigits((uint)offset.Hours, destination, 28);
                destination[27] = sign;
            }
            else if (kind == DateTimeKind.Utc)
            {
                destination[27] = 'Z';
            }

            return true;
        }

        // Rfc1123
        //   01234567890123456789012345678
        //   -----------------------------
        //   Tue, 03 Jan 2017 08:08:05 GMT
        private static bool TryFormatR(DateTime dateTime, TimeSpan offset, Span<char> destination, out int charsWritten)
        {
            // Writing the check in this fashion elides all bounds checks on 'destination'
            // for the remainder of the method.
            if (28 >= (uint)destination.Length)
            {
                charsWritten = 0;
                return false;
            }

            if (offset != NullOffset)
            {
                // Convert to UTC invariants.
                dateTime = dateTime - offset;
            }

            dateTime.GetDatePart(out int year, out int month, out int day);

            string dayAbbrev = InvariantAbbreviatedDayNames[(int)dateTime.DayOfWeek];
            Debug.Assert(dayAbbrev.Length == 3);

            string monthAbbrev = InvariantAbbreviatedMonthNames[month - 1];
            Debug.Assert(monthAbbrev.Length == 3);

            destination[0] = dayAbbrev[0];
            destination[1] = dayAbbrev[1];
            destination[2] = dayAbbrev[2];
            destination[3] = ',';
            destination[4] = ' ';
            WriteTwoDecimalDigits((uint)day, destination, 5);
            destination[7] = ' ';
            destination[8] = monthAbbrev[0];
            destination[9] = monthAbbrev[1];
            destination[10] = monthAbbrev[2];
            destination[11] = ' ';
            WriteFourDecimalDigits((uint)year, destination, 12);
            destination[16] = ' ';
            WriteTwoDecimalDigits((uint)dateTime.Hour, destination, 17);
            destination[19] = ':';
            WriteTwoDecimalDigits((uint)dateTime.Minute, destination, 20);
            destination[22] = ':';
            WriteTwoDecimalDigits((uint)dateTime.Second, destination, 23);
            destination[25] = ' ';
            destination[26] = 'G';
            destination[27] = 'M';
            destination[28] = 'T';

            charsWritten = 29;
            return true;
        }

        /// <summary>
        /// Writes a value [ 00 .. 99 ] to the buffer starting at the specified offset.
        /// This method performs best when the starting index is a constant literal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteTwoDecimalDigits(uint value, Span<char> destination, int offset)
        {
            Debug.Assert(0 <= value && value <= 99);

            uint temp = '0' + value;
            value /= 10;
            destination[offset + 1] = (char)(temp - (value * 10));
            destination[offset] = (char)('0' + value);
        }

        /// <summary>
        /// Writes a value [ 0000 .. 9999 ] to the buffer starting at the specified offset.
        /// This method performs best when the starting index is a constant literal.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteFourDecimalDigits(uint value, Span<char> buffer, int startingIndex = 0)
        {
            Debug.Assert(0 <= value && value <= 9999);

            uint temp = '0' + value;
            value /= 10;
            buffer[startingIndex + 3] = (char)(temp - (value * 10));

            temp = '0' + value;
            value /= 10;
            buffer[startingIndex + 2] = (char)(temp - (value * 10));

            temp = '0' + value;
            value /= 10;
            buffer[startingIndex + 1] = (char)(temp - (value * 10));

            buffer[startingIndex] = (char)('0' + value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void WriteDigits(ulong value, Span<char> buffer)
        {
            // We can mutate the 'value' parameter since it's a copy-by-value local.
            // It'll be used to represent the value left over after each division by 10.

            for (int i = buffer.Length - 1; i >= 1; i--)
            {
                ulong temp = '0' + value;
                value /= 10;
                buffer[i] = (char)(temp - (value * 10));
            }

            Debug.Assert(value < 10);
            buffer[0] = (char)('0' + value);
        }

    }
}
