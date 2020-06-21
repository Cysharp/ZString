using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal<T>(s, values.AsSpan());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(char separator, List<T> values)
        {
            return Join(separator, (IList<T>)values);
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(char separator, ReadOnlySpan<T> values)
        {
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, values);
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(char separator, IEnumerable<T> values)
        {
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, values);
        }

        public static string Join<T>(char separator, ICollection<T> values)
        {
            return Join(separator, values.AsEnumerable());
        }

        public static string Join<T>(char separator, IList<T> values)
        {
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, values);
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
            return JoinInternal<T>(separator.AsSpan(), values.AsSpan());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string separator, List<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }
        
        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string separator, ReadOnlySpan<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }

        public static string Join<T>(string separator, ICollection<T> values)
        {
            return JoinInternal(separator.AsSpan(), values.AsEnumerable());
        }

        public static string Join<T>(string separator, IList<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }

        public static string Join<T>(string separator, IReadOnlyList<T> values)
        {
            return JoinInternal(separator.AsSpan(), values.AsEnumerable());
        }

        public static string Join<T>(string separator, IReadOnlyCollection<T> values)
        {
            return JoinInternal(separator.AsSpan(), values.AsEnumerable());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }

        static string JoinInternal<T>(ReadOnlySpan<char> separator, IList<T> values)
        {
            var count = values.Count;
            if (count == 0)
            {
                return string.Empty;
            }
            else if (typeof(T) == typeof(string) && count == 1)
            {
                return Unsafe.As<string>(values[0]);
            }

            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                for (int i = 0; i < count; i++)
                {
                    if (i != 0)
                    {
                        sb.Append(separator);
                    }

                    var item = values[i];
                    if (typeof(T) == typeof(string))
                    {
                        var s = Unsafe.As<string>(item);
                        if (!string.IsNullOrEmpty(s))
                        {
                            sb.Append(s);
                        }
                    }
                    else
                    {
                        sb.Append(item);
                    }
                }
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        static string JoinInternal<T>(ReadOnlySpan<char> separator, ReadOnlySpan<T> values)
        {
            if (values.Length == 0)
            {
                return string.Empty;
            }
            else if (typeof(T) == typeof(string) && values.Length == 1)
            {
                return Unsafe.As<string>(values[0]);
            }

            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (i != 0)
                    {
                        sb.Append(separator);
                    }

                    var item = values[i];
                    if (typeof(T) == typeof(string))
                    {
                        var s = Unsafe.As<string>(item);
                        if (!string.IsNullOrEmpty(s))
                        {
                            sb.Append(s);
                        }
                    }
                    else
                    {
                        sb.Append(item);
                    }
                }
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        static string JoinInternal<T>(ReadOnlySpan<char> separator, IEnumerable<T> values)
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

                    if (typeof(T) == typeof(string))
                    {
                        var s = Unsafe.As<string>(item);
                        if (!string.IsNullOrEmpty(s))
                        {
                            sb.Append(s);
                        }
                    }
                    else
                    {
                        sb.Append(item);
                    }
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
