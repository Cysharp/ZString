using Cysharp.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNet472
{
    class Program
    {
        static void Main(string[] args)
        {
            //double d = double.Epsilon;
            //Span<char> s = stackalloc char[128];

            //var ok = ShimsExtensions.TryFormat(d, s, out var written);
            //Console.WriteLine(ok);
            //Console.WriteLine(written);
            //Console.WriteLine(new string(s.Slice(written).ToArray()));

            // ReadOnlySpan<char> hoge = "hugahuga";
            var tako = ZString.Format("hoge{0}hoge{1}", 100, 200);

            // new Utf8ValueStringBuilder().


            Console.WriteLine(tako);

        }
    }
}
