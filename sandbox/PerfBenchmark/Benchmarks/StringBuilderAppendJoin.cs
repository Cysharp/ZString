using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Text;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class StringBuilderAppendJoin
    {
        double[] dValues;
        float[] fValues;
        decimal[] mValues;
        public StringBuilderAppendJoin()
        {
            dValues = new[] { 0d, double.MaxValue, double.MinValue };
            fValues = new[] { 0f, float.MaxValue, float.MinValue };
            mValues = new[] { 0m, decimal.MaxValue, decimal.MinValue };

#if NETCOREAPP || NETSTANDARD2_1
            if (StringBuilder() != ZStringBuilder())
                throw new Exception();
#endif
        }


#if NETCOREAPP || NETSTANDARD2_1
        [Benchmark(Baseline = true)]
        public int StringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append("double: ");
            sb.AppendJoin(", ", dValues);
            sb.AppendLine();
            sb.Append("float: ");
            sb.AppendJoin(", ", fValues);
            sb.AppendLine();
            sb.Append("decimal: ");
            sb.AppendJoin(", ", mValues);
            sb.AppendLine();
            return sb.Length;
        }
#endif

        [Benchmark]
        public int ZStringBuilder()
        {
            using var sb = ZString.CreateStringBuilder();
            sb.Append("double: ");
            sb.AppendJoin(", ", dValues);
            sb.AppendLine();
            sb.Append("float: ");
            sb.AppendJoin(", ", fValues);
            sb.AppendLine();
            sb.Append("decimal: ");
            sb.AppendJoin(", ", mValues);
            sb.AppendLine();
            return sb.Length;
        }
    }
}
