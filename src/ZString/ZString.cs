using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cysharp.Text
{
    public static partial class ZString
    {
        static Encoding UTF8NoBom = new UTF8Encoding(false);

        /// <summary>Create the Utf16 string StringBuilder.</summary>
        public static Utf16ValueStringBuilder CreateStringBuilder()
        {
            return new Utf16ValueStringBuilder(false);
        }

        /// <summary>Create the Utf16 string StringBuilder, when true uses thread-static buffer that is faster but must return immediately.</summary>
        public static Utf8ValueStringBuilder CreateUtf8StringBuilder()
        {
            return new Utf8ValueStringBuilder(false);
        }

        /// <summary>Create the Utf8(`Span[byte]`) StringBuilder.</summary>
        public static Utf16ValueStringBuilder CreateStringBuilder(bool notNested)
        {
            return new Utf16ValueStringBuilder(notNested);
        }

        /// <summary>Create the Utf8(`Span[byte]`) StringBuilder, when true uses thread-static buffer that is faster but must return immediately.</summary>
        public static Utf8ValueStringBuilder CreateUtf8StringBuilder(bool notNested)
        {
            return new Utf8ValueStringBuilder(notNested);
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(char separator, params T[] values)
        {
            var sb = new Utf16ValueStringBuilder(true);
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

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(char separator, List<T> values)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                var count = values.Count;
                for (int i = 0; i < count; i++)
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

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(char separator, ReadOnlySpan<T> values)
        {
            var sb = new Utf16ValueStringBuilder(true);
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

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(char separator, IEnumerable<T> values)
        {
            var sb = new Utf16ValueStringBuilder(true);
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

        public static string Join<T>(char separator, ICollection<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        public static string Join<T>(char separator, IList<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        public static string Join<T>(char separator, IReadOnlyList<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        public static string Join<T>(char separator, IReadOnlyCollection<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string separator, params T[] values)
        {
            var sb = new Utf16ValueStringBuilder(true);
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

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string separator, List<T> values)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                var count = values.Count;
                for (int i = 0; i < count; i++)
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

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string separator, ReadOnlySpan<T> values)
        {
            var sb = new Utf16ValueStringBuilder(true);
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

        public static string Join<T>(string separator, ICollection<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        public static string Join<T>(string separator, IList<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        public static string Join<T>(string separator, IReadOnlyList<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        public static string Join<T>(string separator, IReadOnlyCollection<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            var sb = new Utf16ValueStringBuilder(true);
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
