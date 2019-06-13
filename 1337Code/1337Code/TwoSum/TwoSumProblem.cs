using System;
using System.Collections.Generic;

namespace _1337Code.TwoSum
{
    // https://leetcode.com/problems/two-sum/
    public sealed class TwoSumProblem
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var d = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var currentValue = nums[i];

                // try to find complementary value
                var complementaryValue = target - currentValue;
                if (d.ContainsKey(complementaryValue))
                {
                    return new int[] { d[complementaryValue], i };
                }

                // keep in memory (overwrite older value)
                d[currentValue] = i;
            }

            return Array.Empty<int>();
        }

        public int[] TwoSumNaive(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j < nums.Length; j++)
                {
                    if (i != j && target - nums[i] == nums[j])
                    {
                        return new[] { i, j };
                    }
                }
            }

            return Array.Empty<int>();
        }
    }
}
