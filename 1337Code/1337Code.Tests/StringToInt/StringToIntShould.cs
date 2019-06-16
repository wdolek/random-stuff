using Xunit;
using AToI = _1337Code.StringToInt.StringToInt;

namespace _1337Code.Tests.StringToInt
{
    public class StringToIntShould
    {
        [Theory]
        [InlineData("42", 42)]
        [InlineData("   -42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("-91283472332", int.MinValue)]
        [InlineData("   +0 123", 0)]
        [InlineData("9223372036854775808", int.MaxValue)]
        [InlineData("-   234", 0)]
        [InlineData("0-1", 0)]
        [InlineData("-5-", -5)]
        public void GiveExpectedResult(string s, int expected)
        {
            var atoi = new AToI();
            var result = atoi.MyAtoi(s);

            Assert.Equal(expected, result);
        }
    }
}
