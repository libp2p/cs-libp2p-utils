using System;
using LibP2P.Utilities.Extensions;
using Xunit;

namespace LibP2P.Utilities.Tests
{
    public class TupleTests
    {
        [Fact]
        public void Swap_GivenTwoValues_ReturnsSwappedTuple()
        {
            var tuple = Tuple.Create(1, 2);
            
            Assert.Equal(tuple.Swap(), Tuple.Create(2, 1));
        }
    }
}
