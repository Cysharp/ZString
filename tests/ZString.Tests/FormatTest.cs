using Cysharp.Text;
using FluentAssertions;
using System;
using System.Buffers;
using System.Numerics;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class FormatTest
    {
        void Test<T0, T1>(string format, T0 t0, T1 t1)
        {
            {
                var actual = ZString.Format(format, t0, t1);
                var expected = string.Format(format, t0, t1);
                actual.Should().Be(expected);
            }
            {
                var sb = ZString.CreateUtf8StringBuilder();
                sb.AppendFormat(format, t0, t1);
                var actual = sb.ToString();
                var expected = string.Format(format, t0, t1);
                actual.Should().Be(expected);
            }

            // Prepare
            {
                var actual = ZString.PrepareUtf16<T0, T1>(format).Format(t0, t1);
                var expected = string.Format(format, t0, t1);
                actual.Should().Be(expected);
            }
            {
                var sb = ZString.PrepareUtf8<T0, T1>(format);
                var actual = sb.Format(t0, t1);
                var expected = string.Format(format, t0, t1);
                actual.Should().Be(expected);
            }

            // Direct
            {
#if NETCOREAPP3_1
                var writer = new ArrayBufferWriter<byte>();
                ZString.Utf8Format(writer, format, t0, t1);
                var actual = Encoding.UTF8.GetString(writer.WrittenSpan);
                var expected = string.Format(format, t0, t1);
                actual.Should().Be(expected);
#endif
            }
        }

        [Fact]
        public void EmptyFormat()
        {
            Test("", 100, 200);
        }

        [Fact]
        public void NoFormat()
        {
            Test("abcdefg", 100, 200);
        }

        [Fact]
        public void SingleFormat()
        {
            Test("{0}", 100, 200);
        }

        [Fact]
        public void DoubleFormat()
        {
            Test("{0}{1}", 100, 200);
        }

        [Fact]
        public void DoubleFormat2()
        {
            Test("abc{0}def{1}", 100, 200);
        }

        [Fact]
        public void DoubleFormat3()
        {
            Test("abc{0}def{1}ghi", 100, 200);
        }

        [Fact]
        public void Nullable()
        {
            Test("abc{0}def{1}ghi", (int?)100, (int?)1);
            Test("abc{0:X}def{1:X}ghi", (int?)100, (int?)1);
            Test("abc{0}def{1}ghi", (Guid?)Guid.NewGuid(), (Guid?)null);
            Test("abc{0:e}def{1:e}ghi", (double?)Math.PI, (double?)null);
        }

        [Fact]
        public void Comment()
        {
            Test("abc{{0}}def{1}ghi", 100, 200);
        }

        [Fact]
        public void FormatArgs()
        {
            ZString.Format("{0:00000000}-{1:00000000}", 100, 200).Should().Be("00000100-00000200");
        }

        [Fact]
        public void FormatIntPtr()
        {
            // IntPtr/UIntPtr ignores format
            Test("abc{0}def{1:X}", new IntPtr(int.MinValue), new IntPtr(int.MaxValue));
            Test("abc{0}def{1:X}", new UIntPtr(uint.MinValue), new UIntPtr(uint.MaxValue));
            if (IntPtr.Size == 8)
            {
                Test("abc{0}def{1:X}", new IntPtr(long.MinValue), new IntPtr(long.MaxValue));
                Test("abc{0}def{1:X}", new UIntPtr(ulong.MinValue), new UIntPtr(ulong.MaxValue));
            }
        }

        [Fact]
        public void FormattableObject()
        {
            Test("abc{0:}def{1:F3}", (object)default(Vector2), (object)new Vector2(MathF.PI));
            Test("abc{0:E0}def{1:N}", (object)new Vector3(float.MinValue, float.NaN, float.MaxValue),
                (object)new Vector3(MathF.PI));
        }

        [Fact]
        public void Escape()
        {
            TimeSpan span = new TimeSpan(12, 34, 56);
            var reference = string.Format(@"{0:h\,h\:mm\:ss}", span);

            var actual = ZString.Format(@"{0:h\,h\:mm\:ss}", span);
            actual.Should().Be(reference);
        }

        [Fact]
        public void Unicode()
        {
            Test("\u30cf\u30fc\u30c8: {0}, \u5bb6\u65cf: {1}(\u7d75\u6587\u5b57)", "\u2764", "\uD83D\uDC69\u200D\uD83D\uDC69\u200D\uD83D\uDC67\u200D\uD83D\uDC67");
        }
    }
}