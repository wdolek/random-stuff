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
    }
}
