using Cysharp.Text;
using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp
{
    public struct MyStruct
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            // BenchmarkRunner.Run<JoinBenchmark>();
            Run();
        }

        static void Run()
        {
            ZString.Join(",", "a", "b");
            TimeSpan span = new TimeSpan(12, 34, 56);
            Console.WriteLine($"string.Format: {string.Format(@"{0:h\,h\:mm\:ss}", span)}");
            Console.WriteLine($"ZString.Format: {ZString.Format(@"{0:h\,h\:mm\:ss}", span)}");
        }
    }
    
    public class JoinBenchmark
    {
        public string[] Source = new []{ "111", "222", "333"};
        public const string Sp = ",";

        [Benchmark]
        public string StringJoin()
        {
            return string.Join(Sp, Source);
        }

        [Benchmark]
        public string ZStringJoin() 
        {
            return ZString.Join(Sp, Source);
        }
    }

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

        public string StringFormat()
        {
            return string.Format(format, x, y);
        }

        public string ZStringFormat()
        {
            return ZString.Format(format, x, y);
        }

        //public string StringFormatterFormat()
        //{
        //    return StringBuffer.Format(format, x, y);
        //}
    }
}
