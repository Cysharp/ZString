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
    }
}
