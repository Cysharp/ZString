﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cysharp.Text
{
    public static partial class ZString
    {
        static Encoding UTF8NoBom = new UTF8Encoding(false);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AppendChars<TBufferWriter>(ref TBufferWriter sb, ReadOnlySpan<char> chars)
            where TBufferWriter : System.Buffers.IBufferWriter<byte>
        {
            var span = sb.GetSpan(UTF8NoBom.GetMaxByteCount(chars.Length));
            sb.Advance(UTF8NoBom.GetBytes(chars, span));
        }

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
        /// <param name="notNested">
        /// If true uses thread-static buffer that is faster but must return immediately.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This exception is thrown when <c>new StringBuilder(disposeImmediately: true)</c> or <c>ZString.CreateUtf8StringBuilder(notNested: true)</c> is nested.
        /// See the README.md
        /// </exception>
        public static Utf16ValueStringBuilder CreateStringBuilder(bool notNested)
        {
            return new Utf16ValueStringBuilder(notNested);
        }

        /// <summary>Create the Utf8(`Span[byte]`) StringBuilder, when true uses thread-static buffer that is faster but must return immediately.</summary>
        /// <param name="notNested">
        /// If true uses thread-static buffer that is faster but must return immediately.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// This exception is thrown when <c>new StringBuilder(disposeImmediately: true)</c> or <c>ZString.CreateUtf8StringBuilder(notNested: true)</c> is nested.
        /// See the README.md
        /// </exception>
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
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, (IReadOnlyList<T>)values);
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
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, values.AsEnumerable());
        }

        public static string Join<T>(char separator, IList<T> values)
        {
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, values);
        }

        public static string Join<T>(char separator, IReadOnlyList<T> values)
        {
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, values);
        }

        public static string Join<T>(char separator, IReadOnlyCollection<T> values)
        {
            ReadOnlySpan<char> s = stackalloc char[1] { separator };
            return JoinInternal(s, values.AsEnumerable());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string? separator, params T[] values)
        {
            return JoinInternal<T>(separator.AsSpan(), values.AsSpan());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string? separator, List<T> values)
        {
            return JoinInternal(separator.AsSpan(), (IReadOnlyList<T>)values);
        }
        
        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string? separator, ReadOnlySpan<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }

        public static string Join<T>(string? separator, ICollection<T> values)
        {
            return JoinInternal(separator.AsSpan(), values.AsEnumerable());
        }

        public static string Join<T>(string? separator, IList<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }

        public static string Join<T>(string? separator, IReadOnlyList<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }

        public static string Join<T>(string? separator, IReadOnlyCollection<T> values)
        {
            return JoinInternal(separator.AsSpan(), values.AsEnumerable());
        }

        /// <summary>Concatenates the elements of an array, using the specified seperator between each element.</summary>
        public static string Join<T>(string? separator, IEnumerable<T> values)
        {
            return JoinInternal(separator.AsSpan(), values);
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(params T[] values)
        {
            return JoinInternal<T>(default, values.AsSpan());
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(List<T> values)
        {
            return JoinInternal(default, (IReadOnlyList<T>)values);
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(ReadOnlySpan<T> values)
        {
            return JoinInternal(default, values);
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(ICollection<T> values)
        {
            return JoinInternal(default, values.AsEnumerable());
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(IList<T> values)
        {
            return JoinInternal(default, values);
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(IReadOnlyList<T> values)
        {
            return JoinInternal(default, values);
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(IReadOnlyCollection<T> values)
        {
            return JoinInternal(default, values.AsEnumerable());
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T>(IEnumerable<T> values)
        {
            return JoinInternal(default, values);
        }

        static string JoinInternal<T>(ReadOnlySpan<char> separator, IList<T> values)
        {
            var readOnlyList = values as IReadOnlyList<T>;
            // Boxing will occur, but JIT will be de-virtualized.
            readOnlyList = readOnlyList ?? new ReadOnlyListAdaptor<T>(values);
            return JoinInternal(separator, readOnlyList);
        }

        static string JoinInternal<T>(ReadOnlySpan<char> separator, IReadOnlyList<T> values)
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
                sb.AppendJoinInternal(separator, values);
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
                sb.AppendJoinInternal(separator, values);
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
                sb.AppendJoinInternal(separator, values);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
    }
}
