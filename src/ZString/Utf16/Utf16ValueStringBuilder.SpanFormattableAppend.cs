using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public partial struct Utf16ValueStringBuilder
    {
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Byte value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Byte value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this; 
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Byte value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Byte value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.DateTime value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.DateTime value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.DateTime value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.DateTime value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.DateTimeOffset value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.DateTimeOffset value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.DateTimeOffset value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.DateTimeOffset value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Decimal value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Decimal value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Decimal value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Decimal value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Double value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Double value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Double value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Double value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Int16 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Int16 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Int16 value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Int16 value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Int32 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Int32 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Int32 value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Int32 value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Int64 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this; 
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Int64 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Int64 value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Int64 value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.SByte value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.SByte value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.SByte value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.SByte value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Single value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Single value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Single value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Single value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.TimeSpan value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.TimeSpan value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.TimeSpan value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.TimeSpan value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.UInt16 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.UInt16 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.UInt16 value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.UInt16 value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.UInt32 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.UInt32 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.UInt32 value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.UInt32 value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.UInt64 value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.UInt64 value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.UInt64 value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.UInt64 value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Guid value)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder Append(System.Guid value, string format)
        {
            if(!value.TryFormat(buffer.AsSpan(index), out var written, format.AsSpan()))
            {
                Grow(written);
                if(!value.TryFormat(buffer.AsSpan(index), out written, format.AsSpan()))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
            return this;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Guid value)
        {
            Append(value);
            AppendLine();
            return this;
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Utf16ValueStringBuilder AppendLine(System.Guid value, string format)
        {
            Append(value, format);
            AppendLine();
            return this;
        }
    }
}
