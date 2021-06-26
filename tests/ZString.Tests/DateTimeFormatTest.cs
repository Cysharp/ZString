using Cysharp.Text;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;

namespace ZStringTests
{
    //In .NET Standard 2.0, embedded Formatter is used.
    public class DateTimeFormatTest
    {

#if !NETCOREAPP3_0_OR_GREATER

        public static IEnumerable<object[]> GetDateTimeFormatAndCultures()
        {
            string[] formats = {
                // Standard date and time format strings
                "d", "D", "f", "F", "g", "G", "M", "m", "O", "o", "R", "r", "s", "t", "T", "u", "Y", "y",
                // Custom date and time format strings
                "d dd ddd dddd f fffffff F FFFFFFF g gg h hh H HH K m mm M MM MMM MMMM s ss t tt y yy yyyy z zz zzz ",
            };
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            return cultures.SelectMany(_ => formats, (culture, format) => (new object[] { culture, format }));
        }

        [Theory]
        [MemberData(nameof(GetDateTimeFormatAndCultures))]
        public void CultureTest(CultureInfo culture, string format)
        {
            var oldculture = System.Threading.Thread.CurrentThread.CurrentCulture;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                format = "{0:" + format + "}";

                {
                    var utc = new DateTime(2021, 12, 31, 12, 34, 59, DateTimeKind.Utc);
                    ZString.Format(format, utc).Should().Be(string.Format(format, utc));
                    var local = new DateTime(2021, 12, 31, 12, 34, 59, DateTimeKind.Local);
                    ZString.Format(format, local).Should().Be(string.Format(format, local));
                }

                // The "U" format specifier is not supported by the DateTimeOffset type and throws a FormatException if it is used to format a DateTimeOffset value.
                if (format != "U")
                {
                    var utc = new DateTimeOffset(2021, 12, 31, 12, 34, 59, TimeSpan.Zero);
                    ZString.Format(format, utc).Should().Be(string.Format(format, utc));
                    var local = new DateTimeOffset(2021, 12, 31, 12, 34, 59, TimeSpan.FromHours(-12));
                    ZString.Format(format, local).Should().Be(string.Format(format, local));
                }
            }
            finally
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = oldculture;
            }
        }

#endif


        public static IEnumerable<object[]> DateTimeData()
        {
            yield return new object[] { default(DateTime) };
            yield return new object[] { DateTime.MinValue };
            yield return new object[] { DateTime.MaxValue };
            yield return new object[] { DateTime.UnixEpoch };
            yield return new object[] { new DateTime(1999, 12, 31, 12, 34, 59, DateTimeKind.Utc) };
            yield return new object[] { new DateTime(1999, 12, 31, 12, 34, 59, DateTimeKind.Local) };
            yield return new object[] { new DateTime(1999, 12, 31, 12, 34, 59, DateTimeKind.Unspecified) };
        }

        [Theory]
        [MemberData(nameof(DateTimeData))]
        public void DateTimeFormat(DateTime x)
        {
            ZString.Format("{0}", x).Should().Be(string.Format("{0}", x)); // fallback
            ZString.Format("{0:r}", x).Should().Be(string.Format("{0:r}", x));
            ZString.Format("{0:R}", x).Should().Be(string.Format("{0:R}", x));
            ZString.Format("{0:o}", x).Should().Be(string.Format("{0:o}", x));
            ZString.Format("{0:O}", x).Should().Be(string.Format("{0:O}", x));
            ZString.Format("{0:g}", x).Should().Be(string.Format("{0:g}", x)); // fallback
        }

        public static IEnumerable<object[]> DateTimeOffsetData()
        {
            yield return new object[] { default(DateTimeOffset) };
            yield return new object[] { DateTimeOffset.MinValue };
            yield return new object[] { DateTimeOffset.MaxValue };
            yield return new object[] { DateTimeOffset.UnixEpoch };
            yield return new object[] { DateTimeOffset.UtcNow };
            yield return new object[] { new DateTimeOffset(1999, 12, 31, 12, 34, 59, TimeSpan.FromHours(-12)) };
        }

        [Theory]
        [MemberData(nameof(DateTimeOffsetData))]
        public void DateTimeOffsetFormat(DateTimeOffset x)
        {
            ZString.Format("{0}", x).Should().Be(string.Format("{0}", x)); // fallback
            ZString.Format("{0:r}", x).Should().Be(string.Format("{0:r}", x));
            ZString.Format("{0:R}", x).Should().Be(string.Format("{0:R}", x));
            ZString.Format("{0:o}", x).Should().Be(string.Format("{0:o}", x));
            ZString.Format("{0:O}", x).Should().Be(string.Format("{0:O}", x));
            ZString.Format("{0:g}", x).Should().Be(string.Format("{0:g}", x)); // fallback
        }
    }
}
