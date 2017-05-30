using System.Text;
using LibP2P.Utilities.Extensions;
using Multiformats.Hash;
using Multiformats.Hash.Algorithms;
using Xunit;

namespace LibP2P.Utilities.Tests
{
    public class MultihashTests
    {
        [Fact]
        public void Compare_GivenEqualHashes_ReturnsZero()
        {
            var mh1 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello world"));
            var mh2 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello world"));

            Assert.Equal(mh1.Compare(mh2), 0);
        }

        [Fact]
        public void Compare_GivenNonEqualHashes_ReturnsOneOrMinusOne()
        {
            var mh1 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello world"));
            var mh2 = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes("hello_world!"));

            Assert.NotEqual(mh1.Compare(mh2), 0);
        }
    }
}
