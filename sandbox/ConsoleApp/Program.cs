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
            var f = ZString.Format("abcdef: {0}", "abc");

            Console.WriteLine(f);
        }
    }
}
