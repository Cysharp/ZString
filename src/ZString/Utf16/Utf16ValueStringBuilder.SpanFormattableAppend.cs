using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public ref partial struct Utf16ValueStringBuilder
    {        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Byte value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Byte value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTime value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTime value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTimeOffset value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTimeOffset value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Decimal value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Decimal value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Double value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Double value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Int16 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Int16 value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Int32 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Int32 value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Int64 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Int64 value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(SByte value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(SByte value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Single value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Single value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(TimeSpan value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(TimeSpan value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(UInt16 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(UInt16 value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(UInt32 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(UInt32 value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(UInt64 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(UInt64 value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Guid value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Guid value, ReadOnlySpan<char> format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

    }
}