using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace System
{
    internal static partial
    class DateTimeFormat
    {
        private static volatile Calendar GregorianCalendar_s_defaultInstance;
        private static Calendar GregorianCalendar_GetDefaultInstance()
        {
            GregorianCalendar_s_defaultInstance = GregorianCalendar_s_defaultInstance ??new GregorianCalendar();
            return GregorianCalendar_s_defaultInstance;
        }

        private static readonly Dictionary<(string ShortDatePattern, string LongTimePattern), string> dateTimeOffsetPatternCache = new Dictionary<(string, string), string>();

        private static string GetDateTimeOffsetPatternCache(DateTimeFormatInfo dtfi)
        {
            var key = (dtfi.ShortDatePattern, dtfi.LongTimePattern);
            if (!dateTimeOffsetPatternCache.TryGetValue(key, out var value))
            {
                value = GetDateTimeOffsetPattern(dtfi);
                dateTimeOffsetPatternCache[key] = value;
            }
            return value;
        }
#region from DateTimeFormatInfo.cs
        /// Return the default pattern DateTimeOffset : shortDate + long time + time zone offset.
        /// This is used by DateTimeFormat.cs to get the pattern for short Date + long time +  time zone offset
        /// We put this internal property here so that we can avoid doing the
        /// concatation every time somebody uses this form.
        internal static string GetDateTimeOffsetPattern(DateTimeFormatInfo dtfi)
        {
            /* LongTimePattern might contain a "z" as part of the format string in which case we don't want to append a time zone offset */

            bool foundZ = false;
            bool inQuote = false;
            char quote = '\'';
            for (int i = 0; !foundZ && i < dtfi.LongTimePattern.Length; i++)
            {
                switch (dtfi.LongTimePattern[i])
                {
                    case 'z':
                        /* if we aren't in a quote, we've found a z */
                        foundZ = !inQuote;
                        /* we'll fall out of the loop now because the test includes !foundZ */
                        break;
                    case '\'':
                    case '\"':
                        if (inQuote && (quote == dtfi.LongTimePattern[i]))
                        {
                            /* we were in a quote and found a matching exit quote, so we are outside a quote now */
                            inQuote = false;
                        }
                        else if (!inQuote)
                        {
                            quote = dtfi.LongTimePattern[i];
                            inQuote = true;
                        }
                        else
                        {
                            /* we were in a quote and saw the other type of quote character, so we are still in a quote */
                        }
                        break;
                    case '%':
                    case '\\':
                        i++; /* skip next character that is escaped by this backslash */
                        break;
                    default:
                        break;
                }
            }

            return foundZ ?
                dtfi.ShortDatePattern + " " + dtfi.LongTimePattern :
                dtfi.ShortDatePattern + " " + dtfi.LongTimePattern + " zzz";
        }
#endregion

        private static readonly Dictionary<(string ShortDatePattern, string ShortTimePattern), string> generalShortTimePatternCache = new Dictionary<(string, string), string>();

        private static string GetGeneralShortTimePatternCache(DateTimeFormatInfo dtfi)
        {
            var key = (dtfi.ShortDatePattern, dtfi.ShortTimePattern);
            if (!generalShortTimePatternCache.TryGetValue(key, out var value))
            {
                value = dtfi.ShortDatePattern + " " + dtfi.ShortTimePattern;
                generalShortTimePatternCache[key] = value;
            }
            return value;
        }
        
        private static readonly Dictionary<(string ShortDatePattern, string LongTimePattern), string> generalLongTimePattern = new Dictionary<(string, string), string>();

        private static string GetGeneralLongTimePatternCache(DateTimeFormatInfo dtfi)
        {
            var key = (dtfi.ShortDatePattern, dtfi.LongTimePattern);
            if (!generalLongTimePattern.TryGetValue(key, out var value))
            {
                value = dtfi.ShortDatePattern + " " + dtfi.LongTimePattern;
                generalLongTimePattern[key] = value;
            }
            return value;
        }
    }
}