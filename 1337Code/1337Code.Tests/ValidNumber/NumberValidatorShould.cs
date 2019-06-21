using System.Collections.Generic;
using _1337Code.ValidNumber;
using Xunit;

namespace _1337Code.Tests.ValidNumber
{
    public sealed class NumberValidatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateValidNumbers))]
        public void ReturnTrueForValidNumbers(string number)
        {
            var validator = new NumberValidator();
            Assert.True(validator.IsNumber(number));
        }

        [Theory]
        [MemberData(nameof(GenerateInvalidNumbers))]
        public void ReturnFalseeForValidNumbers(string number)
        {
            var validator = new NumberValidator();
            Assert.False(validator.IsNumber(number));
        }

        [Theory]
        [MemberData(nameof(GenerateValidNumbers))]
        public void ReturnTrueForValidNumbersUsingPlainAlg(string number)
        {
            var validator = new NumberValidator();
            Assert.True(validator.IsNumberPlain(number));
        }

        [Theory]
        [MemberData(nameof(GenerateInvalidNumbers))]
        public void ReturnFalseeForValidNumbersUsingPlainAlg(string number)
        {
            var validator = new NumberValidator();
            Assert.False(validator.IsNumberPlain(number));
        }

        public static IEnumerable<object[]> GenerateValidNumbers()
        {
            yield return new[] { "0" };
            yield return new[] { " 0.1 " };
            yield return new[] { "2e10" };
            yield return new[] { " -90e3   " };
            yield return new[] { " 6e-1" };
            yield return new[] { "53.5e93" };
            yield return new[] { ".1" };
            yield return new[] { "3." };
            yield return new[] { "+.8" };
        }

        public static IEnumerable<object[]> GenerateInvalidNumbers()
        {
            yield return new[] { "abc" };
            yield return new[] { "1 a" };
            yield return new[] { " 1e" };
            yield return new[] { "e3" };
            yield return new[] { " 99e2.5 " };
            yield return new[] { " --6 " };
            yield return new[] { "-+3" };
            yield return new[] { "95a54e53" };
        }
    }
}
