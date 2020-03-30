using System;
using System.Text;
using System.Buffers;

namespace Cysharp.Text
{
    public sealed partial class Utf16PreparedFormat<T1>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 13:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 13:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 14:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, false);

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

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
            where TBufferWriter : IBufferWriter<char>
        {
            var strSpan = FormatString.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 13:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 14:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 15:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf16ValueStringBuilder.FormatterCache<T16>.TryFormatDelegate(arg16, span, out var argWritten, item.FormatString.AsSpan()))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf16ValueStringBuilder.FormatterCache<T16>.TryFormatDelegate(arg16, span, out argWritten, item.FormatString.AsSpan()))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg16));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 13:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 13:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 14:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly FormatSegment[] segments;
        readonly byte[] utf8Format;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Parse(format, true);

            var size = 0;
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    size += item.Count;
                }
            }
            this.MinSize = size;
            this.utf8Format = Encoding.UTF8.GetBytes(format);
        }

        public string Format(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                FormatTo(ref sb, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public void FormatTo<TBufferWriter>(ref TBufferWriter sb, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
            where TBufferWriter : IBufferWriter<byte>
        {
            var strSpan = utf8Format.AsSpan();
            foreach (var item in segments)
            {
                if (!item.IsFormatArgument)
                {
                    var span = sb.GetSpan(item.Count);
                    strSpan.Slice(item.Offset, item.Count).TryCopyTo(span);
                    sb.Advance(item.Count);
                }
                else
                {
                    switch (item.FormatIndex)
                    {
                        case 0:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T1>.TryFormatDelegate(arg1, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg1));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 1:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T2>.TryFormatDelegate(arg2, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg2));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 2:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T3>.TryFormatDelegate(arg3, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg3));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 3:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T4>.TryFormatDelegate(arg4, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg4));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 4:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T5>.TryFormatDelegate(arg5, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg5));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 5:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T6>.TryFormatDelegate(arg6, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg6));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 6:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T7>.TryFormatDelegate(arg7, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg7));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 7:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T8>.TryFormatDelegate(arg8, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg8));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 8:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T9>.TryFormatDelegate(arg9, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg9));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 9:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T10>.TryFormatDelegate(arg10, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg10));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 10:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T11>.TryFormatDelegate(arg11, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg11));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 11:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T12>.TryFormatDelegate(arg12, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg12));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 12:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T13>.TryFormatDelegate(arg13, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg13));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 13:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T14>.TryFormatDelegate(arg14, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg14));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 14:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T15>.TryFormatDelegate(arg15, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg15));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        case 15:
                            {
                                var span = sb.GetSpan(0);
                                if (!Utf8ValueStringBuilder.FormatterCache<T16>.TryFormatDelegate(arg16, span, out var argWritten, item.StandardFormat))
                                {
                                    sb.Advance(0);
                                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                                    if (!Utf8ValueStringBuilder.FormatterCache<T16>.TryFormatDelegate(arg16, span, out argWritten, item.StandardFormat))
                                    {
                                        ExceptionUtil.ThrowArgumentException(nameof(arg16));
                                    }
                                }
                                sb.Advance(argWritten);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }

}