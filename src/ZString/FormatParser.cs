using System;

namespace Cysharp.Text
{
    internal static class FormatParser
    {
        // {index[,alignment][:formatString]}

        public readonly ref struct ParseResult
        {
            public readonly int Index;
            public readonly ReadOnlySpan<char> FormatString;
            public readonly int LastIndex;

            public ParseResult(int index, ReadOnlySpan<char> formatString, int lastIndex)
            {
                Index = index;
                FormatString = formatString;
                LastIndex = lastIndex;
            }
        }

        public static ParseResult Parse(ReadOnlySpan<char> format)
        {
            int index = -1;
            var formatStart = -1;

            // ignore start '{'
            for (int i = 1; i < format.Length; i++)
            {
                if (format[i] == '}')
                {
                    if (index == -1)
                    {
                        index = Int32.Parse(format.Slice(1, i - 1));
                        return new ParseResult(index, default, i);
                    }
                    else
                    {
                        var formatString = format.Slice(formatStart, i - formatStart);
                        return new ParseResult(index, formatString, i);
                    }
                }

                if (index == -1 && format[i] == ',' || format[i] == ':')
                {
                    index = Int32.Parse(format.Slice(1, i - 1));
                    formatStart = i + 1;
                }
            }

            throw new FormatException("Invalid format string. format:" + format.ToString());
        }
    }
}
