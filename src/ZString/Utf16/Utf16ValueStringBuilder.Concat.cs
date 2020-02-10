using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public partial struct Utf16ValueStringBuilder
    {
        public void Concat<T0>(T0 arg0)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0>(T0 arg0)
        {
            Concat(arg0);
            AppendNewLine();
        }

        public void Concat<T0, T1>(T0 arg0, T1 arg1)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1>(T0 arg0, T1 arg1)
        {
            Concat(arg0, arg1);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
        {
            Concat(arg0, arg1, arg2);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            Concat(arg0, arg1, arg2, arg3);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Concat(arg0, arg1, arg2, arg3, arg4);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

            if (typeof(T9) == typeof(string))
            {
                var s9 = Unsafe.As<T9, string>(ref arg9);
                if (s9 != null)
                {
                    TryGrow(s9.Length);
                    s9.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s9.Length;
                }
            }
            else if (typeof(T9) == typeof(int))
            {
                int written = 0;

                var i9 = Unsafe.As<T9, int>(ref arg9);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

            if (typeof(T9) == typeof(string))
            {
                var s9 = Unsafe.As<T9, string>(ref arg9);
                if (s9 != null)
                {
                    TryGrow(s9.Length);
                    s9.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s9.Length;
                }
            }
            else if (typeof(T9) == typeof(int))
            {
                int written = 0;

                var i9 = Unsafe.As<T9, int>(ref arg9);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }

            if (typeof(T10) == typeof(string))
            {
                var s10 = Unsafe.As<T10, string>(ref arg10);
                if (s10 != null)
                {
                    TryGrow(s10.Length);
                    s10.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s10.Length;
                }
            }
            else if (typeof(T10) == typeof(int))
            {
                int written = 0;

                var i10 = Unsafe.As<T10, int>(ref arg10);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

            if (typeof(T9) == typeof(string))
            {
                var s9 = Unsafe.As<T9, string>(ref arg9);
                if (s9 != null)
                {
                    TryGrow(s9.Length);
                    s9.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s9.Length;
                }
            }
            else if (typeof(T9) == typeof(int))
            {
                int written = 0;

                var i9 = Unsafe.As<T9, int>(ref arg9);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }

            if (typeof(T10) == typeof(string))
            {
                var s10 = Unsafe.As<T10, string>(ref arg10);
                if (s10 != null)
                {
                    TryGrow(s10.Length);
                    s10.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s10.Length;
                }
            }
            else if (typeof(T10) == typeof(int))
            {
                int written = 0;

                var i10 = Unsafe.As<T10, int>(ref arg10);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }

            if (typeof(T11) == typeof(string))
            {
                var s11 = Unsafe.As<T11, string>(ref arg11);
                if (s11 != null)
                {
                    TryGrow(s11.Length);
                    s11.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s11.Length;
                }
            }
            else if (typeof(T11) == typeof(int))
            {
                int written = 0;

                var i11 = Unsafe.As<T11, int>(ref arg11);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

            if (typeof(T9) == typeof(string))
            {
                var s9 = Unsafe.As<T9, string>(ref arg9);
                if (s9 != null)
                {
                    TryGrow(s9.Length);
                    s9.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s9.Length;
                }
            }
            else if (typeof(T9) == typeof(int))
            {
                int written = 0;

                var i9 = Unsafe.As<T9, int>(ref arg9);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }

            if (typeof(T10) == typeof(string))
            {
                var s10 = Unsafe.As<T10, string>(ref arg10);
                if (s10 != null)
                {
                    TryGrow(s10.Length);
                    s10.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s10.Length;
                }
            }
            else if (typeof(T10) == typeof(int))
            {
                int written = 0;

                var i10 = Unsafe.As<T10, int>(ref arg10);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }

            if (typeof(T11) == typeof(string))
            {
                var s11 = Unsafe.As<T11, string>(ref arg11);
                if (s11 != null)
                {
                    TryGrow(s11.Length);
                    s11.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s11.Length;
                }
            }
            else if (typeof(T11) == typeof(int))
            {
                int written = 0;

                var i11 = Unsafe.As<T11, int>(ref arg11);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }

            if (typeof(T12) == typeof(string))
            {
                var s12 = Unsafe.As<T12, string>(ref arg12);
                if (s12 != null)
                {
                    TryGrow(s12.Length);
                    s12.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s12.Length;
                }
            }
            else if (typeof(T12) == typeof(int))
            {
                int written = 0;

                var i12 = Unsafe.As<T12, int>(ref arg12);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

            if (typeof(T9) == typeof(string))
            {
                var s9 = Unsafe.As<T9, string>(ref arg9);
                if (s9 != null)
                {
                    TryGrow(s9.Length);
                    s9.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s9.Length;
                }
            }
            else if (typeof(T9) == typeof(int))
            {
                int written = 0;

                var i9 = Unsafe.As<T9, int>(ref arg9);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }

            if (typeof(T10) == typeof(string))
            {
                var s10 = Unsafe.As<T10, string>(ref arg10);
                if (s10 != null)
                {
                    TryGrow(s10.Length);
                    s10.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s10.Length;
                }
            }
            else if (typeof(T10) == typeof(int))
            {
                int written = 0;

                var i10 = Unsafe.As<T10, int>(ref arg10);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }

            if (typeof(T11) == typeof(string))
            {
                var s11 = Unsafe.As<T11, string>(ref arg11);
                if (s11 != null)
                {
                    TryGrow(s11.Length);
                    s11.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s11.Length;
                }
            }
            else if (typeof(T11) == typeof(int))
            {
                int written = 0;

                var i11 = Unsafe.As<T11, int>(ref arg11);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }

            if (typeof(T12) == typeof(string))
            {
                var s12 = Unsafe.As<T12, string>(ref arg12);
                if (s12 != null)
                {
                    TryGrow(s12.Length);
                    s12.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s12.Length;
                }
            }
            else if (typeof(T12) == typeof(int))
            {
                int written = 0;

                var i12 = Unsafe.As<T12, int>(ref arg12);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }

            if (typeof(T13) == typeof(string))
            {
                var s13 = Unsafe.As<T13, string>(ref arg13);
                if (s13 != null)
                {
                    TryGrow(s13.Length);
                    s13.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s13.Length;
                }
            }
            else if (typeof(T13) == typeof(int))
            {
                int written = 0;

                var i13 = Unsafe.As<T13, int>(ref arg13);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i13))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i13))
                    {
                        ThrowArgumentException(nameof(arg13));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg13));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

            if (typeof(T9) == typeof(string))
            {
                var s9 = Unsafe.As<T9, string>(ref arg9);
                if (s9 != null)
                {
                    TryGrow(s9.Length);
                    s9.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s9.Length;
                }
            }
            else if (typeof(T9) == typeof(int))
            {
                int written = 0;

                var i9 = Unsafe.As<T9, int>(ref arg9);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }

            if (typeof(T10) == typeof(string))
            {
                var s10 = Unsafe.As<T10, string>(ref arg10);
                if (s10 != null)
                {
                    TryGrow(s10.Length);
                    s10.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s10.Length;
                }
            }
            else if (typeof(T10) == typeof(int))
            {
                int written = 0;

                var i10 = Unsafe.As<T10, int>(ref arg10);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }

            if (typeof(T11) == typeof(string))
            {
                var s11 = Unsafe.As<T11, string>(ref arg11);
                if (s11 != null)
                {
                    TryGrow(s11.Length);
                    s11.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s11.Length;
                }
            }
            else if (typeof(T11) == typeof(int))
            {
                int written = 0;

                var i11 = Unsafe.As<T11, int>(ref arg11);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }

            if (typeof(T12) == typeof(string))
            {
                var s12 = Unsafe.As<T12, string>(ref arg12);
                if (s12 != null)
                {
                    TryGrow(s12.Length);
                    s12.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s12.Length;
                }
            }
            else if (typeof(T12) == typeof(int))
            {
                int written = 0;

                var i12 = Unsafe.As<T12, int>(ref arg12);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }

            if (typeof(T13) == typeof(string))
            {
                var s13 = Unsafe.As<T13, string>(ref arg13);
                if (s13 != null)
                {
                    TryGrow(s13.Length);
                    s13.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s13.Length;
                }
            }
            else if (typeof(T13) == typeof(int))
            {
                int written = 0;

                var i13 = Unsafe.As<T13, int>(ref arg13);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i13))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i13))
                    {
                        ThrowArgumentException(nameof(arg13));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg13));
                    }
                }
                index += written;
            }

            if (typeof(T14) == typeof(string))
            {
                var s14 = Unsafe.As<T14, string>(ref arg14);
                if (s14 != null)
                {
                    TryGrow(s14.Length);
                    s14.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s14.Length;
                }
            }
            else if (typeof(T14) == typeof(int))
            {
                int written = 0;

                var i14 = Unsafe.As<T14, int>(ref arg14);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i14))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i14))
                    {
                        ThrowArgumentException(nameof(arg14));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg14));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            if (typeof(T0) == typeof(string))
            {
                var s0 = Unsafe.As<T0, string>(ref arg0);
                if (s0 != null)
                {
                    TryGrow(s0.Length);
                    s0.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s0.Length;
                }
            }
            else if (typeof(T0) == typeof(int))
            {
                int written = 0;

                var i0 = Unsafe.As<T0, int>(ref arg0);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i0))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T0>.TryFormatDelegate(arg0, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg0));
                    }
                }
                index += written;
            }

            if (typeof(T1) == typeof(string))
            {
                var s1 = Unsafe.As<T1, string>(ref arg1);
                if (s1 != null)
                {
                    TryGrow(s1.Length);
                    s1.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s1.Length;
                }
            }
            else if (typeof(T1) == typeof(int))
            {
                int written = 0;

                var i1 = Unsafe.As<T1, int>(ref arg1);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i1))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T1>.TryFormatDelegate(arg1, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg1));
                    }
                }
                index += written;
            }

            if (typeof(T2) == typeof(string))
            {
                var s2 = Unsafe.As<T2, string>(ref arg2);
                if (s2 != null)
                {
                    TryGrow(s2.Length);
                    s2.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s2.Length;
                }
            }
            else if (typeof(T2) == typeof(int))
            {
                int written = 0;

                var i2 = Unsafe.As<T2, int>(ref arg2);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i2))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T2>.TryFormatDelegate(arg2, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg2));
                    }
                }
                index += written;
            }

            if (typeof(T3) == typeof(string))
            {
                var s3 = Unsafe.As<T3, string>(ref arg3);
                if (s3 != null)
                {
                    TryGrow(s3.Length);
                    s3.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s3.Length;
                }
            }
            else if (typeof(T3) == typeof(int))
            {
                int written = 0;

                var i3 = Unsafe.As<T3, int>(ref arg3);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i3))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T3>.TryFormatDelegate(arg3, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg3));
                    }
                }
                index += written;
            }

            if (typeof(T4) == typeof(string))
            {
                var s4 = Unsafe.As<T4, string>(ref arg4);
                if (s4 != null)
                {
                    TryGrow(s4.Length);
                    s4.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s4.Length;
                }
            }
            else if (typeof(T4) == typeof(int))
            {
                int written = 0;

                var i4 = Unsafe.As<T4, int>(ref arg4);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i4))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T4>.TryFormatDelegate(arg4, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg4));
                    }
                }
                index += written;
            }

            if (typeof(T5) == typeof(string))
            {
                var s5 = Unsafe.As<T5, string>(ref arg5);
                if (s5 != null)
                {
                    TryGrow(s5.Length);
                    s5.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s5.Length;
                }
            }
            else if (typeof(T5) == typeof(int))
            {
                int written = 0;

                var i5 = Unsafe.As<T5, int>(ref arg5);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i5))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T5>.TryFormatDelegate(arg5, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg5));
                    }
                }
                index += written;
            }

            if (typeof(T6) == typeof(string))
            {
                var s6 = Unsafe.As<T6, string>(ref arg6);
                if (s6 != null)
                {
                    TryGrow(s6.Length);
                    s6.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s6.Length;
                }
            }
            else if (typeof(T6) == typeof(int))
            {
                int written = 0;

                var i6 = Unsafe.As<T6, int>(ref arg6);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i6))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T6>.TryFormatDelegate(arg6, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg6));
                    }
                }
                index += written;
            }

            if (typeof(T7) == typeof(string))
            {
                var s7 = Unsafe.As<T7, string>(ref arg7);
                if (s7 != null)
                {
                    TryGrow(s7.Length);
                    s7.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s7.Length;
                }
            }
            else if (typeof(T7) == typeof(int))
            {
                int written = 0;

                var i7 = Unsafe.As<T7, int>(ref arg7);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i7))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T7>.TryFormatDelegate(arg7, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg7));
                    }
                }
                index += written;
            }

            if (typeof(T8) == typeof(string))
            {
                var s8 = Unsafe.As<T8, string>(ref arg8);
                if (s8 != null)
                {
                    TryGrow(s8.Length);
                    s8.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s8.Length;
                }
            }
            else if (typeof(T8) == typeof(int))
            {
                int written = 0;

                var i8 = Unsafe.As<T8, int>(ref arg8);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i8))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T8>.TryFormatDelegate(arg8, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg8));
                    }
                }
                index += written;
            }

            if (typeof(T9) == typeof(string))
            {
                var s9 = Unsafe.As<T9, string>(ref arg9);
                if (s9 != null)
                {
                    TryGrow(s9.Length);
                    s9.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s9.Length;
                }
            }
            else if (typeof(T9) == typeof(int))
            {
                int written = 0;

                var i9 = Unsafe.As<T9, int>(ref arg9);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i9))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T9>.TryFormatDelegate(arg9, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg9));
                    }
                }
                index += written;
            }

            if (typeof(T10) == typeof(string))
            {
                var s10 = Unsafe.As<T10, string>(ref arg10);
                if (s10 != null)
                {
                    TryGrow(s10.Length);
                    s10.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s10.Length;
                }
            }
            else if (typeof(T10) == typeof(int))
            {
                int written = 0;

                var i10 = Unsafe.As<T10, int>(ref arg10);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i10))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T10>.TryFormatDelegate(arg10, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg10));
                    }
                }
                index += written;
            }

            if (typeof(T11) == typeof(string))
            {
                var s11 = Unsafe.As<T11, string>(ref arg11);
                if (s11 != null)
                {
                    TryGrow(s11.Length);
                    s11.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s11.Length;
                }
            }
            else if (typeof(T11) == typeof(int))
            {
                int written = 0;

                var i11 = Unsafe.As<T11, int>(ref arg11);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i11))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T11>.TryFormatDelegate(arg11, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg11));
                    }
                }
                index += written;
            }

            if (typeof(T12) == typeof(string))
            {
                var s12 = Unsafe.As<T12, string>(ref arg12);
                if (s12 != null)
                {
                    TryGrow(s12.Length);
                    s12.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s12.Length;
                }
            }
            else if (typeof(T12) == typeof(int))
            {
                int written = 0;

                var i12 = Unsafe.As<T12, int>(ref arg12);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i12))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T12>.TryFormatDelegate(arg12, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg12));
                    }
                }
                index += written;
            }

            if (typeof(T13) == typeof(string))
            {
                var s13 = Unsafe.As<T13, string>(ref arg13);
                if (s13 != null)
                {
                    TryGrow(s13.Length);
                    s13.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s13.Length;
                }
            }
            else if (typeof(T13) == typeof(int))
            {
                int written = 0;

                var i13 = Unsafe.As<T13, int>(ref arg13);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i13))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i13))
                    {
                        ThrowArgumentException(nameof(arg13));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T13>.TryFormatDelegate(arg13, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg13));
                    }
                }
                index += written;
            }

            if (typeof(T14) == typeof(string))
            {
                var s14 = Unsafe.As<T14, string>(ref arg14);
                if (s14 != null)
                {
                    TryGrow(s14.Length);
                    s14.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s14.Length;
                }
            }
            else if (typeof(T14) == typeof(int))
            {
                int written = 0;

                var i14 = Unsafe.As<T14, int>(ref arg14);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i14))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i14))
                    {
                        ThrowArgumentException(nameof(arg14));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T14>.TryFormatDelegate(arg14, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg14));
                    }
                }
                index += written;
            }

            if (typeof(T15) == typeof(string))
            {
                var s15 = Unsafe.As<T15, string>(ref arg15);
                if (s15 != null)
                {
                    TryGrow(s15.Length);
                    s15.AsSpan().TryCopyTo(buffer.AsSpan(index));
                    index += s15.Length;
                }
            }
            else if (typeof(T15) == typeof(int))
            {
                int written = 0;

                var i15 = Unsafe.As<T15, int>(ref arg15);
                if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i15))
                {
                    Grow();
                    if (!FastNumberWriter.TryWriteInt64(buffer.AsSpan(index), out written, (long)i15))
                    {
                        ThrowArgumentException(nameof(arg15));
                    }
                }
                index += written;
            }
            else
            {
                int written = 0;

                if (!FormatterCache<T15>.TryFormatDelegate(arg15, buffer.AsSpan(index), out written, default))
                {
                    Grow(written);
                    if (!FormatterCache<T15>.TryFormatDelegate(arg15, buffer.AsSpan(index), out written, default))
                    {
                        ThrowArgumentException(nameof(arg15));
                    }
                }
                index += written;
            }

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            AppendNewLine();
        }

    }
}