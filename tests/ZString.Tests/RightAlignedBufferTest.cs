using Cysharp.Text;
using FluentAssertions;
using System;
using System.Buffers;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class RightAlignedBufferTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void PreparedUtf16UsesOnlyFormattedCharacters(int value)
        {
            var writer = new ArrayBufferWriter<char>(1);
            ZString.PrepareUtf16<int>("{0,2}").FormatTo(ref writer, value);
            new string(writer.WrittenSpan).Should().Be(string.Format("{0,2}", value));
        }

        [Theory]
        [InlineData(false, 1)]
        [InlineData(false, 100)]
        [InlineData(true, 1)]
        [InlineData(true, 100)]
        public void Utf8UsesOnlyFormattedBytes(bool prepared, int value)
        {
            var writer = new ArrayBufferWriter<byte>(1);
            if (prepared)
            {
                ZString.PrepareUtf8<int>("{0,2}").FormatTo(ref writer, value);
            }
            else
            {
                ZString.Utf8Format(writer, "{0,2}", value);
            }
            Encoding.UTF8.GetString(writer.WrittenSpan).Should().Be(string.Format("{0,2}", value));
        }

        [Fact]
        public void Utf8BuilderUsesOnlyFormattedBytesNearCapacity()
        {
            using (var builder = ZString.CreateUtf8StringBuilder())
            {
                var prefix = new string('x', builder.GetSpan(0).Length - 2);
                builder.Append(prefix);
                builder.AppendFormat("{0,1}", 1);
                builder.ToString().Should().Be(prefix + "1");
            }
        }
    }
}
