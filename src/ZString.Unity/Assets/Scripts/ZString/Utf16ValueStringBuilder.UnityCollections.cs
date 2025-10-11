#if ZSTRING_COLLECTIONS_SUPPORT
using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Collections;

namespace Cysharp.Text
{
    partial struct Utf16ValueStringBuilder
    {
        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString32Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the byte length of the buffer exceeds 29 bytes.</exception>
        public FixedString32Bytes AsFixedString32Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString32Bytes();
            }

            int byteCount = GetUtf8ByteCount(in buffer, in index);

            if (byteCount > FixedString32Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString32Bytes ({FixedString32Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in byteCount))
            {
                return new FixedString32Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString64Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the byte length of the buffer exceeds 61 bytes.</exception>
        public FixedString64Bytes AsFixedString64Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString64Bytes();
            }

            int byteCount = GetUtf8ByteCount(in buffer, in index);

            if (byteCount > FixedString64Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString64Bytes ({FixedString64Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in byteCount))
            {
                return new FixedString64Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString128Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the byte length of the buffer exceeds 125 bytes.</exception>
        public FixedString128Bytes AsFixedString128Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString128Bytes();
            }

            int byteCount = GetUtf8ByteCount(in buffer, in index);

            if (byteCount > FixedString128Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString128Bytes ({FixedString128Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in byteCount))
            {
                return new FixedString128Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString512Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the byte length of the buffer exceeds 509 bytes.</exception>
        public FixedString512Bytes AsFixedString512Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString512Bytes();
            }

            int byteCount = GetUtf8ByteCount(in buffer, in index);

            if (byteCount > FixedString512Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString512Bytes ({FixedString512Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in byteCount))
            {
                return new FixedString512Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString4096Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the byte length of the buffer exceeds 4093 bytes.</exception>
        public FixedString4096Bytes AsFixedString4096Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString4096Bytes();
            }

            int byteCount = GetUtf8ByteCount(in buffer, in index);

            if (byteCount > FixedString4096Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString4096Bytes ({FixedString4096Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in byteCount))
            {
                return new FixedString4096Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Helper method to copy a <see cref="char" /> array buffer to <see cref="NativeText" />
        /// </summary>
        /// <param name="buffer">The current buffer.</param>
        /// <param name="byteCount">The amount of bytes this buffer requires.</param>
        /// <returns><see cref="NativeText" /> with the <paramref name="buffer" /> written to it.</returns>
        private static NativeText CopyToNativeText(in char[] buffer, in int byteCount)
        {
            byte[]? destinationArray = ArrayPool<byte>.Shared.Rent(byteCount);
            Span<byte> destination = destinationArray.AsSpan(0, byteCount);
            int writtenBytes = Encoding.UTF8.GetBytes(buffer, destination);

            NativeText text = new NativeText(writtenBytes, Allocator.Temp);
            for (int i = 0; i < writtenBytes; i++)
            {
                text.Add(destination[i]);
            }

            ArrayPool<byte>.Shared.Return(destinationArray);

            return text;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetUtf8ByteCount(in char[] buffer, in int length)
        {
            return Encoding.UTF8.GetByteCount(buffer, 0, length);
        }
    }
}
#endif
