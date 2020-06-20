using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class StringListJoinBenchmark
    {
        //private const char Separator = ',';
        private const string Separator = ",";

        List<string> _emptyList;
        IEnumerable<string> _enum1;
        string[] _array1;
        List<string> _list1;
        IEnumerable<string> _enum2;
        string[] _array2;
        List<string> _list2;
        IEnumerable<string> _enum10;
        List<string> _list10;
        string[] _array10;

        public StringListJoinBenchmark()
        {
            _emptyList = new List<string>();
            _enum1 = Enumerable.Repeat(Guid.NewGuid().ToString(), 1);
            _list1 = _enum1.ToList();
            _array1 = _enum1.ToArray();
            _enum2 = Enumerable.Repeat(Guid.NewGuid().ToString(), 2);
            _list2 = _enum2.ToList();
            _array2 = _enum2.ToArray();
            _enum10 = Enumerable.Repeat(Guid.NewGuid().ToString(), 10);
            _list10 = _enum10.ToList();
            _array10 = _enum10.ToArray();
        }

        [Benchmark]
        public string JoinEmptyList() => String.Join(Separator, _emptyList);

        [Benchmark]
        public string ZJoinEmptyList() => ZString.Join(Separator, _emptyList);

        [Benchmark]
        public string JoinList1() => String.Join(Separator, _list1);

        [Benchmark]
        public string ZJoinList1() => ZString.Join(Separator, _list1);

        [Benchmark]
        public string JoinArray1() => String.Join(Separator, _array1);

        [Benchmark]
        public string ZJoinArray1() => ZString.Join(Separator, _array1);

        [Benchmark]
        public string JoinEnumerable1() => String.Join(Separator, _enum1);

        [Benchmark]
        public string ZJoinEnumerable1() => ZString.Join(Separator, _enum1);

        [Benchmark]
        public string JoinList2() => String.Join(Separator, _list2);

        [Benchmark]
        public string ZJoinList2() => ZString.Join(Separator, _list2);

        [Benchmark]
        public string JoinArray2() => String.Join(Separator, _array2);

        [Benchmark]
        public string ZJoinArray2() => ZString.Join(Separator, _array2);

        [Benchmark]
        public string JoinEnumerable2() => String.Join(Separator, _enum2);

        [Benchmark]
        public string ZJoinEnumerable2() => ZString.Join(Separator, _enum2);

        [Benchmark]
        public string JoinList10() => String.Join(Separator, _list10);

        [Benchmark]
        public string ZJoinList10() => ZString.Join(Separator, _list10);

        [Benchmark]
        public string JoinArray10() => String.Join(Separator, _array10);

        [Benchmark]
        public string ZJoinArray10() => ZString.Join(Separator, _array10);

        [Benchmark]
        public string JoinEnumerable10() => String.Join(Separator, _enum10);

        [Benchmark]
        public string ZJoinEnumerable10() => ZString.Join(Separator, _enum10);

    }
}
