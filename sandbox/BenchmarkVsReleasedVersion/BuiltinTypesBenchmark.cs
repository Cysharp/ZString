// Before use, You must change AssemblyName to "NewZString" of local ZString.csproj

extern alias NewZString;

using System;
using System.Collections.Generic;
using System.Text;
using Cysharp.Text;
using NZString = NewZString::Cysharp.Text.ZString;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using PF16 = Cysharp.Text.Utf16PreparedFormat<byte, System.DateTime, System.DateTimeOffset, decimal, double, System.Guid, short, float, System.TimeSpan, uint, ulong, object, string, bool, System.TypeCode, char>;
using NPF16 = NewZString::Cysharp.Text.Utf16PreparedFormat<byte, System.DateTime, System.DateTimeOffset, decimal, double, System.Guid, short, float, System.TimeSpan, uint, ulong, object, string, bool, System.TypeCode, char>;

using PF8 = Cysharp.Text.Utf8PreparedFormat<byte, System.DateTime, System.DateTimeOffset, decimal, double, System.Guid, short, float, System.TimeSpan, uint, ulong, object, string, bool, System.TypeCode, char>;
using NPF8 = NewZString::Cysharp.Text.Utf8PreparedFormat<byte, System.DateTime, System.DateTimeOffset, decimal, double, System.Guid, short, float, System.TimeSpan, uint, ulong, object, string, bool, System.TypeCode, char>;

namespace BenchmarkVsReleasedVersion
{
    [Config(typeof(BenchmarkConfig))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [DisassemblyDiagnoser]
    public class BuiltinTypesBenchmark
    {
        string _format;

        byte _byte;
        DateTime _dt;
        DateTimeOffset _dto;
        decimal _decimal;
        double _double;
        Guid _guid;
        short _short;
        sbyte _sbyte;
        float _float;
        TimeSpan _ts;
        ushort _ushort;
        uint _uint;
        ulong _ulong;
        object _null;
        string _string;
        bool _bool;
        TypeCode _enum;
        char _char;

        PF16 _utf16preparedFormat_;
        NPF16 _utf16preparedFormatN;

        PF8 _utf8preparedFormat_;
        NPF8 _utf8preparedFormatN;

        public BuiltinTypesBenchmark()
        {
            var rand = new Random();

            _format = "{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-{13}-{14}-{15}";

            _utf16preparedFormat_ = new PF16(_format);
            _utf16preparedFormatN = new NPF16(_format);

            _utf8preparedFormat_ = new PF8(_format);
            _utf8preparedFormatN = new NPF8(_format);

            _byte = (byte)rand.Next();
            _dt = DateTime.Now;
            _dto = DateTimeOffset.Now;
            _decimal = (decimal)rand.NextDouble();
            _double = rand.NextDouble();
            _guid = Guid.NewGuid();
            _short = (short)rand.Next();
            _sbyte = (sbyte)rand.Next();
            _float = (float)rand.NextDouble();
            _ts = DateTime.Now - DateTime.Today;
            _ushort = (ushort)rand.Next();
            _uint = (uint)rand.Next();
            _ulong = (ulong)rand.Next();
            _null = null;
            _string = Guid.NewGuid().ToString();
            _bool = rand.Next() % 1 == 0;
            _enum = (TypeCode)rand.Next((int)TypeCode.DateTime);
            _char = (char)rand.Next();
        }

        [BenchmarkCategory("Format"), Benchmark(Baseline = true)]
        public string Format_()
        {
            return ZString.Format(_format,
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
        }

        [BenchmarkCategory("Format"), Benchmark]
        public string FormatN()
        {
            return NZString.Format(_format,
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
        }

        [BenchmarkCategory("CreateUtf16PreparedFormat"), Benchmark(Baseline = true)]
        public object CreateUtf16PreparedFormat_()
        {
            return new PF16(_format);
        }

        [BenchmarkCategory("CreateUtf16PreparedFormat"), Benchmark]
        public object CreateUtf16PreparedFormatN()
        {
            return new NPF16(_format);
        }

        [BenchmarkCategory("CreateUtf8PreparedFormat"), Benchmark(Baseline = true)]
        public object CreateUtf8PreparedFormat_()
        {
            return new PF8(_format);
        }

        [BenchmarkCategory("CreateUtf8PreparedFormat"), Benchmark]
        public object CreateUtf8PreparedFormatN()
        {
            return new NPF8(_format);
        }

        [BenchmarkCategory("Utf16PreparedFormat"), Benchmark(Baseline = true)]
        public string Utf16PreparedFormat_()
        {
            return _utf16preparedFormat_.Format(
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
        }

        [BenchmarkCategory("Utf16PreparedFormat"), Benchmark]
        public string Utf16PreparedFormatN()
        {
            return _utf16preparedFormatN.Format(
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
        }

        [BenchmarkCategory("Utf8PreparedFormat"), Benchmark(Baseline = true)]
        public string Utf8PreparedFormat_()
        {
            return _utf8preparedFormat_.Format(
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
        }

        [BenchmarkCategory("Utf8PreparedFormat"), Benchmark]
        public string Utf8PreparedFormatN()
        {
            return _utf8preparedFormatN.Format(
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
        }

        [BenchmarkCategory("Utf16StringBuilderAppendFormat"), Benchmark(Baseline = true)]
        public int Utf16StringBuilderAppendFormat_()
        {
            using var zsh = ZString.CreateStringBuilder();
            zsh.AppendFormat(_format,
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf16StringBuilderAppendFormat"), Benchmark]
        public int Utf16StringBuilderAppendFormatN()
        {
            using var zsh = NZString.CreateStringBuilder();
            zsh.AppendFormat(_format,
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf8StringBuilderAppendFormat"), Benchmark(Baseline = true)]
        public int Utf8StringBuilderAppendFormat_()
        {
            using var zsh = ZString.CreateUtf8StringBuilder();
            zsh.AppendFormat(_format,
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
            return zsh.Length;
        }

        [BenchmarkCategory("Utf8StringBuilderAppendFormat"), Benchmark]
        public int Utf8StringBuilderAppendFormatN()
        {
            using var zsh = NZString.CreateUtf8StringBuilder();
            zsh.AppendFormat(_format,
                _byte, _dt, _dto, _decimal, _double, _guid, _short, _float, _ts, _uint, _ulong, _null, _string, _bool, _enum, _char);
            return zsh.Length;
        }
    }
}
