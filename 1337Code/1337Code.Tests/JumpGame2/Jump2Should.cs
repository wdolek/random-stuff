using System.Collections.Generic;
using _1337Code.JumpGame2;
using Xunit;

namespace _1337Code.Tests.JumpGame2
{
    public sealed class Jump2Should
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ReturnExpectedJumps(int[] nums, int expectedJumps)
        {
            var jump = new Jump2();
            var result = jump.Jump(nums);

            Assert.Equal(expectedJumps, result);
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ReturnExpectedGreedyJumps(int[] nums, int expectedJumps)
        {
            var jump = new Jump2();
            var result = jump.JumpGreedy(nums);

            Assert.Equal(expectedJumps, result);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[] { new[] { 2, 3, 1, 1, 4 }, 2 };
            yield return new object[] { new[] { 1, 1, 1 }, 2 };
            yield return new object[] { new[] { 1 }, 0 };
        }
    }
}
