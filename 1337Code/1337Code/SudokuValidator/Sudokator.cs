using System;

namespace _1337Code.SudokuValidator
{
    // https://leetcode.com/problems/valid-sudoku/
    public sealed class Sudokator
    {
        private const int _numOfCells = 9;
        private const char _emptyCell = '.';

        public bool IsValidSudoku(char[][] board)
        {
            if (board == null || board.Length != _numOfCells || board[0].Length != _numOfCells)
            {
                return false;
            }

            return AreRowsAndColsValid(board) && AreSubBoxesValid(board);
        }

        private static bool IsCellValid(char[][] board, ref Span<bool> map, int row, int col)
        {
            var symbol = board[row][col];
            if (symbol == _emptyCell)
            {
                return true;
            }

            // convert char to int (use ASCII!)
            // NB! Sudoku contains nums from 1..9, make sure we use range 0..8!
            var num = symbol - '0' - 1;
            if (map[num])
            {
                return false;
            }

            // flag we found current number in referenced map
            // (this is evil side effect... but ¯\_(ツ)_/¯ ...)
            map[num] = true;

            return true;
        }

        private static bool AreRowsAndColsValid(char[][] board)
        {
            Span<bool> rowMap = stackalloc bool[_numOfCells];
            Span<bool> colMap = stackalloc bool[_numOfCells];

            // | i/j |   0   |   1   |   2   | ...
            // +-----+-------+-------+-------+-----
            // |   0 | [0,0] | [0,1] | [0,2] |
            // +-----+-------+-------+-------+-----
            // |   1 | [1,0] | [1,1] | [1,2] |
            // +-----+-------+-------+-------+-----
            // |   2 | [2,0] | [2,1] | [2,2] |
            // +-----+-------+-------+-------+-----
            // | ... |       |       |       |

            // scan rows & cols
            // (since board is NxN, we can swap `i` and `j` to scan rows and cols at once)
            for (var i = 0; i < _numOfCells; i++)
            {
                for (var j = 0; j < _numOfCells; j++)
                {
                    // row
                    if (!IsCellValid(board, ref rowMap, i, j))
                    {
                        return false;
                    }

                    // column
                    // NB! we swapped `i` and `j`
                    if (!IsCellValid(board, ref colMap, j, i))
                    {
                        return false;
                    }
                }

                // reset maps for each row (resp. col)
                rowMap.Fill(false);
                colMap.Fill(false);
            }

            return true;
        }

        private static bool AreSubBoxesValid(char[][] board)
        {
            Span<bool> subMap = stackalloc bool[_numOfCells];

            // go trough sub-box coords: [0,0], [0,3], [0,6], [3,0], [3,3], ...
            for (var subRow = 0; subRow < _numOfCells; subRow += 3)
            {
                for (var subCol = 0; subCol < _numOfCells; subCol += 3)
                {
                    // go trough sub-box 3x3 matrix
                    for (var i = subRow; i < subRow + 3; i++)
                    {
                        for (var j = subCol; j < subCol + 3; j++)
                        {
                            if (!IsCellValid(board, ref subMap, i, j))
                            {
                                return false;
                            }
                        }
                    }

                    // reset map for each sub-box
                    subMap.Fill(false);
                }
            }

            return true;
        }
    }
}
