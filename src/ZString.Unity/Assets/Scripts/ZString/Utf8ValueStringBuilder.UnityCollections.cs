#if ZSTRING_COLLECTIONS_SUPPORT
using System;
using Unity.Collections;

namespace Cysharp.Text
{
    partial struct Utf8ValueStringBuilder
    {
        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString32Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the <see cref="Length" /> of the buffer exceeds 29 bytes.</exception>
        public FixedString32Bytes AsFixedString32Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString32Bytes();
            }

            if (Length > FixedString32Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString32Bytes ({FixedString32Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in index))
            {
                return new FixedString32Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString64Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the <see cref="Length" /> of the buffer exceeds 61 bytes.</exception>
        public FixedString64Bytes AsFixedString64Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString64Bytes();
            }

            if (Length > FixedString64Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString64Bytes ({FixedString64Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in index))
            {
                return new FixedString64Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString128Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the <see cref="Length" /> of the buffer exceeds 125 bytes.</exception>
        public FixedString128Bytes AsFixedString128Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString128Bytes();
            }

            if (Length > FixedString128Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString128Bytes ({FixedString128Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in index))
            {
                return new FixedString128Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString512Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the <see cref="Length" /> of the buffer exceeds 509 bytes.</exception>
        public FixedString512Bytes AsFixedString512Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString512Bytes();
            }

            if (Length > FixedString512Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString512Bytes ({FixedString512Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in index))
            {
                return new FixedString512Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Get the written buffer data as a <see cref="FixedString4096Bytes" />.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the <see cref="Length" /> of the buffer exceeds 4093 bytes.</exception>
        public FixedString4096Bytes AsFixedString4096Bytes()
        {
            if (buffer == null || Length == 0)
            {
                return new FixedString4096Bytes();
            }

            if (Length > FixedString4096Bytes.UTF8MaxLengthInBytes)
            {
                throw new InvalidOperationException(
                    $"The current length ({Length}) exceeds the maximum length of FixedString4096Bytes ({FixedString4096Bytes.UTF8MaxLengthInBytes}).");
            }

            using (NativeText text = CopyToNativeText(in buffer, in index))
            {
                return new FixedString4096Bytes(text.AsReadOnly());
            }
        }

        /// <summary>
        ///     Helper method to copy a <see cref="byte"/> array buffer to <see cref="NativeText" />
        /// </summary>
        /// <param name="buffer">The current buffer.</param>
        /// <param name="length">The length of written elements in the buffer.</param>
        /// <returns><see cref="NativeText" /> with the <paramref name="buffer" /> written to it.</returns>
        private static NativeText CopyToNativeText(in byte[] buffer, in int length)
        {
            NativeText text = new NativeText(length, Allocator.Temp);
            for (int i = 0; i < length; i++)
            {
                text.Add(buffer[i]);
            }

            return text;
        }
    }
}
#endif
