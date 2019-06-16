using System.Collections.Generic;
using Xunit;
using Substringator = _1337Code.LongestSubstring.LongestSubstring;

namespace _1337Code.Tests.LongestSubstring
{
    public sealed class LongestSubstringShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ReturnExpectedLengthOfLongestSubstring(string s, int expectedLength)
        {
            var substr = new Substringator();
            var result = substr.LengthOfLongestSubstring(s);

            Assert.Equal(expectedLength, result);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[] { "abcabcbb", 3 };
            yield return new object[] { "bbbbb", 1 };
            yield return new object[] { "pwwkew", 3 };
            yield return new object[] { " ", 1 };
            yield return new object[] { "aab", 2 };
            yield return new object[] { "dvdf", 3 };
        }
    }
}
