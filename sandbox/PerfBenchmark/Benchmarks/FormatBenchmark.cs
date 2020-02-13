using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Formatting;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class FormatBenchmark
    {
        int x;
        int y;
        string format;
        StringBuilder stringBuilder;

        public FormatBenchmark()
        {
            x = int.Parse("100");
            y = int.Parse("200");
            format = "x:{0}, y:{1}";
            stringBuilder = new StringBuilder();
        }

        [Benchmark]
        public string StringFormat()
        {
            return string.Format(format, x, y);
        }

        [Benchmark]
        public string ZStringFormat()
        {
            return ZString.Format(format, x, y);
        }

        [Benchmark]
        public string StringFormatterFormat()
        {
            return StringBuffer.Format(format, x, y);
        }
    }
}
