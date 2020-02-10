using System;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder
    {
        public void Concat<T0>(T0 arg0)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

        }

        public void ConcatLine<T0>(T0 arg0)
        {
            Concat(arg0);
            AppendNewLine();
        }

        public void Concat<T0, T1>(T0 arg0, T1 arg1)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1>(T0 arg0, T1 arg1)
        {
            Concat(arg0, arg1);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
        {
            Concat(arg0, arg1, arg2);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            Concat(arg0, arg1, arg2, arg3);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            Concat(arg0, arg1, arg2, arg3, arg4);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

            if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg9));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

            if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg9));
                }
            }
            index += written;

            if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg10));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

            if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg9));
                }
            }
            index += written;

            if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg10));
                }
            }
            index += written;

            if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg11));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

            if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg9));
                }
            }
            index += written;

            if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg10));
                }
            }
            index += written;

            if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg11));
                }
            }
            index += written;

            if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg12));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

            if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg9));
                }
            }
            index += written;

            if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg10));
                }
            }
            index += written;

            if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg11));
                }
            }
            index += written;

            if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg12));
                }
            }
            index += written;

            if (!FormatterCache<T13>.TryFormatDelegate(arg13, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T13>.TryFormatDelegate(arg13, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg13));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

            if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg9));
                }
            }
            index += written;

            if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg10));
                }
            }
            index += written;

            if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg11));
                }
            }
            index += written;

            if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg12));
                }
            }
            index += written;

            if (!FormatterCache<T13>.TryFormatDelegate(arg13, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T13>.TryFormatDelegate(arg13, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg13));
                }
            }
            index += written;

            if (!FormatterCache<T14>.TryFormatDelegate(arg14, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T14>.TryFormatDelegate(arg14, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg14));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            AppendNewLine();
        }

        public void Concat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            int written;
            var span = buffer.AsSpan();

            if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T0>.TryFormatDelegate(arg0, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg0));
                }
            }
            index += written;

            if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T1>.TryFormatDelegate(arg1, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg1));
                }
            }
            index += written;

            if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T2>.TryFormatDelegate(arg2, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg2));
                }
            }
            index += written;

            if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T3>.TryFormatDelegate(arg3, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg3));
                }
            }
            index += written;

            if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T4>.TryFormatDelegate(arg4, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg4));
                }
            }
            index += written;

            if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T5>.TryFormatDelegate(arg5, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg5));
                }
            }
            index += written;

            if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T6>.TryFormatDelegate(arg6, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg6));
                }
            }
            index += written;

            if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T7>.TryFormatDelegate(arg7, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg7));
                }
            }
            index += written;

            if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T8>.TryFormatDelegate(arg8, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg8));
                }
            }
            index += written;

            if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T9>.TryFormatDelegate(arg9, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg9));
                }
            }
            index += written;

            if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T10>.TryFormatDelegate(arg10, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg10));
                }
            }
            index += written;

            if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T11>.TryFormatDelegate(arg11, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg11));
                }
            }
            index += written;

            if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T12>.TryFormatDelegate(arg12, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg12));
                }
            }
            index += written;

            if (!FormatterCache<T13>.TryFormatDelegate(arg13, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T13>.TryFormatDelegate(arg13, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg13));
                }
            }
            index += written;

            if (!FormatterCache<T14>.TryFormatDelegate(arg14, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T14>.TryFormatDelegate(arg14, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg14));
                }
            }
            index += written;

            if (!FormatterCache<T15>.TryFormatDelegate(arg15, span.Slice(index), out written, default))
            {
                Grow(written);
                if (!FormatterCache<T15>.TryFormatDelegate(arg15, span.Slice(index), out written, default))
                {
                    ThrowArgumentException(nameof(arg15));
                }
            }
            index += written;

        }

        public void ConcatLine<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            Concat(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            AppendNewLine();
        }

    }
}