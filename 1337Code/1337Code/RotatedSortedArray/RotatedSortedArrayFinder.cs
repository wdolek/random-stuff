namespace _1337Code.RotatedSortedArray
{
    // https://leetcode.com/problems/search-in-rotated-sorted-array/
    public sealed class RotatedSortedArrayFinder
    {
        public int Search(int[] nums, int target)
        {
            if (nums is null || nums.Length == 0)
            {
                return -1;
            }

            if (nums.Length == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var pivot = (left + right) / 2;
                if (nums[pivot] == target)
                {
                    return pivot;
                }

                if (nums[left] <= nums[pivot])
                {
                    // -> first half sorted
                    if (target >= nums[left] && target < nums[pivot])
                    {
                        right = pivot - 1;
                    }
                    else
                    {
                        left = pivot + 1;
                    }

                }
                else if (nums[pivot] < nums[right])
                {
                    // -> second half sorted
                    if (target > nums[pivot] && target <= nums[right])
                    {
                        left = pivot + 1;
                    }
                    else
                    {
                        right = pivot - 1;
                    }
                }
            }

            return -1;
        }
    }
}
