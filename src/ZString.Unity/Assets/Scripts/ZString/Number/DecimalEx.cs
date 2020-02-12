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

        [StructLayout(LayoutKind.Explicit)]
        private struct DecCalc
        {
            private const uint TenToPowerNine = 1000000000;

            // NOTE: Do not change the offsets of these fields. This structure must have the same layout as Decimal.
            [FieldOffset(0)]
            public uint uflags;
            [FieldOffset(4)]
            public uint uhi;
            [FieldOffset(8)]
            public uint ulo;
            [FieldOffset(12)]
            public uint umid;

            /// <summary>
            /// The low and mid fields combined in little-endian order
            /// </summary>
            [FieldOffset(8)]
            private ulong ulomidLE;

            internal static uint DecDivMod1E9(ref DecCalc value)
            {
                ulong high64 = ((ulong)value.uhi << 32) + value.umid;
                ulong div64 = high64 / TenToPowerNine;
                value.uhi = (uint)(div64 >> 32);
                value.umid = (uint)div64;

                ulong num = ((high64 - (uint)div64 * TenToPowerNine) << 32) + value.ulo;
                uint div = (uint)(num / TenToPowerNine);
                value.ulo = div;
                return (uint)num - div * TenToPowerNine;
            }
        }

        private const int ScaleShift = 16;

        static ref DecCalc AsMutable(ref decimal d) => ref Unsafe.As<decimal, DecCalc>(ref d);

        internal static uint High(this decimal value)
        {
            return Unsafe.As<decimal, DecCalc>(ref value).uhi;
        }

        internal static uint Low(this decimal value)
        {
            return Unsafe.As<decimal, DecCalc>(ref value).ulo;
        }

        internal static uint Mid(this decimal value)
        {
            return Unsafe.As<decimal, DecCalc>(ref value).umid;
        }

        internal static bool IsNegative(this decimal value)
        {
            return Unsafe.As<decimal, DecimalBits>(ref value).flags < 0;
        }

        internal static int Scale(this decimal value)
        {
            return (byte)(Unsafe.As<decimal, DecimalBits>(ref value).flags >> ScaleShift);
        }

        internal static uint DecDivMod1E9(ref decimal value)
        {
            return DecCalc.DecDivMod1E9(ref AsMutable(ref value));
        }
    }
}
