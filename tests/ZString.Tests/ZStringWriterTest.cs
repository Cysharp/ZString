using System;
using Cysharp.Text;
using Xunit;

namespace ZStringTests
{
    public class ZStringWriterTest
    {
        [Fact]
        public void DoubleDisposeTest()
        {
            var sb = new ZStringWriter();
            sb.Dispose();
            sb.Dispose(); // call more than once
        }

        [Fact]
        public void BasicWrites()
        {
            using (var writer = new ZStringWriter())
            {
                writer.Write("text1".AsSpan());
                writer.Write("text2");
                writer.Write('c');
                writer.Write(true);
                writer.Write(123);
                writer.Write(456f);
                writer.Write(789d);
                writer.Write("end".AsMemory());
                writer.WriteLine();

                var expected = "text1text2cTrue123456789end" + Environment.NewLine;
                Assert.Equal(expected, writer.ToString());
            }
        }
    }
}