using Cysharp.Text;
using System;
using System.Linq;
using System.Text;
using System.Text.Formatting;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            using (var sb = ZString.CreateStringBuilder())
            {
                sb.Append("foo");
                sb.AppendLine(42);
                sb.AppendFormat("{0} {1:.###}", "bar", 123.456789);
                sb.Concat(1, "foo", 100, "bar");

                Console.WriteLine(sb.ToString());
            }
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
