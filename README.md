ZString
===
[![CircleCI](https://circleci.com/gh/Cysharp/ZString.svg?style=svg)](https://circleci.com/gh/Cysharp/ZString)

**Z**ero Allocation **String**Builder for .NET Core and Unity.

Currently Preview Release, -0.1.0.

Getting Started(Unity, with TextMeshPro)
---
Check the [releases](https://github.com/Cysharp/ZString/releases) page, download `ZString.Unity.unitypackage`.

```csharp
TextMeshProUGUI text; // TMP_Text
int count = 0;

void Update()
{
    label.SetTextFormat("Damage: {0}", count++);
}
```

SetTextFormat is extension method of `TMP_Text`, there parameter is generics so can avoid boxing, and ZString writes to buffer directly without any ToString allocation. Finally inner buffer copy to `TextMeshPro` buffer so avoid all string allocations.

```
public static void SetTextFormat<T0>(this TMP_Text text, string format, T0 arg0)
public static void SetTextFormat<T0, T1>(this TMP_Text text, string format, T0 arg0, T1 arg1)
// ...
public static void SetTextFormat<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this TMP_Text text, string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
```

Raw API is start from `ZString.CreateStringBuilder();`.

```csharp
using(var sb = ZString.CreateStringBuilder())
{
    sb.Append("foo");
    sb.AppendLine(42);
    sb.AppendFormat("{0} {1}", "bar", 123.456);
    sb.AppendMany(1, "foo", 100, "bar");

    Debug.Log(sb.ToString());
}

// If you want to use only format, use `ZString.Format` instead of `String.Format`.
var str = ZString.Format("foo {0} bar {1}", 42, 123.456);
```

Getting Started(.NET Core)
---

> PM> Install-Package [ZString](https://www.nuget.org/packages/ZString)

```csharp
using var sb = ZString.CreateStringBuilder();

sb.AppendLine("foo");
sb.AppendLine(42);
sb.AppendLine("bar");
sb.AppendLine(123.456);

Console.WriteLine(sb.ToString());

// format, shortform
var str = ZString.Format("foo {0} bar {1}", 42, 123.456);
```

```csharp
// write to Utf8 directly
using var sb = ZString.CreateUtf8StringBuilder();

sb.AppendLine("foo");
sb.AppendLine(42);
sb.AppendLine("bar");
sb.AppendLine(123.456);

await sb.CopyToAsync(stream);
```

License
---
This library is under the MIT License.
