using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Text;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class SixObjectConcatBenchmark
    {
        int x;
        int y;
        int z;

        public SixObjectConcatBenchmark()
        {
            x = int.Parse("333");
            y = int.Parse("444");
            z = int.Parse("555");
        }

        [Benchmark(Baseline = true)]
        public string StringPlus()
        {
            return "x:" + x + " y:" + y + " z:" + z;
        }

        [Benchmark]
        public string ZStringConcat()
        {
            return ZString.Concat("x:", x, " y:", y, " z:", z);
        }

        [Benchmark]
        public string StringFormat()
        {
            return string.Format("x:{0} y:{1} z:{2}", x, y, z);
        }

        [Benchmark]
        public string ZStringFormat()
        {
            return ZString.Format("x:{0} y:{1} z:{2}", x, y, z);
        }

        [Benchmark]
        public string StringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append("x:");
            sb.Append(x);
            sb.Append(" y:");
            sb.Append(y);
            sb.Append(" z:");
            sb.Append(z);
            return sb.ToString();
        }

        [Benchmark]
        public string ZStringBuilder()
        {
            using var sb = ZString.CreateStringBuilder();
            sb.Append("x:");
            sb.Append(x);
            sb.Append(" y:");
            sb.Append(y);
            sb.Append(" z:");
            sb.Append(z);
            return sb.ToString();
        }
    }
}
