using System.Runtime.CompilerServices;
using System.Buffers;
using System;

namespace Cysharp.Text
{
    public static partial class ZString
    {
        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1>(IBufferWriter<byte> bufferWriter, string format, T1 arg1)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 14:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(IBufferWriter<byte> bufferWriter, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
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
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 1:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 2:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 3:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 4:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 5:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 6:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 7:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 8:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 9:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 10:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 11:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 12:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 13:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 14:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        case 15:
                            {
                                var buffer = bufferWriter.GetSpan();
                                if (!Utf8ValueStringBuilder.FormatterCache<T16>.TryFormatDelegate(arg16, buffer, out var written, writeFormat))
                                {
                                    bufferWriter.Advance(0);
                                    buffer = bufferWriter.GetSpan(Math.Max(buffer.Length + 1, written));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T16>.TryFormatDelegate(arg16, buffer, out written, writeFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg16));
                                    }
                                }
                                bufferWriter.Advance(written);
                                goto NEXT_LOOP;
                            }
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
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
                    var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(copyLength));
                    var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, copyLength), buffer);
                    bufferWriter.Advance(written);
                }
            }
        }

    }
}