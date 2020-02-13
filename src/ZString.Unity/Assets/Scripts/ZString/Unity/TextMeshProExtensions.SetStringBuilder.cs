using System;
using TMPro;

namespace Cysharp.Text
{
    public static partial class TextMeshProExtensions
    {
        public static void SetText(this TMP_Text text, Utf16ValueStringBuilder stringBuilder)
        {
            var array = stringBuilder.AsArraySegment();
            text.SetCharArray(array.Array, array.Offset, array.Count);
        }
    }
}
