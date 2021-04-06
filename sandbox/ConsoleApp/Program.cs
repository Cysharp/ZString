using Cysharp.Text;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
// using System.Text.Formatting;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public struct MyStruct
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            TimeSpan span = new TimeSpan(12, 34, 56);
            Console.WriteLine($"string.Format: {string.Format(@"{0:h\,h\:mm\:ss}", span)}");


            Console.WriteLine($"ZString.Format: {ZString.Format(@"{0:h\,h\:mm\:ss}", span)}");



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
