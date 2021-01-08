using System;
using System.Runtime.CompilerServices;

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
            public readonly int Alignment;

            public ParseResult(int index, ReadOnlySpan<char> formatString, int lastIndex, int alignment)
            {
                Index = index;
                FormatString = formatString;
                LastIndex = lastIndex;
                Alignment = alignment;
            }
        }

        internal const int ArgLengthLimit = 16;
        internal const int WidthLimit = 1000; // Note:  -WidthLimit <  ArgAlign < WidthLimit


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ParserScanResult ScanFormatString(ReadOnlySpan<char> format, ref int i)
        {
            var len = format.Length;
            char c = format[i];

            i++; // points netxt char
            if (c == '}')
            {
                // skip escaped '}'
                if (i < len && format[i] == '}')
                {
                    i++;
                    return ParserScanResult.EscapedChar;
                }
                else
                {
                    ExceptionUtil.ThrowFormatError();
                    return ParserScanResult.NormalChar; // NOTE Don't reached
                }
            }
            else if (c == '{')
            {
                // skip escaped '{'
                if (i < len && format[i] == '{')
                {
                    i++;
                    return ParserScanResult.EscapedChar;
                }
                else
                {
                    i--;
                    return ParserScanResult.BraceOpen;
                }
            }
            else
            {
                // ch is the normal char OR end of text
                return ParserScanResult.NormalChar;
            }
        }

        // Accept only non-unicode numbers
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsDigit(char c) => '0' <= c && c <= '9';

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ParseResult Parse(string format, int i)
        {
            char c = default;
            var len = format.Length;

            i++; // Skip `{`

            //  === Index Component ===
            //   ('0'-'9')+ WS*

            if (i == len || !IsDigit(c = format[i]))
            {
                ExceptionUtil.ThrowFormatError();
            }

            int paramIndex = 0;
            do
            {
                paramIndex = (paramIndex * 10) + c - '0';

                if (++i == len)
                    ExceptionUtil.ThrowFormatError();

                c = format[i];
            }
            while (IsDigit(c) && paramIndex < ArgLengthLimit);

            if (paramIndex >= ArgLengthLimit)
            {
                ExceptionUtil.ThrowFormatException();
            }

            // skip whitespace.
            while (i < len && (c = format[i]) == ' ')
                i++;

            //  === Alignment Component ===
            //   comma WS* minus? ('0'-'9')+ WS*

            int alignment = 0;

            if (c == ',')
            {
                i++;

                // skip whitespace.
                while (i < len && (c = format[i]) == ' ')
                    i++;

                if (i == len)
                {
                    ExceptionUtil.ThrowFormatError();
                }

                var leftJustify = false;
                if (c == '-')
                {
                    leftJustify = true;

                    if (++i == len)
                        ExceptionUtil.ThrowFormatError();

                    c = format[i];
                }

                if (!IsDigit(c))
                {
                    ExceptionUtil.ThrowFormatError();
                }

                do
                {
                    alignment = (alignment * 10) + c - '0';

                    if (++i == len)
                        ExceptionUtil.ThrowFormatError();

                    c = format[i];
                }
                while (IsDigit(c) && alignment < WidthLimit);

                if (leftJustify)
                    alignment *= -1;
            }

            // skip whitespace.
            while (i < len && (c = format[i]) == ' ')
                i++;

            //  === Format String Component ===

            ReadOnlySpan<char> itemFormatSpan = default;

            if (c == ':')
            {
                i++;
                int formatStart = i;

                while (true)
                {
                    if (i == len)
                    {
                        ExceptionUtil.ThrowFormatError();
                    }
                    c = format[i];

                    if (c == '}')
                    {
                        break;
                    }
                    else if (c == '{')
                    {
                        ExceptionUtil.ThrowFormatError();
                    }

                    i++;
                }

                // has format
                if (i > formatStart)
                {
                    itemFormatSpan = format.AsSpan(formatStart, i - formatStart);
                }
            }
            else if (c != '}')
            {
                // Unexpected character
                ExceptionUtil.ThrowFormatError();
            }

            i++; // Skip `}`
            return new ParseResult(paramIndex, itemFormatSpan, i, alignment);
        }
    }
    internal enum ParserScanResult
    {
        BraceOpen,
        EscapedChar,
        NormalChar,
    }

}
