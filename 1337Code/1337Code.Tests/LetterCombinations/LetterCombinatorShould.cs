using System;
using System.Collections.Generic;
using System.Linq;
using _1337Code.LetterCombinations;
using Xunit;

namespace _1337Code.Tests.LetterCombinations
{
    public sealed class LetterCombinatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateInputDigits))]
        public void ReturnAllPossibleCombinations(string digits, IEnumerable<string> expected)
        {
            var combinator = new LetterCombinator();
            var result = combinator.LetterCombinations(digits);

            Assert.True(expected.SequenceEqual(result));
        }

        [Theory]
        [MemberData(nameof(GenerateInputDigits))]
        public void ReturnAllPossibleCombinationsUsingLinq(string digits, IEnumerable<string> expected)
        {
            var combinator = new LetterCombinator();
            var result = combinator.LetterCombinationsUsingLinq(digits);

            Assert.True(expected.SequenceEqual(result));
        }

        [Theory]
        [InlineData("936535", "wdolek")]
        public void ContainSpecificString(string digits, string expectedCombination)
        {
            var combinator = new LetterCombinator();
            var result = combinator.LetterCombinations(digits);

            Assert.Contains(result, v => string.Equals(v, expectedCombination, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<object[]> GenerateInputDigits()
        {
            yield return new object[]
            {
                "23",
                new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }
            };
        }
    }
}
