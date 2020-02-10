using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System.Text;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class FourObjectConcatBenchmark
    {
        int x;
        int y;

        public FourObjectConcatBenchmark()
        {
            x = int.Parse("100");
            y = int.Parse("200");
        }

        [Benchmark]
        public string StringPlus()
        {
            return "x:" + x + ", y:" + y;
        }

        [Benchmark]
        public string StringConcatObject()
        {
            return string.Concat("x:", x, ", y:", y);
        }

        [Benchmark]
        public string ZStringConcat()
        {
            return ZString.Concat("x:", x, ", y:", y);
        }

        [Benchmark]
        public string StringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append("x:");
            sb.Append(x);
            sb.Append(", y:");
            sb.Append(y);
            return sb.ToString();
        }

        [Benchmark]
        public string ZStringBuilder()
        {
            using var sb = ZString.CreateStringBuilder();
            sb.Append("x:");
            sb.Append(x);
            sb.Append(", y:");
            sb.Append(y);
            return sb.ToString();
        }

        [Benchmark]
        public string ZStringBuilder2()
        {
            using var sb = ZString.CreateStringBuilder(true);
            sb.Append("x:");
            sb.Append(x);
            sb.Append(", y:");
            sb.Append(y);
            return sb.ToString();
        }
    }
}
