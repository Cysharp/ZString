using System;
using Cysharp.Text;
using FluentAssertions;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class AppendInterpolatedStringTest
    {
        [Fact]
        public void InterpolatedStringHandlerTest()
        {
            var zsb = ZString.CreateStringBuilder();
            var bcl = new StringBuilder();

            zsb.Append($"Const int{1}");
            bcl.Append($"Const int{1}");
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.Append($"Const int with format{1:0000}");
            bcl.Append($"Const int with format{1:0000}");
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.Append($"Const float with format{1f:0000}");
            bcl.Append($"Const float with format{1f:0000}");
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.Append($"Const double with format{1d:0000}");
            bcl.Append($"Const double with format{1d:0000}");
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.Append($"Const decimal with format{1m:0000}");
            bcl.Append($"Const decimal with format{1m:0000}");
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.Append($"Const long with format{1L:0000}");
            bcl.Append($"Const long with format{1L:0000}");
            zsb.ToString().Should().Be(bcl.ToString());

            var str = "str";
            zsb.Append($"Const string with pd10{str,10}");
            bcl.Append($"Const string with pd10{str,10}");
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.Append($"Const string with pd-10{str,-10}");
            bcl.Append($"Const string with pd-10{str,-10}");
            zsb.ToString().Should().Be(bcl.ToString());

            var guid = Guid.NewGuid();
            zsb.Insert(12, $"Some inserted {guid:N}");
            bcl.Insert(12, $"Some inserted {guid:N}");
            zsb.ToString().Should().Be(bcl.ToString());

            var datetime = DateTime.Now;
            zsb.Replace("long", $"Some inserted {datetime:yyyyMMddHHmmssfff}");
            bcl.Replace("long", $"Some inserted {datetime:yyyyMMddHHmmssfff}");
            zsb.ToString().Should().Be(bcl.ToString());
        }
    }
}
