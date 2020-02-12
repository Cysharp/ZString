using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    internal static class InternalSpanEx
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool EqualsOrdinalIgnoreCase(this ReadOnlySpan<char> span, ReadOnlySpan<char> value)
        {
            if (span.Length != value.Length)
                return false;
            if (value.Length == 0)  // span.Length == value.Length == 0
                return true;
            
            

            return EqualsOrdinalIgnoreCase(ref MemoryMarshal.GetReference(span), ref MemoryMarshal.GetReference(value), span.Length);
        }

        static bool EqualsOrdinalIgnoreCase(ref char charA, ref char charB, int length)
        {
            IntPtr byteOffset = IntPtr.Zero;

            if (IntPtr.Size == 8)
            {
                // Read 4 chars (64 bits) at a time from each string
                while ((uint)length >= 4)
                {
                    ulong valueA = Unsafe.ReadUnaligned<ulong>(ref Unsafe.As<char, byte>(ref Unsafe.AddByteOffset(ref charA, byteOffset)));
                    ulong valueB = Unsafe.ReadUnaligned<ulong>(ref Unsafe.As<char, byte>(ref Unsafe.AddByteOffset(ref charB, byteOffset)));

                    // A 32-bit test - even with the bit-twiddling here - is more efficient than a 64-bit test.
                    ulong temp = valueA | valueB;
                    if (!AllCharsInUInt32AreAscii((uint)temp | (uint)(temp >> 32)))
                    {
                        goto NonAscii; // one of the inputs contains non-ASCII data
                    }

                    // Generally, the caller has likely performed a first-pass check that the input strings
                    // are likely equal. Consider a dictionary which computes the hash code of its key before
                    // performing a proper deep equality check of the string contents. We want to optimize for
                    // the case where the equality check is likely to succeed, which means that we want to avoid
                    // branching within this loop unless we're about to exit the loop, either due to failure or
                    // due to us running out of input data.

                    if (!UInt64OrdinalIgnoreCaseAscii(valueA, valueB))
                    {
                        return false;
                    }

                    byteOffset += 8;
                    length -= 4;
                }
            }

            // Read 2 chars (32 bits) at a time from each string
            while ((uint)length >= 2)
            {
                uint valueA = Unsafe.ReadUnaligned<uint>(ref Unsafe.As<char, byte>(ref Unsafe.AddByteOffset(ref charA, byteOffset)));
                uint valueB = Unsafe.ReadUnaligned<uint>(ref Unsafe.As<char, byte>(ref Unsafe.AddByteOffset(ref charB, byteOffset)));

                if (!AllCharsInUInt32AreAscii(valueA | valueB))
                {
                    goto NonAscii; // one of the inputs contains non-ASCII data
                }

                // Generally, the caller has likely performed a first-pass check that the input strings
                // are likely equal. Consider a dictionary which computes the hash code of its key before
                // performing a proper deep equality check of the string contents. We want to optimize for
                // the case where the equality check is likely to succeed, which means that we want to avoid
                // branching within this loop unless we're about to exit the loop, either due to failure or
                // due to us running out of input data.

                if (!UInt32OrdinalIgnoreCaseAscii(valueA, valueB))
                {
                    return false;
                }

                byteOffset += 4;
                length -= 2;
            }

            if (length != 0)
            {
                Debug.Assert(length == 1);

                uint valueA = Unsafe.AddByteOffset(ref charA, byteOffset);
                uint valueB = Unsafe.AddByteOffset(ref charB, byteOffset);

                if ((valueA | valueB) > 0x7Fu)
                {
                    goto NonAscii; // one of the inputs contains non-ASCII data
                }

                if (valueA == valueB)
                {
                    return true; // exact match
                }

                valueA |= 0x20u;
                if ((uint)(valueA - 'a') > (uint)('z' - 'a'))
                {
                    return false; // not exact match, and first input isn't in [A-Za-z]
                }

                // The ternary operator below seems redundant but helps RyuJIT generate more optimal code.
                // See https://github.com/dotnet/coreclr/issues/914.
                return (valueA == (valueB | 0x20u)) ? true : false;
            }

            Debug.Assert(length == 0);
            return true;

            NonAscii:
            // The non-ASCII case is factored out into its own helper method so that the JIT
            // doesn't need to emit a complex prolog for its caller (this method).
            return EqualsOrdinalIgnoreCaseNonAscii(ref Unsafe.AddByteOffset(ref charA, byteOffset), ref Unsafe.AddByteOffset(ref charB, byteOffset), length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool AllCharsInUInt32AreAscii(uint value)
        {
            return (value & ~0x007F_007Fu) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool AllCharsInUInt64AreAscii(ulong value)
        {
            return (value & ~0x007F_007F_007F_007Ful) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool UInt32OrdinalIgnoreCaseAscii(uint valueA, uint valueB)
        {
            // ASSUMPTION: Caller has validated that input values are ASCII.
            Debug.Assert(AllCharsInUInt32AreAscii(valueA));
            Debug.Assert(AllCharsInUInt32AreAscii(valueB));

            // a mask of all bits which are different between A and B
            uint differentBits = valueA ^ valueB;

            // the 0x80 bit of each word of 'lowerIndicator' will be set iff the word has value < 'A'
            uint lowerIndicator = valueA + 0x0100_0100u - 0x0041_0041u;

            // the 0x80 bit of each word of 'upperIndicator' will be set iff (word | 0x20) has value > 'z'
            uint upperIndicator = (valueA | 0x0020_0020u) + 0x0080_0080u - 0x007B_007Bu;

            // the 0x80 bit of each word of 'combinedIndicator' will be set iff the word is *not* [A-Za-z]
            uint combinedIndicator = lowerIndicator | upperIndicator;

            // Shift all the 0x80 bits of 'combinedIndicator' into the 0x20 positions, then set all bits
            // aside from 0x20. This creates a mask where all bits are set *except* for the 0x20 bits
            // which correspond to alpha chars (either lower or upper). For these alpha chars only, the
            // 0x20 bit is allowed to differ between the two input values. Every other char must be an
            // exact bitwise match between the two input values. In other words, (valueA & mask) will
            // convert valueA to uppercase, so (valueA & mask) == (valueB & mask) answers "is the uppercase
            // form of valueA equal to the uppercase form of valueB?" (Technically if valueA has an alpha
            // char in the same position as a non-alpha char in valueB, or vice versa, this operation will
            // result in nonsense, but it'll still compute as inequal regardless, which is what we want ultimately.)
            // The line below is a more efficient way of doing the same check taking advantage of the XOR
            // computation we performed at the beginning of the method.

            return (((combinedIndicator >> 2) | ~0x0020_0020u) & differentBits) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool UInt64OrdinalIgnoreCaseAscii(ulong valueA, ulong valueB)
        {
            // ASSUMPTION: Caller has validated that input values are ASCII.
            Debug.Assert(AllCharsInUInt64AreAscii(valueA));
            Debug.Assert(AllCharsInUInt64AreAscii(valueB));

            // the 0x80 bit of each word of 'lowerIndicator' will be set iff the word has value >= 'A'
            ulong lowerIndicator = valueA + 0x0080_0080_0080_0080ul - 0x0041_0041_0041_0041ul;

            // the 0x80 bit of each word of 'upperIndicator' will be set iff (word | 0x20) has value <= 'z'
            ulong upperIndicator = (valueA | 0x0020_0020_0020_0020ul) + 0x0100_0100_0100_0100ul - 0x007B_007B_007B_007Bul;

            // the 0x20 bit of each word of 'combinedIndicator' will be set iff the word is [A-Za-z]
            ulong combinedIndicator = (0x0080_0080_0080_0080ul & lowerIndicator & upperIndicator) >> 2;

            // Convert both values to lowercase (using the combined indicator from the first value)
            // and compare for equality. It's possible that the first value will contain an alpha character
            // where the second value doesn't (or vice versa), and applying the combined indicator will
            // create nonsensical data, but the comparison would have failed anyway in this case so it's
            // a safe operation to perform.
            //
            // This 64-bit method is similar to the 32-bit method, but it performs the equivalent of convert-to-
            // lowercase-then-compare rather than convert-to-uppercase-and-compare. This particular operation
            // happens to be faster on x64.

            return (valueA | combinedIndicator) == (valueB | combinedIndicator);
        }

        private static bool EqualsOrdinalIgnoreCaseNonAscii(ref char charA, ref char charB, int length)
        {
            //if (!GlobalizationMode.Invariant)
            //{
            //    return CompareStringOrdinalIgnoreCase(ref charA, length, ref charB, length) == 0;
            //}
            //else
            {
                // If we don't have localization tables to consult, we'll still perform a case-insensitive
                // check for ASCII characters, but if we see anything outside the ASCII range we'll immediately
                // fail if it doesn't have true bitwise equality.

                IntPtr byteOffset = IntPtr.Zero;
                while (length != 0)
                {
                    // Ordinal equals or lowercase equals if the result ends up in the a-z range
                    uint valueA = Unsafe.AddByteOffset(ref charA, byteOffset);
                    uint valueB = Unsafe.AddByteOffset(ref charB, byteOffset);

                    if (valueA == valueB ||
                        ((valueA | 0x20) == (valueB | 0x20) &&
                            (uint)((valueA | 0x20) - 'a') <= (uint)('z' - 'a')))
                    {
                        byteOffset += 2;
                        length--;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
