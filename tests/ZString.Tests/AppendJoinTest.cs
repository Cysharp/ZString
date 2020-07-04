using Cysharp.Text;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class AppendJoinTest
    {
#if NETCOREAPP || NETSTANDARD2_1
        [Fact]
        public void JoinOverloads()
        {
            var zsb = ZString.CreateStringBuilder();
            var bcl = new StringBuilder();
            zsb.Append("Foo:");
            bcl.Append("Foo:");

            zsb.AppendJoin("_,_", 0);  // params
            bcl.AppendJoin("_,_", 0);  // params
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", 0, 1);  // params
            bcl.AppendJoin("_,_", 0, 1);  // params
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", new string[0]);
            bcl.AppendJoin("_,_", new string[0]);
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", new[] { 1, 2, 3 });
            bcl.AppendJoin("_,_", new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", new string[] { }.AsEnumerable());
            bcl.AppendJoin("_,_", new string[] { }.AsEnumerable());
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", new[] { 1, 2, 3 }.AsEnumerable());
            bcl.AppendJoin("_,_", new[] { 1, 2, 3 }.AsEnumerable());
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', new string[0]);
            bcl.AppendJoin(',', new string[0]);
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', new[] { 1, 2, 3 });
            bcl.AppendJoin(',', new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', new string[0].AsEnumerable());
            bcl.AppendJoin(',', new string[0].AsEnumerable());
            zsb.ToString().Should().Be(bcl.ToString());
        }

        [Fact]
        public void JoinOverloads2()
        {
            var zsb = ZString.CreateStringBuilder();
            var bcl = new StringBuilder();
            zsb.Append("Foo:");
            bcl.Append("Foo:");

            zsb.AppendJoin("_,_", new string[] { }.ToList());
            bcl.AppendJoin("_,_", new string[] { }.ToList());
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", new[] { 1, 2, 3 }.ToList());
            bcl.AppendJoin("_,_", new[] { 1, 2, 3 }.ToList());
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (IList<int>)new int[] { });
            bcl.AppendJoin("_,_", (IList<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (IList<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin("_,_", (IList<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (IReadOnlyList<int>)new int[] { });
            bcl.AppendJoin("_,_", (IReadOnlyList<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (IReadOnlyList<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin("_,_", (IReadOnlyList<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (ICollection<int>)new int[] { });
            bcl.AppendJoin("_,_", (ICollection<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (ICollection<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin("_,_", (ICollection<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (IReadOnlyCollection<int>)new int[] { });
            bcl.AppendJoin("_,_", (IReadOnlyCollection<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin("_,_", (IReadOnlyCollection<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin("_,_", (IReadOnlyCollection<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());
        }

        [Fact]
        public void JoinOverloads3()
        {
            var zsb = ZString.CreateStringBuilder();
            var bcl = new StringBuilder();
            zsb.Append("Foo:");
            bcl.Append("Foo:");

            zsb.AppendJoin(',', new string[] { }.ToList());
            bcl.AppendJoin(',', new string[] { }.ToList());
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', new[] { 1, 2, 3 }.ToList());
            bcl.AppendJoin(',', new[] { 1, 2, 3 }.ToList());
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (IList<int>)new int[] { });
            bcl.AppendJoin(',', (IList<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (IList<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin(',', (IList<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (IReadOnlyList<int>)new int[] { });
            bcl.AppendJoin(',', (IReadOnlyList<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (IReadOnlyList<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin(',', (IReadOnlyList<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (ICollection<int>)new int[] { });
            bcl.AppendJoin(',', (ICollection<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (ICollection<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin(',', (ICollection<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (IReadOnlyCollection<int>)new int[] { });
            bcl.AppendJoin(',', (IReadOnlyCollection<int>)new int[] { });
            zsb.ToString().Should().Be(bcl.ToString());

            zsb.AppendJoin(',', (IReadOnlyCollection<int>)new[] { 1, 2, 3 });
            bcl.AppendJoin(',', (IReadOnlyCollection<int>)new[] { 1, 2, 3 });
            zsb.ToString().Should().Be(bcl.ToString());
        }

        [Fact]
        public void JoinStrings()
        {
            var values = new string[] { "abc", null, "def" };
            {
                const char sep = ',';
                var zsb = ZString.CreateStringBuilder();
                var bcl = new StringBuilder();

                zsb.AppendJoin(sep, "Foo:");
                bcl.AppendJoin(sep, "Foo:");

                zsb.AppendJoin(sep, new ReadOnlySpan<string>(values));
                bcl.AppendJoin(sep, values);

                zsb.AppendJoin(sep, values);
                bcl.AppendJoin(sep, values);

                zsb.AppendJoin(sep, values.ToList());
                bcl.AppendJoin(sep, values.ToList());

                zsb.AppendJoin(sep, values.AsEnumerable());
                bcl.AppendJoin(sep, values.AsEnumerable());

                zsb.AppendLine();
                bcl.AppendLine();
                zsb.ToString().Should().Be(bcl.ToString());
            }

            {
                const string sep = "_,_";
                var zsb = ZString.CreateStringBuilder();
                var bcl = new StringBuilder();

                zsb.AppendJoin(sep, "Foo:");
                bcl.AppendJoin(sep, "Foo:");

                zsb.AppendJoin(sep, new ReadOnlySpan<string>(values));
                bcl.AppendJoin(sep, values);

                zsb.AppendJoin(sep, values);
                bcl.AppendJoin(sep, values);

                zsb.AppendJoin(sep, values.ToList());
                bcl.AppendJoin(sep, values.ToList());

                zsb.AppendJoin(sep, values.AsEnumerable());
                bcl.AppendJoin(sep, values.AsEnumerable());

                zsb.AppendLine();
                bcl.AppendLine();
                zsb.ToString().Should().Be(bcl.ToString());
            }
        }
    }
#endif
}
