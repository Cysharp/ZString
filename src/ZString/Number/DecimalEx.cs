using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    internal static class DecimalEx
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct DecimalBits
        {
            [FieldOffset(0)]
            public int flags;
            [FieldOffset(4)]
            public int hi;
            [FieldOffset(8)]
            public int lo;
            [FieldOffset(12)]
            public int mid;
        }

        internal static uint High(this decimal value)
        {
            return (uint)Unsafe.As<decimal, DecimalBits>(ref value).hi;
        }

        internal static uint Low(this decimal value)
        {
            return (uint)Unsafe.As<decimal, DecimalBits>(ref value).lo;
        }

        internal static uint Mid(this decimal value)
        {
            return (uint)Unsafe.As<decimal, DecimalBits>(ref value).mid;
        }

        internal static bool IsNegative(this decimal value)
        {
            return Unsafe.As<decimal, DecimalBits>(ref value).flags < 0;
        }
    }
}
