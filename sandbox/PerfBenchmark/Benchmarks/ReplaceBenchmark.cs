using BenchmarkDotNet.Attributes;
using Cysharp.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Formatting;

namespace PerfBenchmark.Benchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class ReplaceBenchmark
    {
        StringBuilder bcl;

        string text = "The quick brown fox jumped over the lazy dogs.";
        string largeText;

        string guid = Guid.NewGuid().ToString();

        readonly string[] csharpKeywords =
        {
            "abstract",
            "as",
            "async",
            "await",
            "base",
            "bool",
            "break",
            "byte",
            "case",
            "catch",
            "char",
            "checked",
            "class",
            "const",
            "continue",
            "decimal",
            "default",
            "delegate",
            "do",
            "double",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "finally",
            "fixed",
            "float",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "int",
            "interface",
            "internal",
            "is",
            "lock",
            "long",
            "namespace",
            "new",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sbyte",
            "sealed",
            "short",
            "sizeof",
            "stackalloc",
            "static",
            "string",
            "struct",
            "switch",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "using",
            "virtual",
            "volatile",
            "void",
            "while",
        };

        private static string GetThisFilePath([System.Runtime.CompilerServices.CallerFilePath] string path = null) => path;

        public ReplaceBenchmark()
        {
            bcl = new StringBuilder();
            largeText = System.IO.File.ReadAllText(GetThisFilePath()); //read this file
            if (largeText.Length < 2048)
                throw new Exception();
        }

        [Benchmark]
        public int ReplaceChar()
        {
            bcl.Clear();
            return bcl.Append(text).Replace(' ', '\n').Length;
        }

        [Benchmark]
        public int ZReplaceChar()
        {
            using var zsb = ZString.CreateStringBuilder(true);
            zsb.Append(text);
            zsb.Replace(' ', '\n');
            return zsb.Length; // Use Length to avoid omitting it
        }

        [Benchmark]
        public int ReplaceString()
        {
            bcl.Clear();
            return bcl.Append(text).Replace(" ", "\r\n").Length; // Use Length to avoid omitting it
        }

        [Benchmark]
        public int ZReplaceString()
        {
            using var zsb = ZString.CreateStringBuilder(true);
            zsb.Append(text);
            zsb.Replace(" ", "\r\n");
            return zsb.Length; // Use Length to avoid omitting it
        }

        [Benchmark]
        public int NotReplaced()
        {
            bcl.Clear();
            bcl.Append(largeText);
            bcl.Replace(guid, "XXXXXX"); // GUID value should not be included in this file.
            return bcl.Length; // Use Length to avoid omitting it
        }

        [Benchmark]
        public int ZNotReplaced()
        {
            using var zsb = ZString.CreateStringBuilder(true);
            zsb.Append(text);
            zsb.Replace(guid, "XXXXXX"); // GUID value should not be included in this file.
            return zsb.Length; // Use Length to avoid omitting it
        }

        [Benchmark]
        public int ManyTimesReplace()
        {
            bcl.Clear();
            bcl.Append(largeText);
            // remove all keywords
            foreach (var keyword in csharpKeywords)
            {
                bcl.Replace(keyword, "");
            }
            return bcl.Length; // Use Length to avoid omitting it
        }

        [Benchmark]
        public int ZManyTimesReplace()
        {
            using var zsb = ZString.CreateStringBuilder(true);
            zsb.Append(text);
            // remove all keywords
            foreach (var keyword in csharpKeywords)
            {
                zsb.Replace(keyword, "");
            }
            return zsb.Length; // Use Length to avoid omitting it
        }
    }
}
