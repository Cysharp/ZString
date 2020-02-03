using Cysharp.Text;
using System;

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
            //using var sb = ZString.CreateStringBuilder();

            //sb.AppendLine("foo");
            //sb.AppendLine(100);
            //sb.AppendLine("baz");
            //sb.AppendLine(123.4);
            //sb.AppendLine("foo", 999, "baz", 1000.4);

            //Console.WriteLine(sb.ToString());

            //using var sb = ZString.CreateStringBuilder();


            //sb.Append(100);
            //sb.Append(100, "hogehoge");
            //sb.Append(100, "hogehoge".AsSpan());


            //sb.AppendMany("hogehoge", 100, 300);



            using var sb2 = ZString.CreateUtf8StringBuilder();

            sb2.Append("あ");
            sb2.Append(1999);
            sb2.Append("bar");

            Console.WriteLine(sb2.ToString());

        }
    }
}
