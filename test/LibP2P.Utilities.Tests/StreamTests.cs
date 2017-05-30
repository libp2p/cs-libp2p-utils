using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using LibP2P.Utilities.Extensions;
using Xunit;

namespace LibP2P.Utilities.Tests
{
    public class StreamTests
    {
        private static void GenerateRandomBytes(byte[] data)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }
        }

        [Fact]
        public void AsReader_GivenMemoryStream_CanReadAll()
        {
            var bytes = new byte[4096];
            GenerateRandomBytes(bytes);
            using (var memory = new MemoryStream(bytes))
            {
                var reader = memory.AsReader();
                var buffer = new byte[bytes.Length];
                var bytesRead = reader.ReadFull(buffer);

                Assert.Equal(bytesRead, bytes.Length);
                Assert.Equal(buffer, bytes);
            }
        }

        [Fact]
        public async Task AsReader_GivenMemoryStream_CanReadAllAsync()
        {
            var bytes = new byte[4096];
            GenerateRandomBytes(bytes);
            using (var memory = new MemoryStream(bytes))
            {
                var reader = memory.AsReader();
                var buffer = new byte[bytes.Length];
                var bytesRead = await reader.ReadFullAsync(buffer);

                Assert.Equal(bytesRead, bytes.Length);
                Assert.Equal(buffer, bytes);
            }
        }

        [Fact]
        public void AsWriter_GivenMemoryStream_CanWriteAll()
        {
            using (var memory = new MemoryStream())
            {
                var writer = memory.AsWriter();
                var bytes = new byte[4096];
                GenerateRandomBytes(bytes);
                writer.Write(bytes, 0, bytes.Length);

                Assert.Equal(memory.ToArray(), bytes);
            }
        }

        [Fact]
        public async Task AsWriter_GivenMemoryStream_CanWriteAllAsync()
        {
            using (var memory = new MemoryStream())
            {
                var writer = memory.AsWriter();
                var bytes = new byte[4096];
                GenerateRandomBytes(bytes);
                await writer.WriteAsync(bytes, 0, bytes.Length, CancellationToken.None);

                Assert.Equal(memory.ToArray(), bytes);
            }
        }
    }
}
