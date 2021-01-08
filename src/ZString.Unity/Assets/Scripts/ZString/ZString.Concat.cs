using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public static partial class ZString
    {
        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1>(T1 arg1)
        {
            if (typeof(T1) == typeof(string))
            {
                return (arg1 != null) ? Unsafe.As<string>(arg1) : string.Empty;
            }

            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2>(T1 arg1, T2 arg2)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                if (typeof(T10) == typeof(string))
                {
                    if(arg10 != null)
                    {
                        sb.Append(Unsafe.As<T10, string>(ref arg10));
                    }
                }
                else if (typeof(T10) == typeof(int))
                {
                    sb.Append(Unsafe.As<T10, int>(ref arg10));
                }
                else
                {
                    sb.Append(arg10);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                if (typeof(T10) == typeof(string))
                {
                    if(arg10 != null)
                    {
                        sb.Append(Unsafe.As<T10, string>(ref arg10));
                    }
                }
                else if (typeof(T10) == typeof(int))
                {
                    sb.Append(Unsafe.As<T10, int>(ref arg10));
                }
                else
                {
                    sb.Append(arg10);
                }

                if (typeof(T11) == typeof(string))
                {
                    if(arg11 != null)
                    {
                        sb.Append(Unsafe.As<T11, string>(ref arg11));
                    }
                }
                else if (typeof(T11) == typeof(int))
                {
                    sb.Append(Unsafe.As<T11, int>(ref arg11));
                }
                else
                {
                    sb.Append(arg11);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                if (typeof(T10) == typeof(string))
                {
                    if(arg10 != null)
                    {
                        sb.Append(Unsafe.As<T10, string>(ref arg10));
                    }
                }
                else if (typeof(T10) == typeof(int))
                {
                    sb.Append(Unsafe.As<T10, int>(ref arg10));
                }
                else
                {
                    sb.Append(arg10);
                }

                if (typeof(T11) == typeof(string))
                {
                    if(arg11 != null)
                    {
                        sb.Append(Unsafe.As<T11, string>(ref arg11));
                    }
                }
                else if (typeof(T11) == typeof(int))
                {
                    sb.Append(Unsafe.As<T11, int>(ref arg11));
                }
                else
                {
                    sb.Append(arg11);
                }

                if (typeof(T12) == typeof(string))
                {
                    if(arg12 != null)
                    {
                        sb.Append(Unsafe.As<T12, string>(ref arg12));
                    }
                }
                else if (typeof(T12) == typeof(int))
                {
                    sb.Append(Unsafe.As<T12, int>(ref arg12));
                }
                else
                {
                    sb.Append(arg12);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                if (typeof(T10) == typeof(string))
                {
                    if(arg10 != null)
                    {
                        sb.Append(Unsafe.As<T10, string>(ref arg10));
                    }
                }
                else if (typeof(T10) == typeof(int))
                {
                    sb.Append(Unsafe.As<T10, int>(ref arg10));
                }
                else
                {
                    sb.Append(arg10);
                }

                if (typeof(T11) == typeof(string))
                {
                    if(arg11 != null)
                    {
                        sb.Append(Unsafe.As<T11, string>(ref arg11));
                    }
                }
                else if (typeof(T11) == typeof(int))
                {
                    sb.Append(Unsafe.As<T11, int>(ref arg11));
                }
                else
                {
                    sb.Append(arg11);
                }

                if (typeof(T12) == typeof(string))
                {
                    if(arg12 != null)
                    {
                        sb.Append(Unsafe.As<T12, string>(ref arg12));
                    }
                }
                else if (typeof(T12) == typeof(int))
                {
                    sb.Append(Unsafe.As<T12, int>(ref arg12));
                }
                else
                {
                    sb.Append(arg12);
                }

                if (typeof(T13) == typeof(string))
                {
                    if(arg13 != null)
                    {
                        sb.Append(Unsafe.As<T13, string>(ref arg13));
                    }
                }
                else if (typeof(T13) == typeof(int))
                {
                    sb.Append(Unsafe.As<T13, int>(ref arg13));
                }
                else
                {
                    sb.Append(arg13);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                if (typeof(T10) == typeof(string))
                {
                    if(arg10 != null)
                    {
                        sb.Append(Unsafe.As<T10, string>(ref arg10));
                    }
                }
                else if (typeof(T10) == typeof(int))
                {
                    sb.Append(Unsafe.As<T10, int>(ref arg10));
                }
                else
                {
                    sb.Append(arg10);
                }

                if (typeof(T11) == typeof(string))
                {
                    if(arg11 != null)
                    {
                        sb.Append(Unsafe.As<T11, string>(ref arg11));
                    }
                }
                else if (typeof(T11) == typeof(int))
                {
                    sb.Append(Unsafe.As<T11, int>(ref arg11));
                }
                else
                {
                    sb.Append(arg11);
                }

                if (typeof(T12) == typeof(string))
                {
                    if(arg12 != null)
                    {
                        sb.Append(Unsafe.As<T12, string>(ref arg12));
                    }
                }
                else if (typeof(T12) == typeof(int))
                {
                    sb.Append(Unsafe.As<T12, int>(ref arg12));
                }
                else
                {
                    sb.Append(arg12);
                }

                if (typeof(T13) == typeof(string))
                {
                    if(arg13 != null)
                    {
                        sb.Append(Unsafe.As<T13, string>(ref arg13));
                    }
                }
                else if (typeof(T13) == typeof(int))
                {
                    sb.Append(Unsafe.As<T13, int>(ref arg13));
                }
                else
                {
                    sb.Append(arg13);
                }

                if (typeof(T14) == typeof(string))
                {
                    if(arg14 != null)
                    {
                        sb.Append(Unsafe.As<T14, string>(ref arg14));
                    }
                }
                else if (typeof(T14) == typeof(int))
                {
                    sb.Append(Unsafe.As<T14, int>(ref arg14));
                }
                else
                {
                    sb.Append(arg14);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                if (typeof(T10) == typeof(string))
                {
                    if(arg10 != null)
                    {
                        sb.Append(Unsafe.As<T10, string>(ref arg10));
                    }
                }
                else if (typeof(T10) == typeof(int))
                {
                    sb.Append(Unsafe.As<T10, int>(ref arg10));
                }
                else
                {
                    sb.Append(arg10);
                }

                if (typeof(T11) == typeof(string))
                {
                    if(arg11 != null)
                    {
                        sb.Append(Unsafe.As<T11, string>(ref arg11));
                    }
                }
                else if (typeof(T11) == typeof(int))
                {
                    sb.Append(Unsafe.As<T11, int>(ref arg11));
                }
                else
                {
                    sb.Append(arg11);
                }

                if (typeof(T12) == typeof(string))
                {
                    if(arg12 != null)
                    {
                        sb.Append(Unsafe.As<T12, string>(ref arg12));
                    }
                }
                else if (typeof(T12) == typeof(int))
                {
                    sb.Append(Unsafe.As<T12, int>(ref arg12));
                }
                else
                {
                    sb.Append(arg12);
                }

                if (typeof(T13) == typeof(string))
                {
                    if(arg13 != null)
                    {
                        sb.Append(Unsafe.As<T13, string>(ref arg13));
                    }
                }
                else if (typeof(T13) == typeof(int))
                {
                    sb.Append(Unsafe.As<T13, int>(ref arg13));
                }
                else
                {
                    sb.Append(arg13);
                }

                if (typeof(T14) == typeof(string))
                {
                    if(arg14 != null)
                    {
                        sb.Append(Unsafe.As<T14, string>(ref arg14));
                    }
                }
                else if (typeof(T14) == typeof(int))
                {
                    sb.Append(Unsafe.As<T14, int>(ref arg14));
                }
                else
                {
                    sb.Append(arg14);
                }

                if (typeof(T15) == typeof(string))
                {
                    if(arg15 != null)
                    {
                        sb.Append(Unsafe.As<T15, string>(ref arg15));
                    }
                }
                else if (typeof(T15) == typeof(int))
                {
                    sb.Append(Unsafe.As<T15, int>(ref arg15));
                }
                else
                {
                    sb.Append(arg15);
                }

                return sb.ToString();
            }
            finally
            {
                sb.Dispose();
            }
        }

        /// <summary>Concatenates the string representation of some specified objects.</summary>
        public static string Concat<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            var sb = new Utf16ValueStringBuilder(true);
            try
            {
                if (typeof(T1) == typeof(string))
                {
                    if(arg1 != null)
                    {
                        sb.Append(Unsafe.As<T1, string>(ref arg1));
                    }
                }
                else if (typeof(T1) == typeof(int))
                {
                    sb.Append(Unsafe.As<T1, int>(ref arg1));
                }
                else
                {
                    sb.Append(arg1);
                }

                if (typeof(T2) == typeof(string))
                {
                    if(arg2 != null)
                    {
                        sb.Append(Unsafe.As<T2, string>(ref arg2));
                    }
                }
                else if (typeof(T2) == typeof(int))
                {
                    sb.Append(Unsafe.As<T2, int>(ref arg2));
                }
                else
                {
                    sb.Append(arg2);
                }

                if (typeof(T3) == typeof(string))
                {
                    if(arg3 != null)
                    {
                        sb.Append(Unsafe.As<T3, string>(ref arg3));
                    }
                }
                else if (typeof(T3) == typeof(int))
                {
                    sb.Append(Unsafe.As<T3, int>(ref arg3));
                }
                else
                {
                    sb.Append(arg3);
                }

                if (typeof(T4) == typeof(string))
                {
                    if(arg4 != null)
                    {
                        sb.Append(Unsafe.As<T4, string>(ref arg4));
                    }
                }
                else if (typeof(T4) == typeof(int))
                {
                    sb.Append(Unsafe.As<T4, int>(ref arg4));
                }
                else
                {
                    sb.Append(arg4);
                }

                if (typeof(T5) == typeof(string))
                {
                    if(arg5 != null)
                    {
                        sb.Append(Unsafe.As<T5, string>(ref arg5));
                    }
                }
                else if (typeof(T5) == typeof(int))
                {
                    sb.Append(Unsafe.As<T5, int>(ref arg5));
                }
                else
                {
                    sb.Append(arg5);
                }

                if (typeof(T6) == typeof(string))
                {
                    if(arg6 != null)
                    {
                        sb.Append(Unsafe.As<T6, string>(ref arg6));
                    }
                }
                else if (typeof(T6) == typeof(int))
                {
                    sb.Append(Unsafe.As<T6, int>(ref arg6));
                }
                else
                {
                    sb.Append(arg6);
                }

                if (typeof(T7) == typeof(string))
                {
                    if(arg7 != null)
                    {
                        sb.Append(Unsafe.As<T7, string>(ref arg7));
                    }
                }
                else if (typeof(T7) == typeof(int))
                {
                    sb.Append(Unsafe.As<T7, int>(ref arg7));
                }
                else
                {
                    sb.Append(arg7);
                }

                if (typeof(T8) == typeof(string))
                {
                    if(arg8 != null)
                    {
                        sb.Append(Unsafe.As<T8, string>(ref arg8));
                    }
                }
                else if (typeof(T8) == typeof(int))
                {
                    sb.Append(Unsafe.As<T8, int>(ref arg8));
                }
                else
                {
                    sb.Append(arg8);
                }

                if (typeof(T9) == typeof(string))
                {
                    if(arg9 != null)
                    {
                        sb.Append(Unsafe.As<T9, string>(ref arg9));
                    }
                }
                else if (typeof(T9) == typeof(int))
                {
                    sb.Append(Unsafe.As<T9, int>(ref arg9));
                }
                else
                {
                    sb.Append(arg9);
                }

                if (typeof(T10) == typeof(string))
                {
                    if(arg10 != null)
                    {
                        sb.Append(Unsafe.As<T10, string>(ref arg10));
                    }
                }
                else if (typeof(T10) == typeof(int))
                {
                    sb.Append(Unsafe.As<T10, int>(ref arg10));
                }
                else
                {
                    sb.Append(arg10);
                }

                if (typeof(T11) == typeof(string))
                {
                    if(arg11 != null)
                    {
                        sb.Append(Unsafe.As<T11, string>(ref arg11));
                    }
                }
                else if (typeof(T11) == typeof(int))
                {
                    sb.Append(Unsafe.As<T11, int>(ref arg11));
                }
                else
                {
                    sb.Append(arg11);
                }

                if (typeof(T12) == typeof(string))
                {
                    if(arg12 != null)
                    {
                        sb.Append(Unsafe.As<T12, string>(ref arg12));
                    }
                }
                else if (typeof(T12) == typeof(int))
                {
                    sb.Append(Unsafe.As<T12, int>(ref arg12));
                }
                else
                {
                    sb.Append(arg12);
                }

                if (typeof(T13) == typeof(string))
                {
                    if(arg13 != null)
                    {
                        sb.Append(Unsafe.As<T13, string>(ref arg13));
                    }
                }
                else if (typeof(T13) == typeof(int))
                {
                    sb.Append(Unsafe.As<T13, int>(ref arg13));
                }
                else
                {
                    sb.Append(arg13);
                }

                if (typeof(T14) == typeof(string))
                {
                    if(arg14 != null)
                    {
                        sb.Append(Unsafe.As<T14, string>(ref arg14));
                    }
                }
                else if (typeof(T14) == typeof(int))
                {
                    sb.Append(Unsafe.As<T14, int>(ref arg14));
                }
                else
                {
                    sb.Append(arg14);
                }

                if (typeof(T15) == typeof(string))
                {
                    if(arg15 != null)
                    {
                        sb.Append(Unsafe.As<T15, string>(ref arg15));
                    }
                }
                else if (typeof(T15) == typeof(int))
                {
                    sb.Append(Unsafe.As<T15, int>(ref arg15));
                }
                else
                {
                    sb.Append(arg15);
                }

                if (typeof(T16) == typeof(string))
                {
                    if(arg16 != null)
                    {
                        sb.Append(Unsafe.As<T16, string>(ref arg16));
                    }
                }
                else if (typeof(T16) == typeof(int))
                {
                    sb.Append(Unsafe.As<T16, int>(ref arg16));
                }
                else
                {
                    sb.Append(arg16);
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