using System;
using LibP2P.Utilities.Extensions;
using Xunit;

namespace LibP2P.Utilities.Tests
{
    public class ArrayTests
    {
        [Fact]
        public void Slice_GivenValidRange_ReturnsCorrectSlice()
        {
            var array = new[] {0,1,2,3,4,5,6,7,8,9};
            var sliced = array.Slice(3, 3);

            Assert.Equal(sliced, new[] { 3, 4, 5 });
        }

        [Fact]
        public void Slice_GivenOnlyOffset_ReturnsCorrectSlice()
        {
            var array = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sliced = array.Slice(6);

            Assert.Equal(sliced, new[] { 6, 7, 8, 9 });
        }

        [Fact]
        public void Slice_GivenInvalidOffset_ThrowsArgumentOutOfRangeException()
        {
            var array = new[] {0, 1, 2};

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(4));
        }

        [Fact]
        public void Slice_GivenZeroOrNegativeCount_ThrowsArgumentOutOfRangeException()
        {
            var array = new[] {0, 1, 2};

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(0, -1));
        }

        [Fact]
        public void Slice_GivenCountLargerThanArray_ReturnsValidSlice()
        {
            var array = new[] {0, 1, 2};
            var sliced = array.Slice(1, 3);

            Assert.Equal(sliced, new[] {1, 2});
        }

        [Fact]
        public void Append_GivenOneItem_ReturnsTwoItems()
        {
            var one = new[] {0};
            var two = one.Append(1);

            Assert.Equal(two, new[] {0,1});
        }

        [Fact]
        public void Append_GivenFiveItems_ReturnsSixItems()
        {
            var one = new[] { 0 };
            var six = one.Append(1,2,3,4,5);

            Assert.Equal(six, new[] { 0, 1, 2, 3, 4, 5 });
        }

        [Fact]
        public void Copy_GivenValidRange_ReturnsActualItemsCopied()
        {
            var array = new[] {0, 1, 2, 3};
            var copy = new int[2];
            var copied = array.Copy(copy);

            Assert.Equal(copied, 2);
            Assert.Equal(copy, new[] {0,1});
        }
    }
}
