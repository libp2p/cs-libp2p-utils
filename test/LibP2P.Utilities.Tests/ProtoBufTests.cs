using System;
using System.Text;
using LibP2P.Utilities.Extensions;
using Xunit;
using ProtoBuf;

namespace LibP2P.Utilities.Tests
{
    public class ProtoBufTests
    {
        [Fact]
        public void Serialize_GivenContract_SerializesAndDeserializes()
        {
            var contract = new TestProtoBufContract
            {
                TestString = "Hello World!",
                TestBytes = Encoding.UTF8.GetBytes("Hello World!").ComputeHash(),
                TestBool = true
            };

            var bytes = contract.SerializeToBytes();
            var deserialized = bytes.Deserialize<TestProtoBufContract>();

            Assert.Equal(deserialized.TestString, contract.TestString);
            Assert.Equal(deserialized.TestBytes, contract.TestBytes);
            Assert.Equal(deserialized.TestBool, contract.TestBool);
        }

        [ProtoContract]
        internal class TestProtoBufContract
        {
            [ProtoMember(1)]
            public string TestString { get; set; }
            [ProtoMember(2)]
            public byte[] TestBytes { get; set; }
            [ProtoMember(3)]
            public bool TestBool { get; set; }
        }

        [Fact]
        public void Serialize_GivenNoContract_ThrowsInvalidOperationException()
        {
            var obj = new Version(1, 2, 3, 4);

            Assert.Throws<InvalidOperationException>(() => obj.SerializeToBytes());
        }
    }
}
