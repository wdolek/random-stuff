using System;

namespace _1337Code.ContainerWithMostWatter
{
    // https://leetcode.com/problems/container-with-most-water/
    public sealed class WaterContainer
    {
        public int MaxArea(int[] height)
        {
            var valuesCount = height.Length;
            var maxArea = 0;

            for (var i = 0; i < valuesCount; i++)
            {
                for (var j = valuesCount - 1; j > i; j--)
                {
                    var area = Math.Min(height[i], height[j]) * (j - i);
                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }

            return maxArea;
        }
    }
}
