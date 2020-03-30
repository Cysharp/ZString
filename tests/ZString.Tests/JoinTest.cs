using Cysharp.Text;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class JoinTest
    {
        [Fact]
        public void JoinOverloads()
        {
            ZString.Join("_,_", new string[0]).Should().Be(string.Join("_,_", new string[0]));
            ZString.Join("_,_", new[] { 1 }).Should().Be(string.Join("_,_", new[] { 1 }));
            ZString.Join("_,_", new[] { 1, 2 }).Should().Be(string.Join("_,_", new[] { 1, 2 }));
            ZString.Join("_,_", new[] { 1, 2, 3 }).Should().Be(string.Join("_,_", new[] { 1, 2, 3 }));

            ZString.Join("_,_", new string[] { }.AsEnumerable()).Should().Be(string.Join("_,_", new string[0]));
            ZString.Join("_,_", new[] { 1 }.AsEnumerable()).Should().Be(string.Join("_,_", new[] { 1 }));
            ZString.Join("_,_", new[] { 1, 2 }.AsEnumerable()).Should().Be(string.Join("_,_", new[] { 1, 2 }));
            ZString.Join("_,_", new[] { 1, 2, 3 }.AsEnumerable()).Should().Be(string.Join("_,_", new[] { 1, 2, 3 }));

            ZString.Join(',', new string[0]).Should().Be(string.Join(",", new string[0]));
            ZString.Join(',', new[] { 1 }).Should().Be(string.Join(",", new[] { 1 }));
            ZString.Join(',', new[] { 1, 2 }).Should().Be(string.Join(",", new[] { 1, 2 }));
            ZString.Join(',', new[] { 1, 2, 3 }).Should().Be(string.Join(",", new[] { 1, 2, 3 }));

            ZString.Join(',', new string[0].AsEnumerable()).Should().Be(string.Join(",", new string[0]));
            ZString.Join(',', new[] { 1 }.AsEnumerable()).Should().Be(string.Join(",", new[] { 1 }));
            ZString.Join(',', new[] { 1, 2 }.AsEnumerable()).Should().Be(string.Join(",", new[] { 1, 2 }));
            ZString.Join(',', new[] { 1, 2, 3 }.AsEnumerable()).Should().Be(string.Join(",", new[] { 1, 2, 3 }));
        }

        [Fact]
        public void JoinOverloads2()
        {
            ZString.Join("_,_", new string[] { }.ToList()).Should().Be(string.Join("_,_", new string[0]));
            ZString.Join("_,_", new[] { 1 }.ToList()).Should().Be(string.Join("_,_", new[] { 1 }));
            ZString.Join("_,_", new[] { 1, 2 }.ToList()).Should().Be(string.Join("_,_", new[] { 1, 2 }));
            ZString.Join("_,_", new[] { 1, 2, 3 }.ToList()).Should().Be(string.Join("_,_", new[] { 1, 2, 3 }));

            ZString.Join("_,_", (IList<int>)new int[] { }).Should().Be(string.Join("_,_", new string[0]));
            ZString.Join("_,_", (IList<int>)new[] { 1 }).Should().Be(string.Join("_,_", new[] { 1 }));
            ZString.Join("_,_", (IList<int>)new[] { 1, 2 }).Should().Be(string.Join("_,_", new[] { 1, 2 }));
            ZString.Join("_,_", (IList<int>)new[] { 1, 2, 3 }).Should().Be(string.Join("_,_", new[] { 1, 2, 3 }));

            ZString.Join("_,_", (IReadOnlyList<int>)new int[] { }).Should().Be(string.Join("_,_", new string[0]));
            ZString.Join("_,_", (IReadOnlyList<int>)new[] { 1 }).Should().Be(string.Join("_,_", new[] { 1 }));
            ZString.Join("_,_", (IReadOnlyList<int>)new[] { 1, 2 }).Should().Be(string.Join("_,_", new[] { 1, 2 }));
            ZString.Join("_,_", (IReadOnlyList<int>)new[] { 1, 2, 3 }).Should().Be(string.Join("_,_", new[] { 1, 2, 3 }));

            ZString.Join("_,_", (ICollection<int>)new int[] { }).Should().Be(string.Join("_,_", new string[0]));
            ZString.Join("_,_", (ICollection<int>)new[] { 1 }).Should().Be(string.Join("_,_", new[] { 1 }));
            ZString.Join("_,_", (ICollection<int>)new[] { 1, 2 }).Should().Be(string.Join("_,_", new[] { 1, 2 }));
            ZString.Join("_,_", (ICollection<int>)new[] { 1, 2, 3 }).Should().Be(string.Join("_,_", new[] { 1, 2, 3 }));

            ZString.Join("_,_", (IReadOnlyCollection<int>)new int[] { }).Should().Be(string.Join("_,_", new string[0]));
            ZString.Join("_,_", (IReadOnlyCollection<int>)new[] { 1 }).Should().Be(string.Join("_,_", new[] { 1 }));
            ZString.Join("_,_", (IReadOnlyCollection<int>)new[] { 1, 2 }).Should().Be(string.Join("_,_", new[] { 1, 2 }));
            ZString.Join("_,_", (IReadOnlyCollection<int>)new[] { 1, 2, 3 }).Should().Be(string.Join("_,_", new[] { 1, 2, 3 }));
        }

        [Fact]
        public void CooncatNullTest()
        {
            var str = ZString.Concat(default(string), "foo", "bar");
            str.Should().Be(string.Concat(default(string), "foo", "bar"));
        }
    }
}
