using System.Net;
using LibP2P.Utilities.Extensions;
using Multiformats.Address;
using Multiformats.Address.Protocols;
using Xunit;

namespace LibP2P.Utilities.Tests
{
    public class MultiaddressTests
    {
        [Fact]
        public void IsIPLoopback_GivenIP4LoopbackAddress_ReturnsTrue()
        {
            var maddr = new Multiaddress().Add<IP4>(IPAddress.Loopback);

            Assert.True(maddr.IsIPLoopback());
        }

        [Fact]
        public void IsIPLoopback_GivenIP6LoopbackAddress_ReturnsTrue()
        {
            var maddr = new Multiaddress().Add<IP6>(IPAddress.IPv6Loopback);

            Assert.True(maddr.IsIPLoopback());
        }

        [Fact]
        public void IsIPLoopback_GivenIP4NoLoopbackAddress_ReturnsFalse()
        {
            var maddr = new Multiaddress().Add<IP4>(IPAddress.Parse("192.168.0.1"));

            Assert.False(maddr.IsIPLoopback());
        }

        [Fact]
        public void IsIPLoopback_GivenIP6NoLoopbackAddress_ReturnsFalse()
        {
            var maddr = new Multiaddress().Add<IP6>(IPAddress.Parse("fe80::5066:4785:4a2:a9b7"));

            Assert.False(maddr.IsIPLoopback());
        }

        [Fact]
        public void IsIPLookback_GivenNoIPAddress_ReturnsFalse()
        {
            var maddr = new Multiaddress();

            Assert.False(maddr.IsIPLoopback());
        }

        [Fact]
        public void IsFDCostlyTransport_GivenTcp_ReturnsTrue()
        {
            var maddr = new Multiaddress().Add<TCP>((ushort)1024);

            Assert.True(maddr.IsFDCostlyTransport());
        }

        [Fact]
        public void IsFDCostlyTransport_GivenHTTP_ReturnsFalse()
        {
            var maddr = new Multiaddress().Add<HTTP>();

            Assert.False(maddr.IsFDCostlyTransport());
        }

        [Fact]
        public void IsFDCostlyTransport_GivenEmptyAddress_ReturnsFalse()
        {
            var maddr = new Multiaddress();

            Assert.False(maddr.IsFDCostlyTransport());
        }
    }
}
