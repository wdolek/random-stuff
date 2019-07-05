using System;
using System.Collections.Generic;
using System.Linq;
using _1337Code.GroupAnagrams;
using Xunit;

namespace _1337Code.Tests.GroupAnagrams
{
    public sealed class AnagramGroupatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void GroupAnagramsCorrectly(string[] strs, IList<IList<string>> expected)
        {
            var groupator = new AnagramGroupator();
            var result = groupator.GroupAnagrams(strs);

            Assert.Equal(expected.Count, result.Count);
            Assert.True(
                expected.SequenceEqual(
                    result,
                    new ListStringComparer()));
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void GroupAnagramsCorrectlyWithouComparer(string[] strs, IList<IList<string>> expected)
        {
            var groupator = new AnagramGroupator();
            var result = groupator.GroupAnagramsWithoutComparer(strs);

            Assert.Equal(expected.Count, result.Count);
            Assert.True(
                expected.SequenceEqual(
                    result,
                    new ListStringComparer()));
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[]
            {
                new [] { "eat", "tea", "tan", "ate", "nat", "bat" },
                new List<IList<string>>
                {
                    new List<string> { "ate", "eat", "tea" },
                    new List<string> { "nat", "tan" },
                    new List<string> { "bat" },
                }
            };
        }

        private class ListStringComparer : IEqualityComparer<IList<string>>
        {
            public bool Equals(IList<string> first, IList<string> second) =>
                first
                    .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                    .SequenceEqual(
                        second.OrderBy(s => s, StringComparer.OrdinalIgnoreCase),
                        StringComparer.OrdinalIgnoreCase);

            public int GetHashCode(IList<string> obj) => 0;
        }
    }
}
