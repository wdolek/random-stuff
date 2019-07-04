using System.Collections.Generic;
using _1337Code.SudokuValidator;
using Xunit;

namespace _1337Code.Tests.SudokuValidator
{
    public sealed class SudokatorShould
    {
        [Theory]
        [MemberData(nameof(GenerateTestData))]
        public void DetermineValidSudokuBoard(char[][] board, bool isValid)
        {
            var validator = new Sudokator();
            var result = validator.IsValidSudoku(board);

            Assert.Equal(isValid, result);
        }

        public static IEnumerable<object[]> GenerateTestData()
        {
            yield return new object[]
            {
                new char[][]
                {
                    new [] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                    new [] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                    new [] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                    new [] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                    new [] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                    new [] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                    new [] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                    new [] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                    new [] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                },
                true
            };

            yield return new object[]
            {
                new char[][]
                {
                    new [] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                    new [] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                    new [] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                    new [] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                    new [] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                    new [] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                    new [] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                    new [] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                    new [] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                },
                false
            };
        }
    }
}
