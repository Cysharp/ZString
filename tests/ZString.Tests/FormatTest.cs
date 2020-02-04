using Cysharp.Text;
using FluentAssertions;
using System;
using Xunit;

namespace ZStringTests
{
    public class FormatTest
    {
        void Test<T0, T1>(string format, T0 t0, T1 t1)
        {
            var actual = ZString.Format(format, t0, t1);
            var expected = string.Format(format, t0, t1);
            actual.Should().Be(expected);
        }

        [Fact]
        public void EmptyFormat()
        {
            Test("", 100, 200);
        }
    }
}