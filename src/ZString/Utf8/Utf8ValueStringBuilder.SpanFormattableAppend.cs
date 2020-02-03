using System;
using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public ref partial struct Utf8ValueStringBuilder
    {        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Byte value)
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
        public void Append(Byte value, StandardFormat format)
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
        public void Append(DateTime value)
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
        public void Append(DateTime value, StandardFormat format)
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
        public void Append(DateTimeOffset value)
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
        public void Append(DateTimeOffset value, StandardFormat format)
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
        public void Append(Decimal value)
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
        public void Append(Decimal value, StandardFormat format)
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
        public void Append(Double value)
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
        public void Append(Double value, StandardFormat format)
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
        public void Append(Int16 value)
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
        public void Append(Int16 value, StandardFormat format)
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
        public void Append(Int32 value)
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
        public void Append(Int32 value, StandardFormat format)
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
        public void Append(Int64 value)
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
        public void Append(Int64 value, StandardFormat format)
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
        public void Append(SByte value)
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
        public void Append(SByte value, StandardFormat format)
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
        public void Append(Single value)
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
        public void Append(Single value, StandardFormat format)
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
        public void Append(TimeSpan value)
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
        public void Append(TimeSpan value, StandardFormat format)
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
        public void Append(UInt16 value)
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
        public void Append(UInt16 value, StandardFormat format)
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
        public void Append(UInt32 value)
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
        public void Append(UInt32 value, StandardFormat format)
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
        public void Append(UInt64 value)
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
        public void Append(UInt64 value, StandardFormat format)
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
        public void Append(Guid value)
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
        public void Append(Guid value, StandardFormat format)
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