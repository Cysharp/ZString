using System;
using System.Text;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    internal static partial class Utf16FormatHelper
    {
        const char sp = (char)' ';

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FormatTo<TBufferWriter, T>(ref TBufferWriter sb, T arg, int width, ReadOnlySpan<char> format, string argName)
            where TBufferWriter : IBufferWriter<char>
        {
            if (width <= 0) // leftJustify
            {
                var span = sb.GetSpan(0);
                if (!Utf16ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, span, out var argWritten, format))
                {
                    sb.Advance(0);
                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                    if (!Utf16ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, span, out argWritten, format))
                    {
                        ExceptionUtil.ThrowArgumentException(argName);
                    }
                }
                sb.Advance(argWritten);

                width *= -1;
                int padding = width - argWritten;
                if (width > 0 && padding > 0)
                {
                    var paddingSpan = sb.GetSpan(padding);
                    paddingSpan.Fill(sp);
                    sb.Advance(padding);
                }
            }
            else
            {
                FormatToRightJustify(ref sb, arg, width, format, argName);
            }
        }

        private static void FormatToRightJustify<TBufferWriter, T>(ref TBufferWriter sb, T arg, int width, ReadOnlySpan<char> format, string argName)
            where TBufferWriter : IBufferWriter<char>
        {
            if (typeof(T) == typeof(string))
            {
                var s = Unsafe.As<string>(arg);
                int padding = width - s.Length;
                if (padding > 0)
                {
                    var paddingSpan = sb.GetSpan(padding);
                    paddingSpan.Fill(sp);
                    sb.Advance(padding);
                }

                var span = sb.GetSpan(s.Length);
                s.AsSpan().CopyTo(span);
                sb.Advance(s.Length);
            }
            else
            {
                Span<char> s = stackalloc char[typeof(T).IsValueType ? Unsafe.SizeOf<T>() * 8 : 1024];

                if (!Utf16ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, s, out var charsWritten, format))
                {
                    s = stackalloc char[s.Length * 2];
                    if (!Utf16ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, s, out charsWritten, format))
                    {
                        ExceptionUtil.ThrowArgumentException(argName);
                    }
                }

                int padding = width - charsWritten;
                if (padding > 0)
                {
                    var paddingSpan = sb.GetSpan(padding);
                    paddingSpan.Fill(sp);
                    sb.Advance(padding);
                }

                var span = sb.GetSpan(charsWritten);
                s.CopyTo(span);
                sb.Advance(charsWritten);
            }
        }
    }

    internal static partial class Utf8FormatHelper
    {
        const byte sp = (byte)' ';

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FormatTo<TBufferWriter, T>(ref TBufferWriter sb, T arg, int width, StandardFormat format, string argName)
            where TBufferWriter : IBufferWriter<byte>
        {
            if (width <= 0) // leftJustify
            {
                var span = sb.GetSpan(0);
                if (!Utf8ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, span, out var argWritten, format))
                {
                    sb.Advance(0);
                    span = sb.GetSpan(Math.Max(span.Length + 1, argWritten));
                    if (!Utf8ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, span, out argWritten, format))
                    {
                        ExceptionUtil.ThrowArgumentException(argName);
                    }
                }
                sb.Advance(argWritten);

                width *= -1;
                int padding = width - argWritten;
                if (width > 0 && padding > 0)
                {
                    var paddingSpan = sb.GetSpan(padding);
                    paddingSpan.Fill(sp);
                    sb.Advance(padding);
                }
            }
            else
            {
                FormatToRightJustify(ref sb, arg, width, format, argName);
            }
        }

        private static void FormatToRightJustify<TBufferWriter, T>(ref TBufferWriter sb, T arg, int width, StandardFormat format, string argName)
            where TBufferWriter : IBufferWriter<byte>
        {
            if (typeof(T) == typeof(string))
            {
                var s = Unsafe.As<string>(arg);
                int padding = width - s.Length;
                if (padding > 0)
                {
                    var paddingSpan = sb.GetSpan(padding);
                    paddingSpan.Fill(sp);
                    sb.Advance(padding);
                }

                ZString.AppendChars(ref sb, s.AsSpan());
            }
            else
            {
                Span<byte> s = stackalloc byte[typeof(T).IsValueType ? Unsafe.SizeOf<T>() * 8 : 1024];

                if (!Utf8ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, s, out var charsWritten, format))
                {
                    s = stackalloc byte[s.Length * 2];
                    if (!Utf8ValueStringBuilder.FormatterCache<T>.TryFormatDelegate(arg, s, out charsWritten, format))
                    {
                        ExceptionUtil.ThrowArgumentException(argName);
                    }
                }

                int padding = width - charsWritten;
                if (padding > 0)
                {
                    var paddingSpan = sb.GetSpan(padding);
                    paddingSpan.Fill(sp);
                    sb.Advance(padding);
                }

                var span = sb.GetSpan(charsWritten);
                s.CopyTo(span);
                sb.Advance(charsWritten);
            }
        }
    }

}