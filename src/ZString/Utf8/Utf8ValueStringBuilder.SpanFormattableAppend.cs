using System;
using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder
    {        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Byte value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Byte value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTime value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTime value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTimeOffset value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTimeOffset value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Decimal value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Decimal value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Double value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Double value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int16 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int16 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int32 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int32 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int64 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int64 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.SByte value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.SByte value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Single value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Single value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.TimeSpan value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.TimeSpan value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt16 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt16 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt32 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt32 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt64 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt64 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Guid value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Guid value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

    }
}