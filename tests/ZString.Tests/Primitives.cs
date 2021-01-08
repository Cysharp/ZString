using Cysharp.Text;
using FluentAssertions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public enum MoreMyEnum
    {
        Fruit, Apple, Orange
    }

    public class Primitives
    {
        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(0, -1)]
        [InlineData(-1, 1)]
        [InlineData(-12, 12)]
        [InlineData(-123, 123)]
        [InlineData(-1234, 1234)]
        [InlineData(-12345, 12345)]
        [InlineData(-123456, 123456)]
        [InlineData(-1234567, 1234567)]
        [InlineData(-12345678, 12345678)]
        [InlineData(-123456789, 123456789)]
        [InlineData(-1234567890, 1234567890)]
        public void Integer(int x, int y)
        {
            using (var sb1 = ZString.CreateStringBuilder())
            using (var sb2 = ZString.CreateUtf8StringBuilder())
            using (var sb3 = ZString.CreateStringBuilder())
            using (var sb4 = ZString.CreateUtf8StringBuilder())
            {
                var sb5 = new StringBuilder();
                sb1.Append(x); sb1.Append(y);
                sb2.Append(x); sb2.Append(y);
                sb3.Append(x); sb3.Append(y);
                sb4.Append(x); sb4.Append(y);
                sb5.Append(x); sb5.Append(y);

                sb1.ToString().Should().Be(sb2.ToString());
                sb1.ToString().Should().Be(sb3.ToString());
                sb1.ToString().Should().Be(sb4.ToString());
                sb1.ToString().Should().Be(sb5.ToString());
            }
        }

        [Theory]
        [InlineData(ulong.MinValue, ulong.MinValue)]
        [InlineData(0UL, 1UL)]
        [InlineData(1UL, 1UL)]
        [InlineData(12UL, 12UL)]
        [InlineData(123UL, 123UL)]
        [InlineData(1234UL, 1234UL)]
        [InlineData(12345UL, 12345UL)]
        [InlineData(123456UL, 123456UL)]
        [InlineData(1234567UL, 1234567UL)]
        [InlineData(12345678UL, 12345678UL)]
        [InlineData(123456789UL, 123456789UL)]
        [InlineData(1234567890UL, 1234567890UL)]
        [InlineData(12345678901UL, 12345678901UL)]
        [InlineData(123456789012UL, 123456789012UL)]
        public void UInt64(ulong x, ulong y)
        {
            using (var sb1 = ZString.CreateStringBuilder())
            using (var sb2 = ZString.CreateUtf8StringBuilder())
            using (var sb3 = ZString.CreateStringBuilder())
            using (var sb4 = ZString.CreateUtf8StringBuilder())
            {
                var sb5 = new StringBuilder();
                sb1.Append(x); sb1.Append(y);
                sb2.Append(x); sb2.Append(y);
                sb3.Append(x); sb3.Append(y);
                sb4.Append(x); sb4.Append(y);
                sb5.Append(x); sb5.Append(y);

                sb1.ToString().Should().Be(sb2.ToString());
                sb1.ToString().Should().Be(sb3.ToString());
                sb1.ToString().Should().Be(sb4.ToString());
                sb1.ToString().Should().Be(sb5.ToString());
            }
        }

        [Theory]
        //[InlineData(double.MinValue, double.MinValue)]
        //[InlineData(double.Epsilon, double.NaN)]
        [InlineData(0.1, -0.1)]
        [InlineData(0.0, 0.0)]
        [InlineData(0.12, 0.12)]
        [InlineData(0.123, 0.123)]
        [InlineData(0.1234, 0.1234)]
        [InlineData(0.12345, 0.12345)]
        [InlineData(1.12345, 1.12345)]
        [InlineData(12.12345, 12.12345)]
        [InlineData(123.12345, 123.12345)]
        [InlineData(1234.12345, 1234.12345)]
        [InlineData(12345.12345, 12345.12345)]
        [InlineData(1234512345d, 1234512345d)]
        public void Double(double x, double y)
        {
            using (var sb1 = ZString.CreateStringBuilder())
            using (var sb2 = ZString.CreateUtf8StringBuilder())
            using (var sb3 = ZString.CreateStringBuilder())
            using (var sb4 = ZString.CreateUtf8StringBuilder())
            {
                var sb5 = new StringBuilder();
                sb1.Append(x); sb1.Append(y);
                sb2.Append(x); sb2.Append(y);
                sb3.Append(x); sb3.Append(y);
                sb4.Append(x); sb4.Append(y);
                sb5.Append(x); sb5.Append(y);

                sb1.ToString().Should().Be(sb2.ToString());
                sb1.ToString().Should().Be(sb3.ToString());
                sb1.ToString().Should().Be(sb4.ToString());
                sb1.ToString().Should().Be(sb5.ToString());
            }
        }

        [Theory]
        //[InlineData(double.MinValue, double.MinValue)]
        //[InlineData(double.Epsilon, double.NaN)]
        [InlineData(0.1f, -0.1f)]
        [InlineData(0.0f, 0.0f)]
        [InlineData(0.12f, 0.12f)]
        [InlineData(0.123f, 0.123f)]
        [InlineData(0.1234f, 0.1234f)]
        [InlineData(0.12345f, 0.12345f)]
        [InlineData(1.12345f, 1.12345f)]
        [InlineData(12.12345f, 12.12345f)]
        [InlineData(123.123f, 123.123f)]
        public void Single(float x, float y)
        {
            using (var sb1 = ZString.CreateStringBuilder())
            using (var sb2 = ZString.CreateUtf8StringBuilder())
            using (var sb3 = ZString.CreateStringBuilder())
            using (var sb4 = ZString.CreateUtf8StringBuilder())
            {
                var sb5 = new StringBuilder();
                sb1.Append(x); sb1.Append(y);
                sb2.Append(x); sb2.Append(y);
                sb3.Append(x); sb3.Append(y);
                sb4.Append(x); sb4.Append(y);
                sb5.Append(x); sb5.Append(y);

                sb1.ToString().Should().Be(sb2.ToString());
                sb1.ToString().Should().Be(sb3.ToString());
                sb1.ToString().Should().Be(sb4.ToString());
                sb1.ToString().Should().Be(sb5.ToString());
            }
        }

        [Fact]
        public void Others()
        {
            using (var sb1 = ZString.CreateStringBuilder())
            //using (var sb2 = ZString.CreateUtf8StringBuilder())
            using (var sb3 = ZString.CreateStringBuilder())
            //using (var sb4 = ZString.CreateUtf8StringBuilder())
            {
                var x = DateTime.Now;
                var y = DateTimeOffset.Now;
                var z = TimeSpan.FromMilliseconds(12345.6789);
                var g = Guid.NewGuid();

                var sb5 = new StringBuilder();
                sb1.Append(x); sb1.Append(y); sb1.Append(z); sb1.Append(g);
                //sb2.Append(x, StandardFormat.Parse("O")); sb2.Append(y, StandardFormat.Parse("O")); sb2.Append(z); sb2.Append(g);
                sb3.Append(x); sb3.Append(y); sb3.Append(z); sb3.Append(g);
                //sb4.Concat(x, y, z, g);
                sb5.Append(x); sb5.Append(y); sb5.Append(z); sb5.Append(g);

                //sb1.ToString().Should().Be(sb2.ToString());
                sb1.ToString().Should().Be(sb3.ToString());
                //sb1.ToString().Should().Be(sb4.ToString());
                sb1.ToString().Should().Be(sb5.ToString());
            }
        }

        [Fact]
        public void EnumTest()
        {
            var x = MoreMyEnum.Apple;
            var y = MoreMyEnum.Orange;

            using (var sb1 = ZString.CreateStringBuilder())
            using (var sb2 = ZString.CreateUtf8StringBuilder())
            using (var sb3 = ZString.CreateStringBuilder())
            using (var sb4 = ZString.CreateUtf8StringBuilder())
            {
                var sb5 = new StringBuilder();
                sb1.Append(x); sb1.Append(y);
                sb2.Append(x); sb2.Append(y);
                sb3.Append(x); sb3.Append(y);
                sb4.Append(x); sb4.Append(y);
                sb5.Append(x); sb5.Append(y);

                sb1.ToString().Should().Be(sb2.ToString());
                sb1.ToString().Should().Be(sb3.ToString());
                sb1.ToString().Should().Be(sb4.ToString());
                sb1.ToString().Should().Be(sb5.ToString());
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BoolTest(bool x)
        {
            using (var sb1 = ZString.CreateStringBuilder())
            using (var sb2 = ZString.CreateUtf8StringBuilder())
            using (var sb3 = ZString.CreateStringBuilder())
            using (var sb4 = ZString.CreateUtf8StringBuilder())
            {
                var sb5 = new StringBuilder();
                sb1.Append(x);
                sb2.Append(x);
                sb3.Append(x);
                sb4.Append(x);
                sb5.Append(x);

                sb1.ToString().Should().Be(sb2.ToString());
                sb1.ToString().Should().Be(sb3.ToString());
                sb1.ToString().Should().Be(sb4.ToString());
                sb1.ToString().Should().Be(sb5.ToString());
            }
        }
    }
}
