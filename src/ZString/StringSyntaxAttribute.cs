#if !NET7_0_OR_GREATER

namespace System.Diagnostics.CodeAnalysis
{
    // Polyfill: lets IDEs recognize composite format strings on targets older than .NET 7.
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal sealed class StringSyntaxAttribute : Attribute
    {
        public const string CompositeFormat = "CompositeFormat";

        public StringSyntaxAttribute(string syntax)
        {
            Syntax = syntax;
            Arguments = Array.Empty<object?>();
        }

        public string Syntax { get; }
        public object?[] Arguments { get; }
    }
}

#endif
