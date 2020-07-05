using Cysharp.Text;
using FluentAssertions;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class ReplaceTest
    {
        [Fact]
        public void ReplaceCharTest()
        {
            var s = new string(' ', 10);
            using (var zsb = ZString.CreateStringBuilder())
            {
                zsb.Append(s);
                zsb.Replace(' ', '-', 2, 5);
                zsb.ToString().Should().Be(new StringBuilder(s).Replace(' ', '-', 2, 5).ToString());
            }

            s = "0";
            using (var zsb = ZString.CreateStringBuilder())
            {
                zsb.Append(s);
                zsb.Replace('0', '1');
                zsb.ToString().Should().Be(new StringBuilder(s).Replace('0', '1').ToString());
            }
        }

        [Fact]
        public void ReplaceStringTest()
        {
            using (var zsb = ZString.CreateStringBuilder(notNested: true))
            {
                var text = "bra bra BRA bra bra";
                zsb.Append(text);
                var bcl = new StringBuilder(text);
                
                zsb.Replace("bra", null, 1, text.Length - 2);
                bcl.Replace("bra", null, 1, text.Length - 2);

                //  "bra BRA bra"
                zsb.ToString().Should().Be(bcl.ToString());
            }

            using (var zsb = ZString.CreateStringBuilder(notNested: true))
            {
                var text = "num num num";
                zsb.Append(text);
                var bcl = new StringBuilder(text);

                // over DefaultBufferSize
                zsb.Replace("num", new string('1', 32768), 1, text.Length - 2);
                bcl.Replace("num", new string('1', 32768), 1, text.Length - 2);

                zsb.ToString().Should().Be(bcl.ToString());
            }

            using (var zsb = ZString.CreateStringBuilder())
            {
                var text = "The quick brown dog jumps over the lazy cat.";
                zsb.Append(text);
                var bcl = new StringBuilder(text);

                // All "cat" -> "dog"
                zsb.Replace("cat", "dog");
                bcl.Replace("cat", "dog");
                zsb.ToString().Should().Be(bcl.ToString());

                // Some "dog" -> "fox"
                zsb.Replace("dog", "fox", 15, 20);
                bcl.Replace("dog", "fox", 15, 20);
                zsb.ToString().Should().Be(bcl.ToString());
            }
        }
        
        [Fact]
        public void NotMatchTest()
        {
            using (var zsb = ZString.CreateStringBuilder(notNested: true))
            {
                var text = "The quick brown dog jumps over the lazy cat.";
                zsb.Append(text);
                zsb.Replace("pig", "dog");
                zsb.ToString().Should().Be(text);
            }
        }
    }
}
