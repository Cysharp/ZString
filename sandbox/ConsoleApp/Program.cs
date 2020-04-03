using Cysharp.Text;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Text.Formatting;
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
var a = new string('a', 10000);
var b = new string('b', 1000000);

ZString.Join(',', new string[] { a, b });

            

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

        public string StringFormatterFormat()
        {
            return StringBuffer.Format(format, x, y);
        }
    }
}
