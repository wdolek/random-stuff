using System.Collections.Generic;
using _1337Code.ReverseWords;
using Xunit;

namespace _1337Code.Tests.ReverseWords
{
    public sealed class WordReverterShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void RevertString(string str, string expected)
        {
            var reverter = new WordReverter();
            var result = reverter.ReverseWords(str);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new[] { "the sky is blue", "blue is sky the" };
            yield return new[] { "  hello world!  ", "world! hello" };
            yield return new[] { "a good   example", "example good a" };
            yield return new[] { null, string.Empty };
            yield return new[] { string.Empty, string.Empty };
            yield return new[] { "   ", string.Empty };
        }
    }
}
