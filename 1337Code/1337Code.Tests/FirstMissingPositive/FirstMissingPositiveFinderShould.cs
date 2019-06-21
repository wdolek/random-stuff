using System.Collections.Generic;
using _1337Code.FirstMissingPositive;
using Xunit;

namespace _1337Code.Tests.FirstMissingPositive
{
    public sealed class FirstMissingPositiveFinderShould
    {
        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositive(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositive(nums);

            Assert.Equal(expectedNumber, result);
        }

        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositiveWithoutExtraMemory(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositiveWithoutExtraMemory(nums);

            Assert.Equal(expectedNumber, result);
        }

        [Theory]
        [MemberData(nameof(GenerateInput))]
        public void FindFirstMissingPositiveWithMinMax(int[] nums, int expectedNumber)
        {
            var finder = new FirstMissingPositiveFinder();
            var result = finder.FirstMissingPositiveWithMinMax(nums);

            Assert.Equal(expectedNumber, result);
        }

        public static IEnumerable<object[]> GenerateInput()
        {
            yield return new object[] { new[] { 1, 2, 0 }, 3 };
            yield return new object[] { new[] { 3, 4, -1, 1 }, 2 };
            yield return new object[] { new[] { 7, 8, 9, 11, 12 }, 1 };
            yield return new object[] { new[] { 1 }, 2 };

            // full sequence 1..9
            yield return new object[] { new[] { 2, 4, 6, 8, 1, 3, 5, 7, 9 }, 10 };

            // no positive numbers at all
            yield return new object[] { new[] { -1, -2, -3 }, 1 };
        }
    }
}
