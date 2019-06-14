namespace _1337Code.JumpGame2
{
    // https://leetcode.com/problems/jump-game-ii/submissions/
    public sealed class Jump2
    {
        public int Jump(int[] nums)
        {
            // 1. [ 2, 3, 1, 1, 4 ]
            //                  ^-- starting point
            // 2. [ 2, 3, 1, 1, 4 ]
            //         ^-- furthest index which can reach marked position
            // 3. [ 2, 3, 1, 1, 4 ]
            //      ^-- now only field which can reach previous one

            // we start with point we want to reach (last index)
            int position = nums.Length - 1;
            int steps = 0;

            while (position > 0)
            {
                // iterate from start towards marked position
                for (int i = 0; i < position; i++)
                {
                    // we found furthest index which points to marked position
                    if (nums[i] >= position - i)
                    {
                        position = i;
                        ++steps;

                        break;
                    }
                }
            }

            return steps;
        }

        public int JumpGreedy(int[] nums)
        {
            // 1. [ 2, 3, 1, 1, 4 ]
            //            ^-- farthest position found (-> 0 + 2 = 2)
            //                ... continue with setting `maxPossibleRange`
            // 2. [ 2, 3, 1, 1, 4 ]
            //         ^-- new farthest position found! (-> 1 + 3 = 4)
            //             ... new farthest equals max position -> we are done!

            // if there's no or single number, we don't need to jump anywhere :)
            if (nums == null || nums.Length <= 1)
            {
                return 0;
            }

            var numOfJumps = 0;
            var maxPossibleRange = 0;
            var farthestPosition = 0;

            var maxPosition = nums.Length - 1;
            for (var i = 0; i <= maxPosition; i++)
            {
                // try to find new farthest position
                // (current index + max range where we can move)
                var tryFarthest = i + nums[i];
                if (tryFarthest > farthestPosition)
                {
                    farthestPosition = tryFarthest;
                }

                // reached end of array
                if (farthestPosition >= maxPosition)
                {
                    return numOfJumps + 1;
                }

                // iterated to maximum possible range, we are still somewhere in the middle
                if (i == maxPossibleRange)
                {
                    ++numOfJumps;
                    maxPossibleRange = farthestPosition;
                }
            }

            return numOfJumps;
        }
    }
}
