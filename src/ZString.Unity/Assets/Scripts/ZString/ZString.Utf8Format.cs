using System;
using System.Buffers;
using System.Runtime.CompilerServices;

using static Cysharp.Text.Utf8ValueStringBuilder;

namespace Cysharp.Text
{
    public static partial class ZString
    {
        /// <summary>Replaces one or more format items in a string with the string representation of some specified values.</summary>
        public static void Utf8Format<T1>(IBufferWriter<byte> bufferWriter, string format, T1 arg1)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg14, indexParse.Alignment, writeFormat, nameof(arg14));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg14, indexParse.Alignment, writeFormat, nameof(arg14));
                            continue;
                        case 14:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg15, indexParse.Alignment, writeFormat, nameof(arg15));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            
            var copyFrom = 0;
            for (int i = 0; i < format.Length; i++)
            {
                var c = format[i];
                if (c == '{')
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg14, indexParse.Alignment, writeFormat, nameof(arg14));
                            continue;
                        case 14:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg15, indexParse.Alignment, writeFormat, nameof(arg15));
                            continue;
                        case 15:
                            Utf8FormatHelper.FormatTo(ref bufferWriter, arg16, indexParse.Alignment, writeFormat, nameof(arg16));
                            continue;
                        default:
                            ExceptionUtil.ThrowFormatException();
                            break;
                    }

                    ExceptionUtil.ThrowFormatException();
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        var buffer = bufferWriter.GetSpan(UTF8NoBom.GetMaxByteCount(size));
                        var written = UTF8NoBom.GetBytes(format.AsSpan(copyFrom, size), buffer);
                        bufferWriter.Advance(written);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                    	ExceptionUtil.ThrowFormatException();
                    }
                }
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
