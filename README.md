ZString
===
[![CircleCI](https://circleci.com/gh/Cysharp/ZString.svg?style=svg)](https://circleci.com/gh/Cysharp/ZString)

WIP

**Z**ero alloction **String**Builder for .NET Core and Unity.

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
