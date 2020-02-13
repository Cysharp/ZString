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
            var x = ZString.CreateStringBuilder();

            var sb = new StringBuilder();


            

            x.AppendFormat("hoge{0:.##}, tako{1:000}", 123.456, 9);
            Console.WriteLine(x.ToString());

            var utf7 = ZString.CreateUtf8StringBuilder();
            

        }
    }
}
