using System;
using System.Buffers;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder
    {
        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1>(string format, T1 arg1)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2>(string format, T1 arg1, T2 arg2)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            AppendFormatInternal(arg14, indexParse.Alignment, writeFormat, nameof(arg14));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            AppendFormatInternal(arg14, indexParse.Alignment, writeFormat, nameof(arg14));
                            continue;
                        case 14:
                            AppendFormatInternal(arg15, indexParse.Alignment, writeFormat, nameof(arg15));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

        /// <summary>Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments.</summary>
        public void AppendFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
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
                        Append(format, copyFrom, size);
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
                    var indexParse = FormatParser.Parse(format, i);
                    copyFrom = indexParse.LastIndex;
                    i = indexParse.LastIndex - 1;
                    var writeFormat = StandardFormat.Parse(indexParse.FormatString);
                    switch (indexParse.Index)
                    {
                        case 0:
                            AppendFormatInternal(arg1, indexParse.Alignment, writeFormat, nameof(arg1));
                            continue;
                        case 1:
                            AppendFormatInternal(arg2, indexParse.Alignment, writeFormat, nameof(arg2));
                            continue;
                        case 2:
                            AppendFormatInternal(arg3, indexParse.Alignment, writeFormat, nameof(arg3));
                            continue;
                        case 3:
                            AppendFormatInternal(arg4, indexParse.Alignment, writeFormat, nameof(arg4));
                            continue;
                        case 4:
                            AppendFormatInternal(arg5, indexParse.Alignment, writeFormat, nameof(arg5));
                            continue;
                        case 5:
                            AppendFormatInternal(arg6, indexParse.Alignment, writeFormat, nameof(arg6));
                            continue;
                        case 6:
                            AppendFormatInternal(arg7, indexParse.Alignment, writeFormat, nameof(arg7));
                            continue;
                        case 7:
                            AppendFormatInternal(arg8, indexParse.Alignment, writeFormat, nameof(arg8));
                            continue;
                        case 8:
                            AppendFormatInternal(arg9, indexParse.Alignment, writeFormat, nameof(arg9));
                            continue;
                        case 9:
                            AppendFormatInternal(arg10, indexParse.Alignment, writeFormat, nameof(arg10));
                            continue;
                        case 10:
                            AppendFormatInternal(arg11, indexParse.Alignment, writeFormat, nameof(arg11));
                            continue;
                        case 11:
                            AppendFormatInternal(arg12, indexParse.Alignment, writeFormat, nameof(arg12));
                            continue;
                        case 12:
                            AppendFormatInternal(arg13, indexParse.Alignment, writeFormat, nameof(arg13));
                            continue;
                        case 13:
                            AppendFormatInternal(arg14, indexParse.Alignment, writeFormat, nameof(arg14));
                            continue;
                        case 14:
                            AppendFormatInternal(arg15, indexParse.Alignment, writeFormat, nameof(arg15));
                            continue;
                        case 15:
                            AppendFormatInternal(arg16, indexParse.Alignment, writeFormat, nameof(arg16));
                            continue;
                        default:
                            ThrowFormatException();
                            break;
                    }
                }
                else if (c == '}')
                {
                    if (i + 1 < format.Length && format[i + 1] == '}')
                    {
                        var size = i - copyFrom;
                        Append(format, copyFrom, size);
                        i = i + 1; // skip escaped '}'
                        copyFrom = i;
                        continue;
                    }
                    else
                    {
                        ThrowFormatException();
                    }
                }

            }

            {
                // copy final string
                var copyLength = format.Length - copyFrom;
                if (copyLength > 0)
                {
                    Append(format, copyFrom, copyLength);
                }
            }
        }

    }
}
