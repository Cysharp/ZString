using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Cysharp.Text
{
    internal static class PreparedFormatHelper
    {
        internal static Utf16FormatSegment[] Utf16Parse(string format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            var list = new List<Utf16FormatSegment>();

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
                        list.Add(new Utf16FormatSegment(copyFrom, size, Utf16FormatSegment.NotFormatIndex, 0));
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

                list.Add(new Utf16FormatSegment(indexParse.LastIndex - indexParse.FormatString.Length - 1, indexParse.FormatString.Length, indexParse.Index, indexParse.Alignment));
            }

            return list.ToArray();
        }

        internal static Utf8FormatSegment[] Utf8Parse(string format, out byte[] utf8buffer)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            var list = new List<Utf8FormatSegment>();
            utf8buffer = new byte[Encoding.UTF8.GetMaxByteCount(format.Length)];
            var bufOffset = 0;

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
                        var utf8size = Encoding.UTF8.GetBytes(format, copyFrom, size, utf8buffer, bufOffset);
                        list.Add(new Utf8FormatSegment(bufOffset, utf8size, Utf8FormatSegment.NotFormatIndex, default, 0));
                        bufOffset += utf8size;
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
                list.Add(new Utf8FormatSegment(0, 0, indexParse.Index, StandardFormat.Parse(indexParse.FormatString), indexParse.Alignment));
            }

            return list.ToArray();
        }
    }

    internal readonly struct Utf8FormatSegment
    {
        public const int NotFormatIndex = -1;

        public readonly int Offset;
        public readonly int Count;
        public readonly int FormatIndex;
        public readonly StandardFormat StandardFormat;
        public readonly int Alignment;

        public bool IsFormatArgument => FormatIndex != NotFormatIndex;

        public Utf8FormatSegment(int offset, int count, int formatIndex, StandardFormat format, int alignment)
        {
            Offset = offset;
            Count = count;
            FormatIndex = formatIndex;
            StandardFormat = format;
            Alignment = alignment;
        }
    }

    internal readonly struct Utf16FormatSegment
    {
        public const int NotFormatIndex = -1;

        public readonly int Offset;
        public readonly int Count;
        public readonly int FormatIndex;
        public readonly int Alignment;

        public bool IsFormatArgument => FormatIndex != NotFormatIndex;

        public Utf16FormatSegment(int offset, int count, int formatIndex, int alignment)
        {
            Offset = offset;
            Count = count;
            FormatIndex = formatIndex;
            Alignment = alignment;
        }
    }
}
