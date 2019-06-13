using Xunit;
using Calculator = _1337Code.BasicCalculator.BasicCalculator;

namespace _1337Code.Tests.BasicCalculator
{
    public sealed class BasicCalculatorShould
    {
        [Theory]
        [InlineData("1+1", 2)]
        [InlineData(" 2 + 2 + 1 ", 5)]
        [InlineData("(2 - 1) + 1", 2)]
        [InlineData("1 + (2 - 1)", 2)]
        [InlineData("(1+(4+5+2)-3)+(6+8)", 23)]
        public void ReturnCorrectCalculation(string input, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(input);

            Assert.Equal(expected, result);
        }
    }
}
