using System;
using System.Text;
using System.Buffers;

namespace Cysharp.Text
{
    public sealed partial class Utf16PreparedFormat<T1>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg10, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg10));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg10, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg11, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg11));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg10, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg11, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg12, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg12));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg10, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg11, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg12, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg13, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg13));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg10, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg11, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg12, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg13, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg14, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg14));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg10, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg11, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg12, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg13, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg14, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg15, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg15));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf16PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf16FormatSegment[] segments;

        public Utf16PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf16Parse(format);

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
            var formatSpan = FormatString.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf16FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg1, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg2, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg3, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg4, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg5, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg6, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg7, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg8, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg9, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg10, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg11, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg12, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg13, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg14, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg15, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg15));
                            break;
                        }
                    case 15:
                        {
                            Utf16FormatHelper.FormatTo(ref sb, arg16, item.Alignment, formatSpan.Slice(item.Offset, item.Count), nameof(arg16));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg10, item.Alignment, item.StandardFormat, nameof(arg10));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg10, item.Alignment, item.StandardFormat, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg11, item.Alignment, item.StandardFormat, nameof(arg11));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg10, item.Alignment, item.StandardFormat, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg11, item.Alignment, item.StandardFormat, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg12, item.Alignment, item.StandardFormat, nameof(arg12));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg10, item.Alignment, item.StandardFormat, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg11, item.Alignment, item.StandardFormat, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg12, item.Alignment, item.StandardFormat, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg13, item.Alignment, item.StandardFormat, nameof(arg13));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg10, item.Alignment, item.StandardFormat, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg11, item.Alignment, item.StandardFormat, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg12, item.Alignment, item.StandardFormat, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg13, item.Alignment, item.StandardFormat, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg14, item.Alignment, item.StandardFormat, nameof(arg14));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg10, item.Alignment, item.StandardFormat, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg11, item.Alignment, item.StandardFormat, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg12, item.Alignment, item.StandardFormat, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg13, item.Alignment, item.StandardFormat, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg14, item.Alignment, item.StandardFormat, nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg15, item.Alignment, item.StandardFormat, nameof(arg15));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
    public sealed partial class Utf8PreparedFormat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        public string FormatString { get; }
        public int MinSize { get; }

        readonly Utf8FormatSegment[] segments;
        readonly byte[] utf8PreEncodedbuffer;

        public Utf8PreparedFormat(string format)
        {
            this.FormatString = format;
            this.segments = PreparedFormatHelper.Utf8Parse(format, out utf8PreEncodedbuffer);

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
            var formatSpan = utf8PreEncodedbuffer.AsSpan();

            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case Utf8FormatSegment.NotFormatIndex:
                        {
                            var strSpan = formatSpan.Slice(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                            break;
                        }
                    case 0:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg1, item.Alignment, item.StandardFormat, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg2, item.Alignment, item.StandardFormat, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg3, item.Alignment, item.StandardFormat, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg4, item.Alignment, item.StandardFormat, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg5, item.Alignment, item.StandardFormat, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg6, item.Alignment, item.StandardFormat, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg7, item.Alignment, item.StandardFormat, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg8, item.Alignment, item.StandardFormat, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg9, item.Alignment, item.StandardFormat, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg10, item.Alignment, item.StandardFormat, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg11, item.Alignment, item.StandardFormat, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg12, item.Alignment, item.StandardFormat, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg13, item.Alignment, item.StandardFormat, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg14, item.Alignment, item.StandardFormat, nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg15, item.Alignment, item.StandardFormat, nameof(arg15));
                            break;
                        }
                    case 15:
                        {
                            Utf8FormatHelper.FormatTo(ref sb, arg16, item.Alignment, item.StandardFormat, nameof(arg16));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
