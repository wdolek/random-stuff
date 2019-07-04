using System.Linq;

namespace _1337Code.LargestElementFinder
{
    // https://leetcode.com/problems/kth-largest-element-in-an-array/
    public sealed class LargestElementFinder
    {
        public int FindKthLargest(int[] nums, int k) =>
            nums.OrderByDescending(v => v)
                .Skip(k - 1)
                .First();
    }
}
