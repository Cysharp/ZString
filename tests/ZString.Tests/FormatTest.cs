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
            {
                var actual = ZString.Format(format, t0, t1);
                var expected = string.Format(format, t0, t1);
                actual.Should().Be(expected);
            }
            {
                var sb = ZString.CreateUtf8StringBuilder();
                sb.AppendFormat(format, t0, t1);
                var actual = sb.ToString();
                var expected = string.Format(format, t0, t1);
                actual.Should().Be(expected);
            }
        }

        [Fact]
        public void EmptyFormat()
        {
            Test("", 100, 200);
        }

        [Fact]
        public void NoFormat()
        {
            Test("abcdefg", 100, 200);
        }

        [Fact]
        public void SingleFormat()
        {
            Test("{0}", 100, 200);
        }

        [Fact]
        public void DoubleFormat()
        {
            Test("{0}{1}", 100, 200);
        }

        [Fact]
        public void DoubleFormat2()
        {
            Test("abc{0}def{1}", 100, 200);
        }

        [Fact]
        public void DoubleFormat3()
        {
            Test("abc{0}def{1}ghi", 100, 200);
        }

        [Fact]
        public void Comment()
        {
            Test("abc{{0}}def{1}ghi", 100, 200);
        }

        [Fact]
        public void FormatArgs()
        {
            ZString.Format("{0:00000000}-{1:00000000}", 100, 200).Should().Be("00000100-00000200");
        }
    }
}