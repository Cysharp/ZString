using System;

namespace Cysharp.Text
{
    // Currently, this class is internals.
    internal class NestedStringBuilderCreationException : InvalidOperationException
    {
        internal protected NestedStringBuilderCreationException(string typeName, string extraMessage = "")
            : base($"A nested call with `notNested: true`, or Either You forgot to call {typeName}.Dispose() of  in the past.{extraMessage}")
        {
        }

        internal protected NestedStringBuilderCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
