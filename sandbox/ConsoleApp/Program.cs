using Cysharp.Text;
using System;
using System.Buffers;
using System.Linq;
using System.Text;
using System.Text.Formatting;
using System.Text.Json;

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
            using var sb = ZString.CreateUtf8StringBuilder();
            IBufferWriter<byte> boxed = sb;
            var writer = new Utf8JsonWriter(boxed);
            JsonSerializer.Serialize(writer, new { foo = 999 });

            using var unboxed = (Utf8ValueStringBuilder)boxed;

            Console.WriteLine(sb.ToString());
            Console.WriteLine(unboxed.ToString());
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
