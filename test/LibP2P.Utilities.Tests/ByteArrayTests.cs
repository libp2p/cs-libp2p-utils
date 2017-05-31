using System;
using System.Text;
using LibP2P.Utilities.Extensions;
using Xunit;

namespace LibP2P.Utilities.Tests
{
    public class ByteArrayTests
    {
        [Fact]
        public void Append_GivenArrayWithTwoBytes_ReturnsArrayWithFourBytes()
        {
            var array = new byte[] {0, 1};
            var result = array.Append(new byte[] {2, 3});

            Assert.Equal(result, new byte[] {0,1,2,3});
        }

        [Fact]
        public void Compare_GivenEqualArrays_ReturnsZero()
        {
            var a = new byte[] {0, 1, 2, 3, 4, 5};
            var b = new byte[] {0, 1, 2, 3, 4, 5};

            Assert.Equal(a.Compare(b), 0);
        }

        [Fact]
        public void Compare_GivenOneLargerArray_ReturnsMinusOne()
        {
            var a = new byte[] { 0, 1, 2, 3, 4, 5 };
            var b = new byte[] { 0, 1, 2, 3, 4, 5, 6 };

            Assert.Equal(a.Compare(b), -1);
        }

        [Fact]
        public void Compare_GivenOneSmallerArray_ReturnsOne()
        {
            var a = new byte[] { 0, 1, 2, 3, 4, 5, 6 };
            var b = new byte[] { 0, 1, 2, 3, 4, 5 };

            Assert.Equal(a.Compare(b), 1);
        }

        [Fact]
        public void Compare_GivenTwoEquallyLongArraysButOneWithHigherContent_ReturnsMinusOne()
        {
            var a = new byte[] { 0, 1, 2, 3, 4, 5 };
            var b = new byte[] { 6, 7, 8, 9, 0, 1 };

            Assert.Equal(a.Compare(b), -1);
        }

        [Fact]
        public void Compare_GivenTwoEquallyLongArraysButOneWithLowerContent_ReturnsOne()
        {
            var a = new byte[] { 6, 7, 8, 9, 0, 1 };
            var b = new byte[] { 0, 1, 2, 3, 4, 5 };

            Assert.Equal(a.Compare(b), 1);
        }

        [Fact]
        public void Xor_GivenTwoEqualArrays_ReturnsAllZero()
        {
            var a = new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var b = new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            Assert.Equal(a.XOR(b), new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }

        [Fact]
        public void ComputeHash_GivenBytes_ReturnsValidSha256Digest()
        {
            var digest = Encoding.UTF8.GetBytes("hello world").ComputeHash();

            Assert.Equal(digest, Convert.FromBase64String("uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek="));
        }
    }
}
