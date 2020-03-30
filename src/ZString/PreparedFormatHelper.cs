using System;
using System.Buffers;
using System.Collections.Generic;

namespace Cysharp.Text
{
    internal static class PreparedFormatHelper
    {
        internal static FormatSegment[] Parse(string format, bool withStandardFormat)
        {
            var list = new List<FormatSegment>();

            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                if (format[i] == '{')
                {
                    // escape.
                    if (i == format.Length - 1)
                    {
                        throw new FormatException("invalid format");
                    }

                    if (i != format.Length && format[i + 1] == '{')
                    {
                        var size = i - copyFrom;
                        if (size != 0)
                        {
                            list.Add(new FormatSegment(copyFrom, size, false, 0, null, withStandardFormat));
                        }
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        if (size != 0)
                        {
                            list.Add(new FormatSegment(copyFrom, size, false, 0, null, withStandardFormat));
                        }
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    list.Add(new FormatSegment(0, 0, true, indexParse.Index, indexParse.FormatString.ToString(), withStandardFormat));

                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        if (size != 0)
                        {
                            list.Add(new FormatSegment(copyFrom, size, false, 0, null, withStandardFormat));
                        }
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                }
            }

            {
                // final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    list.Add(new FormatSegment(copyFrom, copyLength, false, 0, null, withStandardFormat));
                }
            }

            return list.ToArray();
        }
    }


    internal readonly struct FormatSegment
    {
        public readonly int Offset;
        public readonly int Count;
        public readonly bool IsFormatArgument;
        public readonly int FormatIndex;
        public readonly string FormatString;

        // Utf8
        public readonly StandardFormat StandardFormat;

        public FormatSegment(int offset, int count, bool isFormatArgument, int formatIndex, string formatString, bool utf8)
        {
            Offset = offset;
            Count = count;
            IsFormatArgument = isFormatArgument;
            FormatIndex = formatIndex;
            FormatString = formatString;
            if (utf8)
            {
                StandardFormat = (formatString != null) ? StandardFormat.Parse(formatString) : default;
            }
            else
            {
                StandardFormat = default;
            }
        }
    }
}
