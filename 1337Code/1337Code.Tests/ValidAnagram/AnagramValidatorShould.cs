using System.Collections.Generic;
using _1337Code.ValidAnagram;
using Xunit;

namespace _1337Code.Tests.ValidAnagram
{
    public sealed class AnagramValidatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ValidateAnagram(string s, string t, bool isValid) {
            var validator = new AnagramValidator();
            var result = validator.IsAnagram(s, t);

            Assert.Equal(isValid, result);
        }

        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void ValidateAnagramWithoutLinq(string s, string t, bool isValid)
        {
            var validator = new AnagramValidator();
            var result = validator.IsAnagramWithoutLinq(s, t);

            Assert.Equal(isValid, result);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[] { "anagram", "nagaram", true };
            yield return new object[] { "restful", "fluster", true };
            yield return new object[] { "rat", "car", false };
            yield return new object[] { "a", "ab", false };
            yield return new object[] { "ab", "a", false };
            yield return new object[] { "aa", "ab", false };
        }
    }
}
