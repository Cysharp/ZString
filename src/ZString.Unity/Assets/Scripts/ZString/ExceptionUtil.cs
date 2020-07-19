using System;
using System.Collections.Generic;
using System.Text;

namespace Cysharp.Text
{
    internal static class ExceptionUtil
    {
        internal static void ThrowArgumentException(string paramName)
        {
            throw new ArgumentException("Can't format argument.", paramName);
        }

        internal static void ThrowFormatException()
        {
            throw new FormatException("Index (zero based) must be greater than or equal to zero and less than the size of the argument list.");
        }

        internal static void ThrowFormatError()
        {
            throw new FormatException("Input string was not in a correct format.");
        }
    }
}
