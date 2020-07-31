using Cysharp.Text;
using FluentAssertions;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class RemoveTest
    { 
        [Fact]
        public void RemovePart()
        {
            string str = "The quick brown fox jumps over the lazy dog.";
            using (var zsb = ZString.CreateStringBuilder())
            {
                zsb.Append(str);
                var bcl = new StringBuilder(str);

                // Remove "brown "
                zsb.Remove(10, 6);
                bcl.Remove(10, 6);

                zsb.ToString().Should().Be(bcl.ToString());
            }
        }

        [Fact]
        public void RemoveAll()
        {
            string str = "The quick brown fox jumps over the lazy dog.";
            using (var zsb = ZString.CreateStringBuilder())
            {
                zsb.Append(str);
                var bcl = new StringBuilder(str);

                zsb.Remove(0, str.Length);
                bcl.Remove(0, str.Length);

                zsb.ToString().Should().Be(bcl.ToString());
            }
        }

        [Fact]
        public void RemoveTail()
        {
            string str = "foo,bar,baz";
            using (var zsb = ZString.CreateStringBuilder())
            {
                zsb.Append(str);
                var bcl = new StringBuilder(str);

                zsb.Remove(7, 4);
                bcl.Remove(7, 4);

                zsb.ToString().Should().Be(bcl.ToString());
            }
        }
    }
}
