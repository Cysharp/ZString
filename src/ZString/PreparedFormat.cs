using System;
using System.Collections.Generic;

namespace Cysharp.Text
{
    public sealed partial class PreparedFormat
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = Parse(format);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
        }

        // TODO:test 2args.
        public string Format<T0, T1>(T0 arg0, T1 arg1)
        {
            // using (var sb = new Utf16ValueStringBuilder(true))


            {
                while (true)
                {
                    var buffer = sb.AsArraySegment().Array;
                    if (TryFormat(buffer, arg0, arg1, out var written))
                    {
                        return new string(buffer, 0, written);
                    }
                    else
                    {
                        // sb.ad
                    }
                }
            }
        }

        public bool TryFormat<T0, T1>(Span<char> span, T0 arg0, T1 arg1, out int written)
        {
            written = 0;

            if (span.Length < MinSize)
            {
                return false;
            }

            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    span = span.Slice(item.Count);
                    written += item.Count;
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                if (!Utf16ValueStringBuilder.FormatterCache<T0>.TryFormatDelegate(arg0, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    written += argWritten;
                                    return false;
                                }
                                span = span.Slice(written);
                                written += argWritten;
                                break;
                            }
                        case 1:
                            {
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    written += argWritten;
                                    return false;
                                }
                                span = span.Slice(written);
                                written += argWritten;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }

            return true;
        }

        FormatSegment[] Parse(string format)
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
                        list.Add(new FormatSegment(copyFrom, size, false, 0, null));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        list.Add(new FormatSegment(copyFrom, size, false, 0, null));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    list.Add(new FormatSegment(0, 0, true, indexParse.Index, indexParse.FormatString.ToString()));

                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        list.Add(new FormatSegment(copyFrom, size, false, 0, null));
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
                    list.Add(new FormatSegment(copyFrom, copyLength, false, 0, null));
                }
            }

            return list.ToArray();
        }

        readonly struct FormatSegment
        {
            public readonly int Offset;
            public readonly int Count;
            public readonly bool IsFormatArgument;
            public readonly int FormatIndex;
            public readonly string FormatString;

            public FormatSegment(int offset, int count, bool isFormatArgument, int formatIndex, string formatString)
            {
                Offset = offset;
                Count = count;
                IsFormatArgument = isFormatArgument;
                FormatIndex = formatIndex;
                FormatString = formatString;
            }
        }
    }
}
