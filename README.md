ZString
===
[![CircleCI](https://circleci.com/gh/Cysharp/ZString.svg?style=svg)](https://circleci.com/gh/Cysharp/ZString)

**Z**ero Allocation **String**Builder for .NET Core and Unity.

* Struct StringBuilder to avoid allocation of builder itself
* Rent write buffer from `ThreadStatic` or `ArrayPool`
* All append methods are generics(`Append<T>(T value)`) and write to buffer directly instead of concatenate `value.ToString`
* `T0`~`T15` AppendFormat(`AppendFormat<T0,...,T15>(string format, T0 arg0, ..., T15 arg15)` avoids boxing of struct argument
* Also `T0`~`T15` Concat(`Concat<T0,...,T15>(T0 arg0, ..., T15 arg15)`) avoid boxing and `value.ToString` allocation
* Convinient `ZString.Format/Concat/Join` methods can replace instead of `String.Format/Concat/Join`
* Can build both Utf16(`Span<char>`) and Utf8(`Span<byte>`) directly
* Can use inner buffer to avoid allocate final string
* Integrated with Unity TextMeshPro to avoid string allocation

![image](https://user-images.githubusercontent.com/46207/74473217-9061e200-4ee6-11ea-9a77-14d740886faa.png)

This graph compares following codes.

* `"x:" + x + " y:" + y + " z:" + z`
* `ZString.Concat("x:", x, " y:", y, " z:", z)`
* `string.Format("x:{0} y:{1} z:{2}", x, y, z)`
* `ZString.Format("x:{0} y:{1} z:{2}", x, y, z)`
* `new StringBuilder(), Append(), .ToString()`
* `ZString.CreateStringBuilder(), Append(), .ToString()`

`"x:" + x + " y:" + y + " z:" + z` is converted to `String.Concat(new []{ "x:", x.ToString(), " y:", y.ToString(), " z:", z.ToString() })` by C# compiler. It has each `.ToString` allocation and params array allocation. `string.Format` calls `String.Format(string, object, object, object)` so each arguments causes int -> object boxing.

All `ZString` methods only allocate final string. Also, `ZString` has enabled to access inner buffer so if output target has stringless api(like Unity TextMeshPro's `SetCharArray`), you can achieve completely zero allocation.

The blog post of detailed explanation by author: [medium@neuecc/ZString](https://medium.com/@neuecc/zstring-zero-allocation-stringbuilder-for-net-core-and-unity-f3163c88c887)

Getting Started
---
For .NET Core, use NuGet.

> PM> Install-Package [ZString](https://www.nuget.org/packages/ZString)

For Unity, check the [releases](https://github.com/Cysharp/ZString/releases) page, download `ZString.Unity.unitypackage`.

```csharp
using Cysharp.Text; // namespace

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
    await sb2.WriteToAsync(stream);
    sb2.TryCopyTo(dest, out var written);
}
```

Reference
---
**static class ZString**

| method | returns | description |
| -- | -- | -- |
| CreateStringBuilder() | Utf16ValueStringBuilder | Create the Utf16 string StringBuilder. |
| CreateStringBuilder(bool notNested) | Utf16ValueStringBuilder | Create the Utf16 string StringBuilder, when true uses thread-static buffer that is faster but must return immediately. |
| CreateUtf8StringBuilder() | Utf8ValueStringBuilder | Create the Utf8(`Span<byte>`) StringBuilder. |
| CreateUtf8StringBuilder(bool notNested) | Utf8ValueStringBuilder | Create the Utf8(`Span<byte>`) StringBuilder, when true uses thread-static buffer that is faster but must return immediately. |
| `Join(char/string, T[]/IE<T>)` | string | Concatenates the elements of an array, using the specified seperator between each element. |
| `Concat<T0,..,T15>(T0,..,T15)` | string | Concatenates the string representation of some specified values. |
| `Format<T0,..,T15>(string, T0,..,T15)` | string | Replaces one or more format items in a string with the string representation of some specified values. |

**struct Utf16ValueStringBuilder : `IBufferWriter<char>`, IDisposable**

| method | returns | description |
| -- | -- | -- |
| Length | int | Length of written buffer. |
| AsSpan() | `ReadOnlySpan<char>` | Get the written buffer data. |
| AsMemory() | `ReadOnlyMemory<char>` | Get the written buffer data. |
| AsArraySegment() | `ArraySegment<char>` | Get the written buffer data. |
| Dispose() | void | Return the inner buffer to pool. |
| `Append<T>(T value)` | void | Appends the string representation of a specified value to this instance. |
| `Append<T>(T value, string format)` | void | Appends the string representation of a specified value to this instance with numeric format strings. |
| `AppendLine()` | void | Appends the default line terminator to the end of this instance. |
| `AppendLine<T>(T value)` | void | Appends the string representation of a specified value followed by the default line terminator to the end of this instance. |
| `AppendLine<T>(T value, string format)` | void | Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance. |
| `AppendFormat<T0,..,T15>(string, T0,..,T15)` | void | Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments. |
| `TryCopyTo(Span<char>, out int)` | bool | Copy inner buffer to the destination span. |
| ToString() | string | Converts the value of this instance to a System.String. |
| GetMemory(int sizeHint) | `Memory<char>` | IBufferWriter.GetMemory. |
| GetSpan(int sizeHint) | `Span<char>` | IBufferWriter.GetSpan. |
| Advance(int count) | void | IBufferWriter.Advance. |
| static `RegisterTryFormat<T>(TryFormat<T>)` | void | Register custom formatter. |

**struct Utf8ValueStringBuilder : `IBufferWriter<byte>`, IDisposable**

| method | returns | description |
| -- | -- | -- |
| Length | int | Length of written buffer. |
| AsSpan() | `ReadOnlySpan<char>` | Get the written buffer data. |
| AsMemory() | `ReadOnlyMemory<char>` | Get the written buffer data. |
| AsArraySegment() | `ArraySegment<char>` | Get the written buffer data. |
| Dispose() | void | Return the inner buffer to pool. |
| `Append<T>(T value)` | void | Appends the string representation of a specified value to this instance. |
| `Append<T>(T value, StandardFormat format)` | void | Appends the string representation of a specified value to this instance with numeric format strings. |
| `AppendLine()` | void | Appends the default line terminator to the end of this instance. |
| `AppendLine<T>(T value)` | void | Appends the string representation of a specified value followed by the default line terminator to the end of this instance. |
| `AppendLine<T>(T value, StandardFormat format)` | void | Appends the string representation of a specified value with numeric format strings followed by the default line terminator to the end of this instance. |
| `AppendFormat<T0,..,T15>(string, T0,..,T15)` | void | Appends the string returned by processing a composite format string, each format item is replaced by the string representation of arguments. |
| `TryCopyTo(Span<byte>, out int)` | bool | Copy inner buffer to the destination span. |
| WriteToAsync(Stream stream) | Task | Write inner buffer to stream. |
| ToString() | string | Encode the innner utf8 buffer to a System.String. |
| GetMemory(int sizeHint) | `Memory<char>` | IBufferWriter.GetMemory. |
| GetSpan(int sizeHint) | `Span<char>` | IBufferWriter.GetSpan. |
| Advance(int count) | void | IBufferWriter.Advance. |
| static `RegisterTryFormat<T>(TryFormat<T>)` | void | Register custom formatter. |

**static class TextMeshProExtensions**(Unity only)

| method | returns | description |
| -- | -- | -- |
| SetText(Utf16ValueStringBuilder) | void | Set inner buffer to text mesh pro directly to avoid string allocation. |
| `SetTextFormat<T0,..,T15>(string, T0,..,T15)` | void | Set formatted string without string allocation. |

Unity
---
In Unity, if you encount the following error 

```
The type 'Unsafe' exists in both 'System.Runtime.CompilerServices.Unsafe, Version=4.0.6.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' and 'System.Runtime.CompilerServices.Unsafe, Version=4.0.4.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
```

This is caused from dll conflict, for example `Unity Collections` package includes `System.Runtime.CompilerServices.Unsafe.dll` but ZString provides `System.Runtime.CompilerServices.Unsafe.dll` to `Plugins`.

Detail of issue in Unity Forum - [[Bug 1214643][2019.3.0f5] System.Runtime.CompilerServices.Unsafe clashes with imported dll](https://forum.unity.com/threads/bug-1214643-2019-3-0f5-system-runtime-compilerservices-unsafe-clashes-with-imported-dll.816426/)

Workround:
- Copy Collections from Library/PackageCache to %Project Folder%/Packages
- Remove CompilerServices.Unsafe dll from said folder

Advanced Tips
---
`ZString.CreateStringBuilder(notNested:true)` is a special optimized parameter that uses `ThreadStatic` buffer instead of rent from `ArrayPool`. It is slightly faster but can not use in nested.

```csharp
using(var sb = ZString.CreateStringBuilder(true))
{
    sb.Append("foo");

    using var sb2 = ZString.CreateStringBuilder(true); // NG, nested stringbuilder uses conflicted same buffer
    var str = ZString.Concat("x", 100); // NG, ZString.Concat/Join/Format uses threadstatic buffer
}
```

```csharp
// OK, return buffer immediately.
using(var sb = ZString.CreateStringBuilder(true))
{
    sb.Append("foo");
    return sb.ToString();
}
```

`ZString.CreateStringBuilder()` is same as `ZString.CreateStringBuilder(notNested:false)`.

---

In default, `SByte`, `Int16`, `Int32`, `Int64`, `Byte`, `UInt16`, `UInt32`, `UInt64`, `Single`, `Double`, `TimeSpan`, `DateTime`, `DateTimeOffset`, `Decimal`, `Guid`, `String`, `Char` are used there own formatter to avoid `.ToString()` allocation, write directly to buffer. If not exists there list type, used `.ToString()` and copy string data.

If you want to avoid to convert string in custom type, you can register your own formatter.

```csharp
Utf16ValueStringBuilder.RegisterTryFormat((MyStruct value, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format) =>
{
    // write value to destionation and set size to charsWritten.
    charsWritten = 0;
    return true;
});

Utf8ValueStringBuilder.RegisterTryFormat((MyStruct value, Span<byte> destination, out int written, StandardFormat format) =>
{
    written = 0;
    return true;
});
```

---

`CreateStringBuilder` and `CreateUtf8StringBuilder` must use with `using`. Because their builder rent 64K buffer from `ArrayPool`. If not return buffer, allocate 64K buffer when string builder is created.

---

`Utf8ValueStringBuilder` and `Utf16ValueStringBuilder` implements `IBufferWriter` so you can pass serializer(such as `JsonSerializer` of `System.Text.Json`). But be careful to boxing copy, `ValueStringBuilder` is mutable struct. For example,

```csharp
using var sb = ZString.CreateUtf8StringBuilder();
IBufferWriter<byte> boxed = sb;
var writer = new Utf8JsonWriter(boxed);
JsonSerializer.Serialize(writer, ....);

using var unboxed = (Utf8ValueStringBuilder)boxed;
var str = unboxed.ToString();
```

License
---
This library is licensed under the the MIT License.

.NET Standard 2.0 and Unity version borrows [dotnet/runtime](https://github.com/dotnet/runtime) conversion methods, there exists under `ZString/Number` directory.
