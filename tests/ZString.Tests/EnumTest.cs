using Cysharp.Text;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public enum DuplicateEnum
    {
        A = 1,
        B = 2,
        BB = 2,
        C = 3
    }

    public enum StandardEnum
    {
        Abc = 1,
        Def = 2,
        Ghi = 3,
    }

    [Flags]
    public enum FlagsEnum
    {
        None = 0,
        Abc = 1,
        Bcd = 2,
        Efg = 4,
    }

    public class EnumTest
    {
        [Fact]
        public void Duplicate()
        {
            ZString.Format("{0}", DuplicateEnum.A).Should().Be("A");
            ZString.Format("{0}", DuplicateEnum.B).Should().Be("B");
            ZString.Format("{0}", DuplicateEnum.BB).Should().Be("B");
            ZString.Format("{0}", DuplicateEnum.C).Should().Be("C");
            Utf8(DuplicateEnum.A);
            Utf8(DuplicateEnum.B);
            Utf8(DuplicateEnum.BB);
            Utf8(DuplicateEnum.C);
        }

        [Fact]
        public void Standard()
        {
            ZString.Format("{0}", StandardEnum.Abc).Should().Be("Abc");
            ZString.Format("{0}", StandardEnum.Def).Should().Be("Def");
            ZString.Format("{0}", StandardEnum.Ghi).Should().Be("Ghi");
            Utf8(StandardEnum.Abc);
            Utf8(StandardEnum.Def);
            Utf8(StandardEnum.Ghi);
        }

        [Fact]
        public void Flags()
        {
            ZString.Format("{0}", FlagsEnum.Abc | FlagsEnum.Bcd).Should().Be("Abc, Bcd");
            ZString.Format("{0}", FlagsEnum.None).Should().Be("None");
            ZString.Format("{0}", FlagsEnum.Efg).Should().Be("Efg");
            Utf8(FlagsEnum.Abc | FlagsEnum.Bcd);
            Utf8(FlagsEnum.None);
            Utf8(FlagsEnum.Efg);
        }

        static void Utf8<T>(T e) where T : Enum
        {
            var s = ZString.CreateUtf8StringBuilder();
            s.AppendFormat("{0}", e);
            s.AsSpan().SequenceEqual(Encoding.UTF8.GetBytes(e.ToString())).Should().BeTrue();
        }
    }
}
