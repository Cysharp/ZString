using Cysharp.Text;
using FluentAssertions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class Utf8StringBuilderTest
    {

        [Fact]
        public void AppendCharRepeat()
        {
            using (var zsb = ZString.CreateUtf8StringBuilder(notNested: true))
            {
                var text = "foo";
                zsb.Append(text);
                var bcl = new StringBuilder(text);

                // ASCII
                zsb.Append('\x7F', 10);
                bcl.Append('\x7F', 10);
                zsb.ToString().Should().Be(bcl.ToString());

                // Non-ASCII
                zsb.Append('\x80', 10);
                bcl.Append('\x80', 10);
                zsb.ToString().Should().Be(bcl.ToString());

                zsb.Append('\u9bd6', 10);
                bcl.Append('\u9bd6', 10);
                zsb.ToString().Should().Be(bcl.ToString());
            }

        }
    }
}
