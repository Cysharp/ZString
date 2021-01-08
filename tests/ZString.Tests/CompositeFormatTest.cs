using Cysharp.Text;
using FluentAssertions;
using System;
using System.Buffers;
using System.Text;
using Xunit;
using static FluentAssertions.FluentActions;

using static ZStringTests.FormatTest;
namespace ZStringTests
{
    public class CompositeFormatTest
    {
        [Theory]
        [InlineData("{1}")]
        [InlineData("{-0}")]
        [InlineData("{-1}")]
        [InlineData("}")]
        [InlineData("{")]
        [InlineData("{}")]
        [InlineData("{A}")]
        [InlineData("{1A}")]
        [InlineData("{0x0}")]
        [InlineData("{\uff11}")] // Full-Width One
        [InlineData("{ }")]
        [InlineData("{ 1}")]
        [InlineData("{0 0}")]
        [InlineData("{0+0}")]
        [InlineData("{0")]
        [InlineData("{foo")]
        [InlineData("{{0}")]
        [InlineData("{{{0")]
        [InlineData("0}")]
        [InlineData("bar}")]
        [InlineData("{0}}")]
        [InlineData("0}}}")]
        [InlineData("{:0}")]
        [InlineData("{0{}")]
        [InlineData("{0{1}}")]
        [InlineData("{,0}")]
        [InlineData("{ 0,0}")]
        [InlineData("{,-0}")]
        [InlineData("{0,-}")]
        [InlineData("{0,- 0}")]
        [InlineData("{0,--0}")]
        [InlineData("{:}")]
        [InlineData("{,:}")]
        [InlineData(" { , : } ")]
        [InlineData("{:,}")]
        [InlineData("{::}")]
        [InlineData("{,,}")]
        [InlineData(@"{\0}")]
        [InlineData(@"{0\,0}")]
        [InlineData(@"{0,0\:}")]
        [InlineData(@"{0:\}}")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<•Û—¯’†>")]
        public void IncorrectFormat(string format)
        {
            var value = 9999;
            var expected = CatchException(() => string.Format(format, value));
            var actual = CatchException(() => ZString.Format(format, value));

            expected.Should().NotBeNull(); // test miss!
            actual.Should().BeOfType(expected.GetType());

            Exception CatchException(Func<string> func)
            {
                try
                {
                    _ = func();
                    return null;
                }
                catch (Exception e)
                {
                    return e;
                }
            }
        }

        [Fact]
        public void AlignmentComponentInt()
        {
            Test("{1,-1}{0,1}", Int64.MinValue, Int64.MaxValue);
            Test("{0,1}{1,-1}", 1, 1);
            Test("{0,10}{1,-10}", 1, 1);
        }
        [Fact]
        public void AlignmentComponentString()
        {
            Test("{1,0}{0,0}", "right", "left");
            Test("{0,3}{1,-3}", "Foo", "Foo");
            Test("{0,4}{1,-4}", "Foo", "Foo");
        }
        [Fact]
        public void AlignmentComponent()
        {
            Test("{1,-" + 1000 + "}{0," + 1000 + "}", 
                "", Int64.MaxValue);
            var guid = Guid.NewGuid();
            Test(testUtf8: false, "{0,10:X}{{0}}{1,-10:c}", Guid.NewGuid(), DateTime.Now.TimeOfDay.Negate());

            string[] names = { "Adam", "Bridgette", "Carla", "Daniel", "Ebenezer", "Francine", "George" };
            decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80, 16.75m };

            for (int ctr = 0; ctr < names.Length; ctr++)
                Test("{0,-20} {1,5:F}", names[ctr], hours[ctr]);
        }


        [Fact]
        public void Spaces()
        {
            var format = "Prime numbers less than 10: {00 , 01 }, {01  ,02  }, {2 ,3 :D }, {3  ,4: X }";
            var expected = string.Format(format, 2, 3, 5, 7);
            var actual = ZString.Format(format, 2, 3, 5, 7);
            actual.Should().Be(expected);

        }

        [Fact]
        public void CompsiteFormats()
        {
            Test("{{Name = {0}, {1:f}({1:E})}}", "Fred", 500_0000_0000_0000m);
        }

    }
}