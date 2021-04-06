using Cysharp.Text;
using FluentAssertions;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class StringBuilderTest
    {
        [Fact]
        public void Utf16DisposeTest()
        {
            var sb = ZString.CreateStringBuilder();
            sb.Dispose();
            sb.Dispose(); // call more than once
        }

        [Fact]
        public void Utf8DisposeTest()
        {
            var sb = ZString.CreateUtf8StringBuilder();
            sb.Dispose();
            sb.Dispose(); // call more than once
        }
    }
}
