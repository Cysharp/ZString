using Cysharp.Text;
using FluentAssertions;
using FluentAssertions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ZStringTests
{
    public class NestedStringBuilder
    {
        [Fact]
        public void NotNestedUtf16()
        {
            using (_ = ZString.CreateStringBuilder(true))
            {
            }
            using (_ = ZString.CreateStringBuilder(false))
            {
                using (_ = ZString.CreateStringBuilder(true))
                {
                    using (_ = ZString.CreateStringBuilder(false))
                    {
                    }
                }
            }
        }

        [Fact]
        public void NestedUtf16()
        {
            using (_ = ZString.CreateStringBuilder(true))
            {
                using (_ = ZString.CreateStringBuilder(false))
                {
                    Assert.Throws<NestedStringBuilderCreationException>(() =>
                    {
                        using (_ = ZString.CreateStringBuilder(true))
                        {
                        }
                    }
                    );
                }
            }
        }

        [Fact]
        public void NotDisposedUtf16()
        {
            {
                _ = ZString.CreateStringBuilder(true);
            }
            {
                Assert.Throws<NestedStringBuilderCreationException>(() =>
                {
                    using (_ = ZString.CreateStringBuilder(true))
                    {
                    }
                }
                );
            }
            Utf16ValueStringBuilder.scratchBufferUsed.IsSameOrEqualTo(true);
            Utf16ValueStringBuilder.scratchBufferUsed = false;
        }

        [Fact]
        public void NotNestedUtf8()
        {
            using (_ = ZString.CreateUtf8StringBuilder(true))
            {
            }
            using (_ = ZString.CreateUtf8StringBuilder(false))
            {
                using (_ = ZString.CreateUtf8StringBuilder(true))
                {
                    using (_ = ZString.CreateUtf8StringBuilder(false))
                    {
                    }
                }
            }
        }

        [Fact]
        public void NestedUtf8()
        {
            using (_ = ZString.CreateUtf8StringBuilder(true))
            {
                using (_ = ZString.CreateUtf8StringBuilder(false))
                {
                    Assert.Throws<NestedStringBuilderCreationException>(() =>
                    {
                        using (_ = ZString.CreateUtf8StringBuilder(true))
                        {
                        }
                    }
                    );
                }
            }
        }

        [Fact]
        public void NotDisposedUtf8()
        {
            {
                _ = ZString.CreateUtf8StringBuilder(true);
            }
            {
                Assert.Throws<NestedStringBuilderCreationException>(() =>
                {
                    using (_ = ZString.CreateUtf8StringBuilder(true))
                    {
                    }
                }
                );
            }
            Utf8ValueStringBuilder.scratchBufferUsed.IsSameOrEqualTo(true);
            Utf8ValueStringBuilder.scratchBufferUsed = false;
        }

    }
}
