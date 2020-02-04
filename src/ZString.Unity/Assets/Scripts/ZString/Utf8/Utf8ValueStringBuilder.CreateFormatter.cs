using System;
using System.Buffers;
using System.Buffers.Text;

namespace Cysharp.Text
{
    public partial struct Utf8ValueStringBuilder
    {
        static object CreateFormatter(Type type)
        {
            if (type == typeof(System.Byte))
            {
                return new TryFormat<System.Byte>((System.Byte x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.DateTime))
            {
                return new TryFormat<System.DateTime>((System.DateTime x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.DateTimeOffset))
            {
                return new TryFormat<System.DateTimeOffset>((System.DateTimeOffset x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.Decimal))
            {
                return new TryFormat<System.Decimal>((System.Decimal x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.Double))
            {
                return new TryFormat<System.Double>((System.Double x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.Guid))
            {
                return new TryFormat<System.Guid>((System.Guid x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.Int16))
            {
                return new TryFormat<System.Int16>((System.Int16 x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.Int32))
            {
                return new TryFormat<System.Int32>((System.Int32 x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.Int64))
            {
                return new TryFormat<System.Int64>((System.Int64 x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.SByte))
            {
                return new TryFormat<System.SByte>((System.SByte x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.Single))
            {
                return new TryFormat<System.Single>((System.Single x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.TimeSpan))
            {
                return new TryFormat<System.TimeSpan>((System.TimeSpan x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.UInt16))
            {
                return new TryFormat<System.UInt16>((System.UInt16 x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.UInt32))
            {
                return new TryFormat<System.UInt32>((System.UInt32 x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }
            if (type == typeof(System.UInt64))
            {
                return new TryFormat<System.UInt64>((System.UInt64 x, Span<byte> dest, out int written, StandardFormat format) => Utf8Formatter.TryFormat(x, dest, out written, format));
            }

            return null;
        }
    }
}