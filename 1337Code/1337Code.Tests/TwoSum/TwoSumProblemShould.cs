using System.Collections.Generic;
using _1337Code.TwoSum;
using Xunit;

namespace _1337Code.Tests.TwoSum
{
    public sealed class TwoSumProblemShould
    {
        [Theory]
        [MemberData(nameof(GenerateInputData))]
        public void ReturnExpectedIndexes(int[] nums, int target, int[] expected)
        {
            var problem = new TwoSumProblem();
            var result = problem.TwoSum(nums, target);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GenerateInputData))]
        public void ReturnExpectedIndexesFromNaiveImplementation(int[] nums, int target, int[] expected)
        {
            var problem = new TwoSumProblem();
            var result = problem.TwoSumNaive(nums, target);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GenerateInputData()
        {
            yield return new object[]
            {
                new [] { 2, 7, 11, 15 },
                9,
                new [] { 0, 1 }
            };

            yield return new object[]
            {
                new [] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 },
                542,
                new [] { 28,  45 }
            };
        }
    }
}
