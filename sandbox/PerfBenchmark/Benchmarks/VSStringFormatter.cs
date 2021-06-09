using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class VSStringFormatter
    {
        [Benchmark]
        public string ZStringConcatInt()
        {
            return ZString.Concat(1);
        }

        [Benchmark]
        public string ZStringBuilderInt()
        {
            using var builder = Cysharp.Text.ZString.CreateStringBuilder();
            builder.Append(1);
            return builder.ToString();
        }

        [Benchmark]
        public string StringFormatterInt()
        {
            var builder = new System.Text.Formatting.StringBuffer();
            builder.Append(1, System.Text.Formatting.StringView.Empty);
            return builder.ToString();
        }

        [Benchmark]
        public string BclStringBuilderInt()
        {
            var builder = new StringBuilder();
            builder.Append(1);
            return builder.ToString();
        }
    }
}
