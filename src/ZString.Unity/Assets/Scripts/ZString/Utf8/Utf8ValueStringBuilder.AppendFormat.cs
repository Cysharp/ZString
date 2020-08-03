using System;
using System.Buffers;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder
    {
        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1>(string format, T1 arg1)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2>(string format, T1 arg1, T2 arg2)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, writeFormat, nameof(arg10));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, writeFormat, nameof(arg11));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, writeFormat, nameof(arg12));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, writeFormat, nameof(arg13));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            AppendFormatInternal(arg14, writeFormat, nameof(arg14));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            AppendFormatInternal(arg14, writeFormat, nameof(arg14));
                            continue;
                        case 14:
                            AppendFormatInternal(arg15, writeFormat, nameof(arg15));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
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
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '{'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                    }

                    // try to find range
                    var indexParse = FormatParser.Parse(format.AsSpan(i));
                    copyFrom = i + indexParse.LastIndex + 1;
                    i = i + indexParse.LastIndex;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            AppendFormatInternal(arg14, writeFormat, nameof(arg14));
                            continue;
                        case 14:
                            AppendFormatInternal(arg15, writeFormat, nameof(arg15));
                            continue;
                        case 15:
                            AppendFormatInternal(arg16, writeFormat, nameof(arg16));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (format[i] == '}')
                {
                    if (i != format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format.AsSpan(copyFrom, size));
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format.AsSpan(copyFrom, copyLength));
                }
            }
        }

    }
}
