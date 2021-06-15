using Cysharp.Text;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ZStringTests
{
    //In .NET Standard 2.0, embedded Formatter is used.
    public class DateTimeFormatTest
    {
        public static IEnumerable<object[]> DateTimeData()
        {
            yield return new object[] { default(DateTime) };
            yield return new object[] { DateTime.MinValue };
            yield return new object[] { DateTime.MaxValue };
            yield return new object[] { DateTime.UnixEpoch };
            yield return new object[] { new DateTime(1999,12,31,12,34,59, DateTimeKind.Utc) };
            yield return new object[] { new DateTime(1999,12,31, 12,34,59, DateTimeKind.Local) };
            yield return new object[] { new DateTime(1999,12,31,12,34,59, DateTimeKind.Unspecified) };
        }

        [Theory]
        [MemberData(nameof(DateTimeData))]
        public void DateTimeFormat(DateTime x)
        {
            ZString.Format("{0}",x).Should().Be(string.Format("{0}", x)); // fallback
            ZString.Format("{0:r}",x).Should().Be(string.Format("{0:r}", x));
            ZString.Format("{0:R}",x).Should().Be(string.Format("{0:R}", x));
            ZString.Format("{0:o}",x).Should().Be(string.Format("{0:o}", x));
            ZString.Format("{0:O}",x).Should().Be(string.Format("{0:O}", x));
            ZString.Format("{0:g}",x).Should().Be(string.Format("{0:g}", x)); // fallback
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
            ZString.Format("{0:r}",x).Should().Be(string.Format("{0:r}", x));
            ZString.Format("{0:R}",x).Should().Be(string.Format("{0:R}", x));
            ZString.Format("{0:o}",x).Should().Be(string.Format("{0:o}", x));
            ZString.Format("{0:O}",x).Should().Be(string.Format("{0:O}", x));
            ZString.Format("{0:g}",x).Should().Be(string.Format("{0:g}", x)); // fallback
        }
    }

    //In .NET Standard 2.0, embedded Formatter is used.
    public class TimeSpanFormatTest
    {
        public static IEnumerable<object[]> TimeSpanData()
        {
            yield return new object[] { default(TimeSpan) };
            yield return new object[] { TimeSpan.MinValue };
            yield return new object[] { TimeSpan.MaxValue };
            yield return new object[] { DateTime.Now.TimeOfDay };
        }

        [Theory]
        [MemberData(nameof(TimeSpanData))]
        public void TimeSpanFormat(TimeSpan x)
        {
            ZString.Format("{0}", x).Should().Be(string.Format("{0}", x));
            ZString.Format("{0:c}",x).Should().Be(string.Format("{0:c}", x));
            ZString.Format("{0:t}",x).Should().Be(string.Format("{0:t}", x));
            ZString.Format("{0:T}",x).Should().Be(string.Format("{0:T}", x));
            ZString.Format("{0:g}",x).Should().Be(string.Format("{0:g}", x));  // fallback
        }
    }

}
