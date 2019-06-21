using System;
using System.Collections.Generic;
using System.Linq;
using _1337Code.RotateImage;
using Xunit;

namespace _1337Code.Tests.RotateImage
{
    public sealed class ImageRotatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateMatrix))]
        public void ProduceExpectedMatrix(int[][] matrix, int[][] expectedMatrix)
        {
            var rotator = new ImageRotator();
            rotator.Rotate(matrix);

            Assert.True(matrix.SequenceEqual(expectedMatrix, IntArrayEqualityComparer.Instance));
        }

        public static IEnumerable<object[]> GenerateMatrix()
        {
            yield return new object[]
            {
                new[] {
                    new[] { 1, 2, 3 },
                    new[] { 4, 5, 6 },
                    new[] { 7, 8, 9 }
                },
                new[] {
                    new[] { 7, 4, 1 },
                    new[] { 8, 5, 2 },
                    new[] { 9, 6, 3 }
                }
            };

            yield return new object[]
            {
                new[]
                {
                    new[] { 5, 1, 9, 11 },
                    new[] { 2, 4, 8, 10 },
                    new[] { 13, 3, 6, 7 },
                    new[] { 15, 14, 12, 16 }
                },
                new[]
                {
                    new[] { 15, 13, 2, 5 },
                    new[] { 14, 3, 4, 1 },
                    new[] { 12, 6, 8, 9 },
                    new[] { 16, 7, 10, 11 }
                }
            };
        }

        private class IntArrayEqualityComparer : IEqualityComparer<int[]>
        {
            public static readonly IntArrayEqualityComparer Instance = new IntArrayEqualityComparer();
            public bool Equals(int[] x, int[] y) => x.SequenceEqual(y);
            public int GetHashCode(int[] obj) => obj.GetHashCode();
        }
    }
}
