using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace System
{
    internal static class NumberFormatInfoEx
    {
        internal static bool HasInvariantNumberSigns(this NumberFormatInfo info)
        {
            return info.PositiveSign == "+" && info.NegativeSign == "-";
        }
    }
}
