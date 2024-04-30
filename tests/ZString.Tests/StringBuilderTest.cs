using System;
using Cysharp.Text;
using FluentAssertions;
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

        [Theory]
        [InlineData("cucu", "mber")]
        [InlineData("Choco", "pie")]
        public void Append_WhenCalled_IsCorrect(string a, string b)
        {
            using var sut = ZString.CreateStringBuilder();
            sut.Append(a);
            sut.Append(b);
            
            var result = sut.ToString();
            result.Should().Be($"{a}{b}");
        }
        
        [Theory]
        [InlineData("cucu", "mber")]
        [InlineData("Choco", "pie")]
        public void Append_WhenChars_IsCorrect(string species, string b)
        {
            using var sut = ZString.CreateStringBuilder();
            sut.Append(species);
            var chars = new ReadOnlySpan<char>(b.ToCharArray());
            sut.Append(chars);
            
            var result = sut.ToString();
            result.Should().Be($"{species}{b}");
        }
        
        [Theory, InlineData("choco", "apple", "pie")]
        public void Replace_WhenCalled_IsCorrect(string species, string alternative, string mainPart)
        {
            using var sut = ZString.CreateStringBuilder();
            sut.Append(species);
            sut.Append(mainPart);
            sut.Replace(species, alternative);
            
            var result = sut.ToString();
            result.Should().Be($"{alternative}{mainPart}");
        }
        
        [Theory, InlineData("choco", "apple", "pie")]
        public void Insert_WhenCalled_IsCorrect(string species, string alternative, string mainPart)
        {
            using var sut = ZString.CreateStringBuilder();
            sut.Append(species);
            sut.Append(mainPart);
            sut.Insert(species.Length, alternative);
            
            var result = sut.ToString();
            result.Should().Be($"{species}{alternative}{mainPart}");
        }
        
        [Theory]
        [InlineData("cat")]
        [InlineData("dog")]
        public void IndexerAlike_WhenCalled_IsCorrect(string body)
        {
            using var sut = ZString.CreateStringBuilder();
            sut.Append(body);
            
            var letter = sut.AsSpan()[1];
            letter.Should().Be(body[1]);
        }
        
        [Theory]
        [InlineData("cat")]
        [InlineData("dog")]
        public void IndexerAlike_WhenCalledOnLast_IsCorrect(string body)
        {
            using var sut = ZString.CreateStringBuilder();
            sut.Append(body);

            var index = body.Length - 1;
            var letter = sut.AsSpan()[index];
            letter.Should().Be(body[index]);
        }
    }
}
