using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cysharp.Text
{
    /// <summary>
    /// A <see cref="TextWriter"/> implementation that is backed with <see cref="Utf16ValueStringBuilder"/>.
    /// </summary>
    /// <remarks>
    /// It's important to make sure the writer is always properly disposed.
    /// </remarks>
    public sealed class ZStringWriter : TextWriter
    {
        private Utf16ValueStringBuilder sb;
        private bool isOpen;
        private UnicodeEncoding encoding;

        /// <summary>
        /// Creates a new instance using <see cref="CultureInfo.CurrentCulture"/> as format provider.
        /// </summary>
        public ZStringWriter() : this(CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        /// Creates a new instance with given format provider.
        /// </summary>
        public ZStringWriter(IFormatProvider formatProvider) : base(formatProvider)
        {
            sb = ZString.CreateStringBuilder();
            isOpen = true;
        }

        /// <summary>
        /// Disposes this instance, operations are no longer allowed.
        /// </summary>
        public override void Close()
        {
            Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            sb.Dispose();
            isOpen = false;
            base.Dispose(disposing);
        }

        public override Encoding Encoding => encoding = encoding ?? new UnicodeEncoding(false, false);

        public override void Write(char value)
        {
            AssertNotDisposed();

            sb.Append(value);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (buffer.Length - index < count)
            {
                throw new ArgumentException();
            }
            AssertNotDisposed();

            sb.Append(buffer.AsSpan(index, count));
        }

        public override void Write(string value)
        {
            AssertNotDisposed();

            if (value != null)
            {
                sb.Append(value);
            }
        }

        public override Task WriteAsync(char value)
        {
            Write(value);
            return Task.CompletedTask;
        }

        public override Task WriteAsync(string value)
        {
            Write(value);
            return Task.CompletedTask;
        }

        public override Task WriteAsync(char[] buffer, int index, int count)
        {
            Write(buffer, index, count);
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(char value)
        {
            WriteLine(value);
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(string value)
        {
            WriteLine(value);
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(char[] buffer, int index, int count)
        {
            WriteLine(buffer, index, count);
            return Task.CompletedTask;
        }

        public override void Write(bool value)
        {
            AssertNotDisposed();
            sb.Append(value);
        }

        public override void Write(decimal value)
        {
            AssertNotDisposed();
            sb.Append(value);
        }

        /// <summary>
        /// No-op.
        /// </summary>
        public override Task FlushAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Materializes the current state from underlying string builder.
        /// </summary>
        public override string ToString()
        {
            return sb.ToString();
        }

#if !NETSTANDARD2_0
#if !UNITY_2018_3_OR_NEWER

        public override void Write(ReadOnlySpan<char> buffer)
        {
            AssertNotDisposed();

            sb.Append(buffer);
        }

        public override void WriteLine(ReadOnlySpan<char> buffer)
        {
            AssertNotDisposed();

            sb.Append(buffer);
            WriteLine();
        }

        public override Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return Task.FromCanceled(cancellationToken);
            }

            Write(buffer.Span);
            return Task.CompletedTask;
        }

        public override Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return Task.FromCanceled(cancellationToken);
            }

            WriteLine(buffer.Span);
            return Task.CompletedTask;
        }
#endif
#endif

        private void AssertNotDisposed()
        {
            if (!isOpen)
            {
                throw new ObjectDisposedException(nameof(sb));
            }
        }
    }
}
