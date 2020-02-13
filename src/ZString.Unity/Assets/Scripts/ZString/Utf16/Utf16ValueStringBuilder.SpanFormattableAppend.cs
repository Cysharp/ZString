using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public partial struct Utf16ValueStringBuilder
    {        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Byte value)
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
        public void Append(System.Byte value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTime value)
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
        public void Append(System.DateTime value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTimeOffset value)
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
        public void Append(System.DateTimeOffset value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Decimal value)
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
        public void Append(System.Decimal value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Double value)
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
        public void Append(System.Double value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int16 value)
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
        public void Append(System.Int16 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int32 value)
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
        public void Append(System.Int32 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int64 value)
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
        public void Append(System.Int64 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.SByte value)
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
        public void Append(System.SByte value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Single value)
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
        public void Append(System.Single value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.TimeSpan value)
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
        public void Append(System.TimeSpan value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt16 value)
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
        public void Append(System.UInt16 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt32 value)
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
        public void Append(System.UInt32 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt64 value)
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
        public void Append(System.UInt64 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Guid value)
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
        public void Append(System.Guid value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow();
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

    }
}