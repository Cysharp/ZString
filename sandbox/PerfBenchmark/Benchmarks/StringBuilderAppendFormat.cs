using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Text;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class StringBuilderAppendFormat
    {
        double[] dValues;
        float[] fValues;
        decimal[] mValues;
        public StringBuilderAppendFormat()
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
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "double", dValues[0], dValues[1], dValues[2], 1);
            sb.AppendLine();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "float", fValues[0], fValues[1], fValues[2], 2);
            sb.AppendLine();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "decimal", mValues[0], mValues[1], mValues[2], 3);
            sb.AppendLine();
            return sb.Length;
        }
#endif

        [Benchmark]
        public int ZStringBuilder()
        {
            using var sb = ZString.CreateStringBuilder();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "double", dValues[0], dValues[1], dValues[2], 1);
            sb.AppendLine();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "float", fValues[0], fValues[1], fValues[2], 2);
            sb.AppendLine();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "decimal", mValues[0], mValues[1], mValues[2], 3);
            sb.AppendLine();
            return sb.Length;
        }

        [Benchmark]
        public int ZStringBuilderUtf8()
        {
            using var sb = ZString.CreateUtf8StringBuilder();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "double", dValues[0], dValues[1], dValues[2], 1);
            sb.AppendLine();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "float", fValues[0], fValues[1], fValues[2], 2);
            sb.AppendLine();
            sb.AppendFormat("{{ {0}: {1}, {2}, {3} }} - {4}", "decimal", mValues[0], mValues[1], mValues[2], 3);
            sb.AppendLine();
            return sb.Length;
        }
    }
}
