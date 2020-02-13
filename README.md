ZString
===
[![CircleCI](https://circleci.com/gh/Cysharp/ZString.svg?style=svg)](https://circleci.com/gh/Cysharp/ZString)

**Z**ero Allocation **String**Builder for .NET Core and Unity.

* Struct StringBuilder to avoid allocation of builder itself
* Rent write buffer from `ThreadStatic` or `ArrayPool`
* All append methods are generics(`Append<T>(T value)`) and write to buffer directly instead of concatenate `value.ToString`
* `T0`~`T15` AppendFormat(`AppendFormat<T0,...,T15>(string format, T0 arg0, ..., T15 arg15)` avoids boxing of stuct argument
* Also `T0`~`T15` Concat(`Concat<T0,...,T15>(T0 arg0, ..., T15 arg15)`) avoid boxing and `value.ToString` allocation
* Convinient `ZString.Format/Concat/Join` methods can replace instead of `String.Format/Concat/Join`
* Can use inner buffer to avoid allocate final string
* Can build both Utf16(`Span<char>`) and Utf8(`Span<byte>`) directly

// ここに性能比較の画像を貼る

// ここに普通のは何で遅いかの理由を書いておく

Getting Started
---
For .NET Core, use NuGet.

> PM> Install-Package [ZString](https://www.nuget.org/packages/ZString)

For Unity, check the [releases](https://github.com/Cysharp/ZString/releases) page, download `ZString.Unity.unitypackage`.

```csharp
async void Example(int x, int y, int z)
{
    // same as x + y + z
    _ = ZString.Concat(x, y, z);

    // also can use numeric format strings
    _ = ZString.Format("x:{0}, y:{1:000}, z:{2:P}",x, y, z);

    _ = ZString.Join(',', x, y, z);

    // for Unity, direct write(avoid string allocation completely) to TextMeshPro
    tmp.SetTextFormat("Position: {0}, {1}, {2}", x, y, z);

    // create StringBuilder
    using(var sb = ZString.CreateStringBuilder())
    {
        sb.Append("foo");
        sb.AppendLine(42);
        sb.AppendFormat("{0} {1:.###}", "bar", 123.456789);
        sb.Concat(1, "foo", 100, "bar");

        // and build final string
        var str = sb.ToString();

        // for Unity, direct write to TextMeshPro
        tmp.SetText(sb);

        // write to destination buffer
        sb.TryCopyTo(dest, out var written);
    }

    // C# 8.0, Using declarations
    // create Utf8 StringBuilder that build Utf8 directly to avoid encoding
    using var sb2 = ZString.CreateUtf8StringBuilder();

    sb2.Concat("foo:", x, ", bar:", y);

    // directly write to steam or dest to avoid allocation
    await sb2.CopyToAsync(stream);
    sb2.TryCopyTo(dest, out var written);
}
```

Reference
---
ZString

| method | returns | description |
| -- | -- | -- |
| CreateStringBuilder | Utf16ValueStringBuilder | Create Utf16 string StringBuilder |
| CreateStringBuilder(bool notNested) | Utf16ValueStringBuilder | Create Utf16 string StringBuilder, when true uses thread-static buffer that is faster but must return immediately. |
| CreateUtf8StringBuilder | Utf8ValueStringBuilder | Create Utf8(`Span<byte>`) StringBuilder |
| CreateUtf8StringBuilder(bool notNested) | Utf8ValueStringBuilder | Create Utf8(`Span<byte>`) StringBuilder, when true uses thread-static buffer that is faster but must return immediately. |


| Join | Utf8ValueStringBuilder | Create Utf8(`Span<byte>`) StringBuilder, when true uses thread-static buffer that is faster but must return immediately. |






SetTextFormat is extension method of `TMP_Text`, there parameter is generics so can avoid boxing, and ZString writes to buffer directly without any ToString allocation. Finally inner buffer copy to `TextMeshPro` buffer so avoid all string allocations.

```csharp
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


License
---
This library is licensed under the the MIT License.

.NET Standard 2.0 and Unity version borrows [dotnet/runtime](https://github.com/dotnet/runtime) conversion methods, there exists under `ZString/Number` directory.