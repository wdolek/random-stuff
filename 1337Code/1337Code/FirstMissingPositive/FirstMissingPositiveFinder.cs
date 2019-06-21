using System.Collections.Generic;
using System.Linq;

namespace _1337Code.FirstMissingPositive
{
    // https://leetcode.com/problems/first-missing-positive/
    public sealed class FirstMissingPositiveFinder
    {
        public int FirstMissingPositive(int[] nums)
        {
            // turn input to set for better lookup, O(n)
            var set = new HashSet<int>(nums);

            // iterate from 1..MAX, first number not in set is our missing positive number, O(n)
            for (var i = 1; i < int.MaxValue; i++)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }

            return 0;
        }

        public int FirstMissingPositiveWithoutExtraMemory(int[] nums)
        {
            // iterate from 1 .. (n + 1)
            for (var i = 1; i <= nums.Length + 1; i++)
            {
                var numOfIs = nums.Count(v => v == i);
                if (numOfIs == 0)
                {
                    return i;
                }
            }

            return 0;
        }

        public int FirstMissingPositiveWithMinMax(int[] nums)
        {
            var min = int.MaxValue;
            var max = 0;

            // determine minimum and maximum values
            for (var i = 0; i < nums.Length; i++)
            {
                var n = nums[i];

                if (n > 0 && n < min)
                {
                    min = n;
                }

                if (n > max)
                {
                    max = n;
                }
            }

            // we haven't found any positive number
            if (max == 0)
            {
                return 1;
            }

            // if minimal positive value is [2,), first missing is just 1
            if (min > 1)
            {
                return 1;
            }

            // minimal value is 1, we need to find first missing number in sequence
            for (var n = min; n <= max; n++)
            {
                var found = false;
                for (var i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == n)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return n;
                }
            }

            // we haven't found missing number within sequence, so it must be max + 1
            return max + 1;
        }
    }
}
