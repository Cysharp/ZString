using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cysharp.Text
{
    internal static class PreparedFormatHelper
    {
        internal static FormatSegment[] Parse(string format, bool withStandardFormat)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            var list = new List<FormatSegment>();

            int i = 0;
            int len = format.Length;

            var copyFrom = 0;
            var formatSpan = format.AsSpan();

            while (true)
            {
                while (i < len)
                {
                    var parserScanResult = FormatParser.ScanFormatString(formatSpan, ref i);

                    if (ParserScanResult.NormalChar == parserScanResult && i < len)
                    {
                        // skip normal char
                        continue;
                    }

                    var size = i - copyFrom;
                    if (ParserScanResult.EscapedChar == parserScanResult)
                    {
                        size--;
                    }

                    if (size != 0)
                    {
                        list.Add(new FormatSegment(copyFrom, size, FormatSegment.NotFormatIndex, format, default, 0));
                    }

                    copyFrom = i;

                    if (ParserScanResult.BraceOpen == parserScanResult)
                    {
                        break;
                    }
                }

                if (i >= len)
                {
                    break;
                }

                // Here it is before `{`.
                var indexParse = FormatParser.Parse(format, i);
                copyFrom = indexParse.LastIndex; // continue after '}'
                i = indexParse.LastIndex;

                list.Add(new FormatSegment(indexParse.LastIndex - indexParse.FormatString.Length - 1, indexParse.FormatString.Length, indexParse.Index, format, withStandardFormat, indexParse.Alignment));

            }

            return list.ToArray();
        }
    }

    internal readonly struct FormatSegment
    {
        public const int NotFormatIndex = -1;

        public readonly int Offset;
        public readonly int Count;
        public bool IsFormatArgument => FormatIndex != NotFormatIndex;
        public readonly int FormatIndex;
        public readonly string FormatString;
        public readonly int Alignment;

        // Utf8
        public readonly StandardFormat StandardFormat;

        public FormatSegment(int offset, int count, int formatIndex, string formatString, bool utf8, int alignment)
        {
            Offset = offset;
            Count = count;
            FormatIndex = formatIndex;
            FormatString = formatString;
            Alignment = alignment;
            if (utf8)
            {
                StandardFormat = (formatString != null) ? StandardFormat.Parse(formatString.AsSpan(Offset, Count)) : default;
            }
            else
            {
                StandardFormat = default;
            }
        }
    }
}
