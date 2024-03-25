using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Cysharp.Text
{
    internal static class EnumUtil<T>
        // where T : Enum
    {
        const string InvalidName = "$";

        static readonly Dictionary<T, string> names;
        static readonly Dictionary<T, byte[]> utf8names;

        static EnumUtil()
        {
            var enumNames = Enum.GetNames(typeof(T));
            var values =
#if NET7_0_OR_GREATER
                Enum.GetValuesAsUnderlyingType(typeof(T));
#else
                Enum.GetValues(typeof(T));
#endif
            names = new Dictionary<T, string>(enumNames.Length);
            utf8names = new Dictionary<T, byte[]>(enumNames.Length);
            for (int i = 0; i < enumNames.Length; i++)
            {
                var value = (T)values.GetValue(i)!;
                if (names.ContainsKey(value))
                {
                    // already registered = invalid.
                    names[value] = InvalidName;
                    utf8names[value] = Array.Empty<byte>(); // byte[0] == Invalid.
                }
                else
                {
                    names.Add(value, enumNames[i]);
                    utf8names.Add(value, Encoding.UTF8.GetBytes(enumNames[i]));
                }
            }
        }

        public static bool TryFormatUtf16(T value, Span<char> dest, out int written, ReadOnlySpan<char> _)
        {
            if (!names.TryGetValue(value, out var v) || v == InvalidName)
            {
                v = value!.ToString(); // T is Enum, not null always
            }

            written = v.Length;
            return v.AsSpan().TryCopyTo(dest);
        }

        public static bool TryFormatUtf8(T value, Span<byte> dest, out int written, StandardFormat _)
        {
            if (!utf8names.TryGetValue(value, out var v) || v.Length == 0)
            {
                v = Encoding.UTF8.GetBytes(value!.ToString());
            }

            written = v.Length;
            return v.AsSpan().TryCopyTo(dest);
        }
    }
}
