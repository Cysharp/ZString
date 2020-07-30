using Cysharp.Text;
using FluentAssertions;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class InsertTest
    {
        [Fact]
        public void InsertStringTest()
        { 
            string initialValue = "--[]--";

            using (var zsb = ZString.CreateStringBuilder(notNested: true))
            {
                string xyz = "xyz";

                zsb.Append(initialValue);
                var bcl = new StringBuilder(initialValue);

                zsb.Insert(3, xyz, 2);
                bcl.Insert(3, xyz, 2);
                zsb.ToString().Should().Be(bcl.ToString());

                zsb.Insert(3, xyz);
                bcl.Insert(3, xyz);
                zsb.ToString().Should().Be(bcl.ToString());

                zsb.Insert(0, "<<");
                bcl.Insert(0, "<<");
                zsb.ToString().Should().Be(bcl.ToString());

                var endIndex = zsb.Length - 1;
                zsb.Insert(endIndex, ">>");
                bcl.Insert(endIndex, ">>");
                zsb.ToString().Should().Be(bcl.ToString());
            }
        }

        [Fact]
        public void InsertLargeStringTest()
        {
            string initialValue = "--[]--";

            using (var zsb = ZString.CreateStringBuilder(notNested: true))
            {
                string text = new string('X', 32768);

                zsb.Append(initialValue);
                var bcl = new StringBuilder(initialValue);

                zsb.Insert(3, text);
                bcl.Insert(3, text);
                zsb.ToString().Should().Be(bcl.ToString());
            }
        }

        [Fact]
        public void NotInserted()
        {
            using (var zsb = ZString.CreateStringBuilder(notNested: true))
            {
                var text = "The quick brown dog jumps over the lazy cat.";
                zsb.Append(text);
                zsb.Insert( 10, "");
                zsb.ToString().Should().Be(text);
            }
        }
    }
}
