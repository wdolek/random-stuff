using _1337Code.JumpGame2;
using Xunit;

namespace _1337Code.Tests.JumpGame2
{
    public sealed class Jump2Should
    {
        [Theory]
        [InlineData(new [] { 2, 3, 1, 1, 4 }, 2)]
        [InlineData(new [] { 1, 1, 1 }, 2)]
        [InlineData(new [] { 1 }, 0)]
        public void ReturnExpectedJumps(int[] nums, int expectedJumps)
        {
            var jump = new Jump2();
            var result = jump.Jump(nums);

            Assert.Equal(expectedJumps, result);
        }

        [Theory]
        [InlineData(new[] { 2, 3, 1, 1, 4 }, 2)]
        [InlineData(new[] { 1, 1, 1 }, 2)]
        [InlineData(new[] { 1 }, 0)]
        public void ReturnExpectedGreedyJumps(int[] nums, int expectedJumps)
        {
            var jump = new Jump2();
            var result = jump.JumpGreedy(nums);

            Assert.Equal(expectedJumps, result);
        }
    }
}
