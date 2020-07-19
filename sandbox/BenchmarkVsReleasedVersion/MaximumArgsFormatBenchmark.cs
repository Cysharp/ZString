// Before use, You must change AssemblyName to "NewZString" of local ZString.csproj

extern alias NewZString;

using System;
using System.Collections.Generic;
using System.Text;
using Cysharp.Text;
using NZString = NewZString::Cysharp.Text.ZString;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using PF16 = Cysharp.Text.Utf16PreparedFormat<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>;
using NPF16 = NewZString::Cysharp.Text.Utf16PreparedFormat<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>;

using PF8 = Cysharp.Text.Utf8PreparedFormat<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>;
using NPF8 = NewZString::Cysharp.Text.Utf8PreparedFormat<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>;

namespace BenchmarkVsReleasedVersion
{
    [Config(typeof(BenchmarkConfig))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [DisassemblyDiagnoser(maxDepth: 3)]
    public class MaximumArgsFormatBenchmark
    {
        readonly int[] _args;

        readonly string _format;
        PF16 _utf16preparedFormat_;
        NPF16 _utf16preparedFormatN;

        PF8 _utf8preparedFormat_;
        NPF8 _utf8preparedFormatN;

        public MaximumArgsFormatBenchmark() 
        {
            _args = new int[16];
            var rand = new Random();
            _format = "<";
            for (var i = 0; i < _args.Length; i++)
            {
                _args[i] = rand.Next();
                _format += "{" + i + "}, ";
            }
            _format += ">";

            _utf16preparedFormat_ = new PF16(_format);
            _utf16preparedFormatN = new NPF16(_format);

            _utf8preparedFormat_ = new PF8(_format);
            _utf8preparedFormatN = new NPF8(_format);
        }

        [BenchmarkCategory("Format"), Benchmark(Baseline = true)]
        public string Format_()
        {
            return ZString.Format(_format, _args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
        }

        [BenchmarkCategory("Format"), Benchmark]
        public string FormatN()
        {
            return NZString.Format(_format, _args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
        }

        [BenchmarkCategory("CreatePreparedFormat"), Benchmark(Baseline = true)]
        public object CreatePreparedFormat_()
        {
            return new PF16(_format);
        }

        [BenchmarkCategory("CreatePreparedFormat"), Benchmark]
        public object CreatePreparedFormatN()
        {
            return new NPF16(_format);
        }

        [BenchmarkCategory("Utf16PreparedFormat"), Benchmark(Baseline = true)]
        public string Utf16PreparedFormat_()
        {
            return _utf16preparedFormat_.Format(_args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
        }

        [BenchmarkCategory("Utf16PreparedFormat"), Benchmark]
        public string Utf16PreparedFormatN()
        {
            return _utf16preparedFormatN.Format(_args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
        }

        [BenchmarkCategory("Utf8PreparedFormat"), Benchmark(Baseline = true)]
        public string Utf8PreparedFormat_()
        {
            return _utf8preparedFormat_.Format(_args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
        }

        [BenchmarkCategory("Utf8PreparedFormat"), Benchmark]
        public string Utf8PreparedFormatN()
        {
            return _utf8preparedFormatN.Format(_args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
        }

        [BenchmarkCategory("Utf16StringBuilderAppendFormat"), Benchmark(Baseline = true)]
        public int Utf16StringBuilderAppendFormat_()
        {
            using var zsh = ZString.CreateStringBuilder();
            zsh.AppendFormat(_format, _args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf16StringBuilderAppendFormat"), Benchmark]
        public int Utf16StringBuilderAppendFormatN()
        {
            using var zsh = NZString.CreateStringBuilder();
            zsh.AppendFormat(_format, _args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf8StringBuilderAppendFormat"), Benchmark(Baseline = true)]
        public int Utf8StringBuilderAppendFormat_()
        {
            using var zsh = ZString.CreateUtf8StringBuilder();
            zsh.AppendFormat(_format, _args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf8StringBuilderAppendFormat"), Benchmark]
        public int Utf8StringBuilderAppendFormatN()
        {
            using var zsh = NZString.CreateUtf8StringBuilder();
            zsh.AppendFormat(_format, _args[0], _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15]);
            return zsh.Length;
        }
    }
}
