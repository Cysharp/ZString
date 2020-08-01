using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public partial struct Utf16ValueStringBuilder
    {
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Byte value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Byte value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Byte value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Byte value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTime value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTime value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.DateTime value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.DateTime value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTimeOffset value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTimeOffset value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.DateTimeOffset value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.DateTimeOffset value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Decimal value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Decimal value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Decimal value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Decimal value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Double value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Double value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Double value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Double value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int16 value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int16 value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Int16 value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Int16 value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int32 value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int32 value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Int32 value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Int32 value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int64 value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int64 value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Int64 value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Int64 value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.SByte value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.SByte value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.SByte value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.SByte value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Single value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Single value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Single value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Single value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.TimeSpan value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.TimeSpan value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.TimeSpan value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.TimeSpan value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt16 value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt16 value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.UInt16 value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.UInt16 value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt32 value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt32 value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.UInt32 value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.UInt32 value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt64 value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt64 value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.UInt64 value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.UInt64 value, string format)
        {
            Append(value, format);
            AppendLine();
        }
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Guid value)
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
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Guid value, string format)
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
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Guid value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Guid value, string format)
        {
            Append(value, format);
            AppendLine();
        }
    }
}
