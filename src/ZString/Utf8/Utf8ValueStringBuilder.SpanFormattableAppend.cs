using System;
using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder
    {
        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Byte value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Byte value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Byte value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTime value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTime value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.DateTime value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTimeOffset value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.DateTimeOffset value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.DateTimeOffset value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Decimal value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Decimal value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Decimal value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Double value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Double value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Double value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int16 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int16 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Int16 value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int32 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int32 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Int32 value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int64 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Int64 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Int64 value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.SByte value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.SByte value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.SByte value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Single value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Single value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Single value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.TimeSpan value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.TimeSpan value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.TimeSpan value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt16 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt16 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.UInt16 value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt32 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt32 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.UInt32 value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt64 value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.UInt64 value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.UInt64 value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Guid value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Guid value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
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
        public void AppendLine(System.Guid value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value to this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Boolean value)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value to this instance with numeric format strings.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(System.Boolean value, StandardFormat format)
        {
            if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out var written, format))
            {
                Grow(written);
                if(!Utf8Formatter.TryFormat(value, buffer.AsSpan(index), out written, format))
                {
                    ThrowArgumentException(nameof(value));
                }
            }
            index += written;
        }

        /// <summary>Appends the string representation of a specified value followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Boolean value)
        {
            Append(value);
            AppendLine();
        }

        /// <summary>Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine(System.Boolean value, StandardFormat format)
        {
            Append(value, format);
            AppendLine();
        }

    }
}
