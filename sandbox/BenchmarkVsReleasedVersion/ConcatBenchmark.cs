extern alias NewZString;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Cysharp.Text;
using System;
using System.Text;

namespace BenchmarkVsReleasedVersion
{
    [Config(typeof(BenchmarkConfig))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [DisassemblyDiagnoser(maxDepth: 3)]
    public class ConcatBenchmark
    {
        int a;
        int b;
        int c;
        int x;
        int y;
        int z;

        public ConcatBenchmark()
        {
            a = int.Parse("000");
            b = int.Parse("111");
            c = int.Parse("222");
            x = int.Parse("333");
            y = int.Parse("444");
            z = int.Parse("555");
        }

        [BenchmarkCategory("FourParams"), Benchmark(Baseline = true)]
        public string FourParamsConcat_()
        {
            return ZString
                .Concat("x:", x, " y:", y);
        }

        [BenchmarkCategory("FourParams"), Benchmark]
        public string FourParamsConcatN()
        {
            return NewZString::Cysharp.Text.ZString
                .Concat("x:", x, " y:", y);
        }

        [BenchmarkCategory("SixParams"), Benchmark(Baseline = true)]
        public string SixParamsConcat_()
        {
            return ZString
                .Concat("a:", a, " b:", b, " c:", c);
        }

        [BenchmarkCategory("SixParams"), Benchmark]
        public string SixParamsConcatN()
        {
            return NewZString::Cysharp.Text.ZString
                .Concat("a:", a, " b:", b, " c:", c);
        }

        [BenchmarkCategory("EightParams"), Benchmark(Baseline = true)]
        public string EightParamsConcat_()
        {
            return ZString
                .Concat("a:", a, " b:", b, " c:", c, " x:", x);
        }

        [BenchmarkCategory("EightParams"), Benchmark]
        public string EightParamsConcatN()
        {
            return NewZString::Cysharp.Text.ZString
                .Concat("a:", a, " b:", b, " c:", c, " x:", x);
        }

        [BenchmarkCategory("TenParams"), Benchmark(Baseline = true)]
        public string TenParamsConcat_()
        {
            return ZString
                .Concat("a:", a, " b:", b, " c:", c, " x:", x, " y:", y);
        }

        [BenchmarkCategory("TenParams"), Benchmark]
        public string TenParamsConcatN()
        {
            return NewZString::Cysharp.Text.ZString
                .Concat("a:", a, " b:", b, " c:", c, " x:", x, " y:", y);
        }

        [BenchmarkCategory("TwelveParams"), Benchmark(Baseline = true)]
        public string TwelveParamsConcat_()
        {
            return ZString
                .Concat("a:", a, " b:", b, " c:", c, " x:", x, " y:", y, " z:", z);
        }

        [BenchmarkCategory("TwelveParams"), Benchmark]
        public string TwelveParamsConcatN()
        {
            return NewZString::Cysharp.Text.ZString
                .Concat("a:", a, " b:", b, " c:", c, " x:", x, " y:", y, " z:", z);
        }
    }
}
