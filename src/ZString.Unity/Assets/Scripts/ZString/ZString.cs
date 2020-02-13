using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public static partial class ZString
    {
        public static Utf16ValueStringBuilder CreateStringBuilder()
        {
            return new Utf16ValueStringBuilder(false);
        }

        public static Utf8ValueStringBuilder CreateUtf8StringBuilder()
        {
            return new Utf8ValueStringBuilder(false);
        }

        public static Utf16ValueStringBuilder CreateStringBuilder(bool notNested)
        {
            return new Utf16ValueStringBuilder(notNested);
        }

        public static Utf8ValueStringBuilder CreateUtf8StringBuilder(bool notNested)
        {
            return new Utf8ValueStringBuilder(notNested);
        }

        public static string Join<T>(char separator, params T[] values)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (i != 0)
                    {
                        sb.Append(separator);
                    }
                    sb.Append(values[i]);
                }
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public static string Join<T>(char separator, IEnumerable<T> values)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                var isFirst = true;
                foreach (var item in values)
                {
                    if (!isFirst)
                    {
                        sb.Append(separator);
                    }
                    else
                    {
                        isFirst = false;
                    }
                    sb.Append(item);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public static string Join<T>(string separator, params T[] values)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (i != 0)
                    {
                        sb.Append(separator);
                    }
                    sb.Append(values[i]);
                }
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            var sb = new Utf8ValueStringBuilder(true);
            try
            {
                var isFirst = true;
                foreach (var item in values)
                {
                    if (!isFirst)
                    {
                        sb.Append(separator);
                    }
                    else
                    {
                        isFirst = false;
                    }
                    sb.Append(item);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
    }
}
