using System.Collections.Generic;
using System.Linq;
using _1337Code.SortArrayByParity;
using Xunit;

namespace _1337Code.Tests.SortArrayByParity
{
    public sealed class ParityArraySortatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SortItemsByParity(int[] input, int[] expected)
        {
            var sortator = new ParityArraySortator();
            var result = sortator.SortArrayByParity(input);

            AssertParity(expected, result);
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SortItemsByParityInPlace(int[] input, int[] expected)
        {
            var sortator = new ParityArraySortator();
            var result = sortator.SortArrayByParityInPlace(input);

            AssertParity(expected, result);
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SortItemsByParityUnsafe(int[] input, int[] expected)
        {
            var sortator = new ParityArraySortator();
            var result = sortator.SortArrayByParityUnsafe(input);

            AssertParity(expected, result);
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SortItemsByParityRefs(int[] input, int[] expected)
        {
            var sortator = new ParityArraySortator();
            var result = sortator.SortArrayByParityRefs(input);

            AssertParity(expected, result);
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void SortItemsByParityRefSpan(int[] input, int[] expected)
        {
            var sortator = new ParityArraySortator();
            var result = sortator.SortArrayByParityRefSpan(input);

            AssertParity(expected, result);
        }

        [Fact(DisplayName = "Test of util method: Verify order of odd/evens does not matter when asserting")]
        public void TestAssertParity()
        {
            var actual = new[] { 4, 6, 2, 3, 5, 1 };
            var expected = new[] { 2, 4, 6, 1, 3, 5 };
            AssertParity(expected, actual);

            actual = new[] { 6, 4, 2 };
            expected = new[] { 2, 4, 6 };
            AssertParity(expected, actual);

            actual = new[] { 3, 5, 1 };
            expected = new[] { 1, 3, 5 };
            AssertParity(expected, actual);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[]
            {
                new[] { 3, 1, 2, 4 },
                new[] { 2, 4, 1, 3 }
            };

            yield return new object[]
            {
                new[] { 5, 7, 2, 4, 0, 1, 3, 5, 8 },
                new[] { 0, 2, 4, 8, 1, 3, 5, 5, 7 }
            };

            yield return new object[]
            {
                new [] { 2, 4, 6, 8 },
                new [] { 2, 4, 6, 8 }
            };

            yield return new object[]
            {
                new [] { 1, 3, 5, 7 },
                new [] { 1, 3, 5, 7 }
            };

            yield return new object[]
            {
                new int[0],
                new int[0]
            };

            yield return new object[]
            {
                (int[])null,
                new int[0]
            };
        }

        private static void AssertParity(int[] expected, int[] actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.Length, actual.Length);

            var firstOdd = -1;
            for (var i = 0; i < actual.Length; i++)
            {
                if (actual[i] % 2 != 0)
                {
                    firstOdd = i;
                    break;
                }
            }

            if (firstOdd < 0)
            {
                Assert.True(expected.SequenceEqual(actual.OrderBy(i => i)));
                return;
            }

            var sortedActualEvens = actual.Take(firstOdd).OrderBy(i => i);
            var sortedActualOdds = actual.Skip(firstOdd).OrderBy(i => i);
            var paritySortedActual = sortedActualEvens.Concat(sortedActualOdds).ToArray();

            Assert.Equal(expected, paritySortedActual);
        }
    }
}
