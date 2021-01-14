using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Cysharp.Text
{
    internal static class EnumUtil<T>
    {
        const string InvalidName = "$";

        static readonly Dictionary<T, string> names;
        static readonly Dictionary<T, byte[]> utf8names;

        static EnumUtil()
        {
            var enumNames = Enum.GetNames(typeof(T));
            var values = Enum.GetValues(typeof(T));
            names = new Dictionary<T, string>(enumNames.Length);
            utf8names = new Dictionary<T, byte[]>(enumNames.Length);
            for (int i = 0; i < enumNames.Length; i++)
            {
                if (names.ContainsKey((T)values.GetValue(i)))
                {
                    // already registered = invalid.
                    names[(T)values.GetValue(i)] = InvalidName;
                    utf8names[(T)values.GetValue(i)] = Array.Empty<byte>(); // byte[0] == Invalid.
                }
                else
                {
                    names.Add((T)values.GetValue(i), enumNames[i]);
                    utf8names.Add((T)values.GetValue(i), Encoding.UTF8.GetBytes(enumNames[i]));
                }
            }
        }

        public static bool TryFormatUtf16(T value, Span<char> dest, out int written, ReadOnlySpan<char> _)
        {
            if (!names.TryGetValue(value, out var v) || v == InvalidName)
            {
                v = value.ToString();
            }

            written = v.Length;
            return v.AsSpan().TryCopyTo(dest);
        }

        public static bool TryFormatUtf8(T value, Span<byte> dest, out int written, StandardFormat _)
        {
            if (!utf8names.TryGetValue(value, out var v) || v.Length == 0)
            {
                v = Encoding.UTF8.GetBytes(value.ToString());
            }

            written = v.Length;
            return v.AsSpan().TryCopyTo(dest);
        }
    }
}
