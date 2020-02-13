using System;
using System.Buffers;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder
    {
        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0>(string format, T0 arg0)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1>(string format, T0 arg0, T1 arg1)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2>(string format, T0 arg0, T1 arg1, T2 arg2)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 14:
                            {
                                if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
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
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            {
                                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg0));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 14:
                            {
                                if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        case 15:
                            {
                                if (!FormatterCache<T15>.TryFormatDelegate(arg15, buffer.AsSpan(index), out var written, writeFormat))
                                {
                                    Grow(written);
                                    if (!FormatterCache<T15>.TryFormatDelegate(arg15, buffer.AsSpan(index), out written, writeFormat))
                                    {
                                        ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                index += written;
                                goto NEXT_LOOP;
                            }
                        default:
                            ThrowFormatException();
                            break;
                    }

                    ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        TryGrow(UTF8NoBom.GetMaxByteCount(size));
                        index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer.AsSpan(index));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

                NEXT_LOOP:
                continue;
            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    TryGrow(UTF8NoBom.GetMaxByteCount(copyLength));
                    index += UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer.AsSpan(index));
                }
            }
        }

    }
}