// Before use, You must change AssemblyName to "NewZString" of local ZString.csproj

extern alias NewZString;

using System;
using System.Collections.Generic;
using System.Text;
using Cysharp.Text;
using NZString = NewZString::Cysharp.Text.ZString;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace BenchmarkVsReleasedVersion
{
    [Config(typeof(BenchmarkConfig))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [DisassemblyDiagnoser(maxDepth:3)]
    public class FormatBenchmark
    {
        int x;
        int y;

        Utf16PreparedFormat<int, int> _utf16preparedFormat_;
        NewZString::Cysharp.Text.Utf16PreparedFormat<int, int> _utf16preparedFormatN;

        Utf8PreparedFormat<int, int> _utf8preparedFormat_;
        NewZString::Cysharp.Text.Utf8PreparedFormat<int, int> _utf8preparedFormatN;

        [Params(
            "x:{0}, y:{1}",
            "This is a test to see how{0} well {1}this does.  Hello, world."
            )]
        public string FormatString { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _utf16preparedFormat_ = new Utf16PreparedFormat<int, int>(FormatString);
            _utf16preparedFormatN = new NewZString::Cysharp.Text.Utf16PreparedFormat<int, int>(FormatString);

            _utf8preparedFormat_ = new Utf8PreparedFormat<int, int>(FormatString);
            _utf8preparedFormatN = new NewZString::Cysharp.Text.Utf8PreparedFormat<int, int>(FormatString);
        }


        public FormatBenchmark()
        {
            x = int.Parse("100");
            y = int.Parse("200");
        }

        [BenchmarkCategory("Format"), Benchmark(Baseline = true)]
        public string Format_()
        {
            return ZString.Format(FormatString, x, y);
        }

        [BenchmarkCategory("Format"), Benchmark]
        public string FormatN()
        {
            return NZString.Format(FormatString, x, y);
        }

        [BenchmarkCategory("CreateUtf16PreparedFormat"), Benchmark(Baseline = true)]
        public object CreateUtf16PreparedFormat_()
        {
            return new Utf16PreparedFormat<int, int>(FormatString);
        }

        [BenchmarkCategory("CreateUtf16PreparedFormat"), Benchmark]
        public object CreateUtf16PreparedFormatN()
        {
            return new NewZString::Cysharp.Text.Utf16PreparedFormat<int, int>(FormatString);
        }

        [BenchmarkCategory("CreateUtf8PreparedFormat"), Benchmark(Baseline = true)]
        public object CreateUtf8PreparedFormat_()
        {
            return new Utf8PreparedFormat<int, int>(FormatString);
        }

        [BenchmarkCategory("CreateUtf8PreparedFormat"), Benchmark]
        public object CreateUtf8PreparedFormatN()
        {
            return new NewZString::Cysharp.Text.Utf8PreparedFormat<int, int>(FormatString);
        }

        [BenchmarkCategory("Utf16PreparedFormat"), Benchmark(Baseline = true)]
        public string Utf16PreparedFormat_()
        {
            return _utf16preparedFormat_.Format(x, y);
        }

        [BenchmarkCategory("Utf16PreparedFormat"), Benchmark]
        public string Utf16PreparedFormatN()
        {
            return _utf16preparedFormatN.Format(x, y);
        }

        [BenchmarkCategory("Utf8PreparedFormat"), Benchmark(Baseline = true)]
        public string Utf8PreparedFormat_()
        {
            return _utf8preparedFormat_.Format(x, y);
        }

        [BenchmarkCategory("Utf8PreparedFormat"), Benchmark]
        public string Utf8PreparedFormatN()
        {
            return _utf8preparedFormatN.Format(x, y);
        }

        [BenchmarkCategory("Utf16StringBuilderAppendFormat"), Benchmark(Baseline = true)]
        public int Utf16StringBuilderAppendFormat_()
        {
            using var zsh = ZString.CreateStringBuilder();
            zsh.AppendFormat(FormatString, x, y);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf16StringBuilderAppendFormat"), Benchmark]
        public int Utf16StringBuilderAppendFormatN()
        {
            using var zsh = NZString.CreateStringBuilder();
            zsh.AppendFormat(FormatString, x, y);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf8StringBuilderAppendFormat"), Benchmark(Baseline = true)]
        public int Utf8StringBuilderAppendFormat_()
        {
            using var zsh = ZString.CreateUtf8StringBuilder();
            zsh.AppendFormat(FormatString, x, y);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf8StringBuilderAppendFormat"), Benchmark]
        public int Utf8StringBuilderAppendFormatN()
        {
            using var zsh = NZString.CreateUtf8StringBuilder();
            zsh.AppendFormat(FormatString, x, y);
            return zsh.Length;
        }
    }
}
