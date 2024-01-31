using System.Runtime.CompilerServices;
using System;

namespace Cysharp.Text
{
    public static partial class ZString
    {
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1>(string format, T1 arg1)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1>(ReadOnlySpan<char> format, T1 arg1)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2>(ReadOnlySpan<char> format, T1 arg1, T2 arg2)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }
        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ReadOnlySpan<char> format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                sb.AppendFormat(format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T>(string format, T[] args)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                switch (args.Length)
                {
                    case 1:
                        sb.AppendFormat(format, args[0]);
                        break;
                    case 2:
                        sb.AppendFormat(format, args[0], args[1]);
                        break;
                    case 3:
                        sb.AppendFormat(format, args[0], args[1], args[2]);
                        break;
                    case 4:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3]);
                        break;
                    case 5:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4]);
                        break;
                    case 6:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5]);
                        break;
                    case 7:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6]);
                        break;
                    case 8:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]);
                        break;
                    case 9:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8]);
                        break;
                    case 10:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9]);
                        break;
                    case 11:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10]);
                        break;
                    case 12:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11]);
                        break;
                    case 13:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12]);
                        break;
                    case 14:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12], args[13]);
                        break;
                    case 15:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12], args[13], args[14]);
                        break;
                    case 16:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12], args[13], args[14], args[15]);
                        break;
                    default:
                        ExceptionUtil.ThrowArgumentException(nameof(args));
                        break;
                }
                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Replaces one or more format items in a string with the string representation of some specified objects.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Format<T>(ReadOnlySpan<char> format, T[] args)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                switch (args.Length)
                {
                    case 1:
                        sb.AppendFormat(format, args[0]);
                        break;
                    case 2:
                        sb.AppendFormat(format, args[0], args[1]);
                        break;
                    case 3:
                        sb.AppendFormat(format, args[0], args[1], args[2]);
                        break;
                    case 4:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3]);
                        break;
                    case 5:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4]);
                        break;
                    case 6:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5]);
                        break;
                    case 7:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6]);
                        break;
                    case 8:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]);
                        break;
                    case 9:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8]);
                        break;
                    case 10:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9]);
                        break;
                    case 11:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10]);
                        break;
                    case 12:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11]);
                        break;
                    case 13:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12]);
                        break;
                    case 14:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12], args[13]);
                        break;
                    case 15:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12], args[13], args[14]);
                        break;
                    case 16:
                        sb.AppendFormat(format, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7],
                            args[8], args[9], args[10], args[11], args[12], args[13], args[14], args[15]);
                        break;
                    default:
                        ExceptionUtil.ThrowArgumentException(nameof(args));
                        break;
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