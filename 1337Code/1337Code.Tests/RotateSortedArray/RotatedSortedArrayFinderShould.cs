using System.Collections.Generic;
using _1337Code.RotatedSortedArray;
using Xunit;

namespace _1337Code.Tests.RotateSortedArray
{
    public sealed class RotatedSortedArrayFinderShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ReturnIndexOfTargetValue(int[] nums, int target, int expected)
        {
            var finder = new RotatedSortedArrayFinder();
            var result = finder.Search(nums, target);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[] {
                new[] { 4, 5, 6, 7, 0, 1, 2 },
                0,
                4
            };

            yield return new object[] {
                new[] { 4, 5, 6, 7, 0, 1, 2 },
                3,
                -1
            };

            yield return new object[] {
                new[] { 1, 3 },
                1,
                0
            };

            // rotation pivot: 5
            // target is in first half
            yield return new object[] {
                new[] { 12, 13, 14, 15, 16, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                14,
                2
            };

            // rotation pivot: 5
            // target is in second half
            yield return new object[] {
                new[] { 12, 13, 14, 15, 16, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                9,
                14
            };
        }
    }
}
