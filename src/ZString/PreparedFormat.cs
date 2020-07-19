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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg14, nameof(arg14));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg14, nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg15, nameof(arg15));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var span = sb.GetSpan(item.Count);
                            strSpan.TryCopyTo(span);
                            sb.Advance(item.Count);
                        }
                        break;
                    case 0:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg14, nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg15, nameof(arg15));
                            break;
                        }
                    case 15:
                        {
                            Utf16PreparedFormat.FormatTo(ref sb, item, arg16, nameof(arg16));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg14, nameof(arg14));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg14, nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg15, nameof(arg15));
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
            foreach (var item in segments)
            {
                switch (item.FormatIndex)
                {
                    case FormatSegment.NotFormatIndex:
                        {
                            var strSpan = FormatString.AsSpan(item.Offset, item.Count);
                            var size = Utf8ValueStringBuilder.UTF8NoBom.GetMaxByteCount(item.Count);
                            var span = sb.GetSpan(size);
                            var count = Utf8ValueStringBuilder.UTF8NoBom.GetBytes(strSpan, span);
                            sb.Advance(count);
                        }
                        break;
                    case 0:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg1, nameof(arg1));
                            break;
                        }
                    case 1:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg2, nameof(arg2));
                            break;
                        }
                    case 2:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg3, nameof(arg3));
                            break;
                        }
                    case 3:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg4, nameof(arg4));
                            break;
                        }
                    case 4:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg5, nameof(arg5));
                            break;
                        }
                    case 5:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg6, nameof(arg6));
                            break;
                        }
                    case 6:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg7, nameof(arg7));
                            break;
                        }
                    case 7:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg8, nameof(arg8));
                            break;
                        }
                    case 8:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg9, nameof(arg9));
                            break;
                        }
                    case 9:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg10, nameof(arg10));
                            break;
                        }
                    case 10:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg11, nameof(arg11));
                            break;
                        }
                    case 11:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg12, nameof(arg12));
                            break;
                        }
                    case 12:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg13, nameof(arg13));
                            break;
                        }
                    case 13:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg14, nameof(arg14));
                            break;
                        }
                    case 14:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg15, nameof(arg15));
                            break;
                        }
                    case 15:
                        {
                            Utf8PreparedFormat.FormatTo(ref sb, item, arg16, nameof(arg16));
                            break;
                        }
                }
            }
        }
    }
}
