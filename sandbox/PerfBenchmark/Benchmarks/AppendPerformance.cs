using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class AppendPerformance
    {
        List<string> strings;
        const int COUNT = 1000;

        public AppendPerformance()
        {
            strings = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                strings.Add("123456789");
            }
        }

        [Benchmark]
        public void ZStringUtf16()
        {
            for (int i = 0; i < COUNT; i++)
            {
                using (var sb = ZString.CreateStringBuilder())
                {
                    for (int j = 0; j < strings.Count; j++)
                    {
                        sb.Append(strings[j]);
                    }

                    _ = sb.ToString();
                }
            }
        }

        //[Benchmark]
        //public void ZStringUtf16SpanBased()
        //{
        //    for (int i = 0; i < COUNT; i++)
        //    {
        //        using (var sb = ZString.CreateStringBuilder())
        //        {
        //            for (int j = 0; j < strings.Count; j++)
        //            {
        //                sb.AppendSlow(strings[j]);
        //            }

        //            _ = sb.ToString();
        //        }
        //    }
        //}

        [Benchmark(Baseline = true)]
        public void StringBuilder()
        {
            for (int i = 0; i < COUNT; i++)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int j = 0; j < strings.Count; j++)
                {
                    sb.Append(strings[j]);
                }

                _ = sb.ToString();
            }
        }
    }


    [Config(typeof(BenchmarkConfig))]
    public class Utf8AppendPerformance
    {
        List<string> strings;
        const int COUNT = 1000;

        public Utf8AppendPerformance()
        {
            strings = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                strings.Add("123456789");
            }
        }

        [Benchmark]
        public void ZStringUtf8()
        {
            for (int i = 0; i < COUNT; i++)
            {
                using (var sb = ZString.CreateUtf8StringBuilder())
                {
                    for (int j = 0; j < strings.Count; j++)
                    {
                        sb.Append(strings[j]);
                    }

                    _ = sb.AsSpan().ToArray();
                }
            }
        }

        [Benchmark(Baseline = true)]
        public void StringBuilder()
        {
            for (int i = 0; i < COUNT; i++)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int j = 0; j < strings.Count; j++)
                {
                    sb.Append(strings[j]);
                }

                _ = sb.ToString();
            }
        }
    }
}
