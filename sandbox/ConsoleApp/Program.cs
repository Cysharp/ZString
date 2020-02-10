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
            var s = ZString.Concat("a", 100, "b", 200);
            Console.WriteLine(s);
        }
    }
}
