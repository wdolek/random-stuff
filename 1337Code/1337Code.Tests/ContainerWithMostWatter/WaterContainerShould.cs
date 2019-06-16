using _1337Code.ContainerWithMostWatter;
using Xunit;

namespace _1337Code.Tests.ContainerWithMostWatter
{
    public sealed class WaterContainerShould
    {
        [Theory]
        [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [InlineData(new[] { 1, 1 }, 1)]
        public void CalculateMaxArea(int[] height, int expectedArea)
        {
            var container = new WaterContainer();
            var result = container.MaxArea(height);

            Assert.Equal(expectedArea, result);
        }
    }
}
