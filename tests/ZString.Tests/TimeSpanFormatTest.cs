using Cysharp.Text;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ZStringTests
{
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
