using System;
using System.Collections.Generic;

using MineField.Entities;

namespace MineField
{
    public class MineCounter : IMineCounter
    {
        /// <summary>
        /// Get mines count visible from surrounding cells
        /// </summary>
        /// <param name="field">
        /// Mine field
        /// </param>
        /// <returns>
        /// Two dimensional array representing mine field with mine counter
        /// </returns>
        public int[,] Calculate(Field field)
        {
            // calculate number of surrounding mines
            // (dimension is height x width intentionally)
            var counterField = new int[field.Height, field.Width];
            foreach (var mine in field.Mines)
            {
                IncrementCounter(mine, counterField);
            }

            // mark position of mines by -1 afterwards
            foreach (var mine in field.Mines)
            {
                counterField[mine.Y, mine.X] = -1;
            }

            return counterField;
        }

        /// <summary>
        /// Increment surrounding fields by 1
        /// </summary>
        /// <param name="mine">
        /// Mine position
        /// </param>
        /// <param name="field">
        /// Mine field counter
        /// </param>
        private void IncrementCounter(MinePoint mine, int[,] field)
        {
            var width = field.GetLength(1);
            var height = field.GetLength(0);

            foreach (var cellCoordinates in GetSurroundingCoordinates(mine, width, height))
            {
                var x = cellCoordinates.Item1;
                var y = cellCoordinates.Item2;

                // increment value
                ++field[y, x];
            }
        }

        /// <summary>
        /// Get surrounding coordinates within field boundary
        /// </summary>
        /// <param name="mine">
        /// Mine position
        /// </param>
        /// <param name="width">
        /// Field width
        /// </param>
        /// <param name="height">
        /// Field height
        /// </param>
        /// <returns>
        /// Enumerable of surroudning cell coords
        /// </returns>
        private IEnumerable<Tuple<int, int>> GetSurroundingCoordinates(MinePoint mine, int width, int height)
        {
            var cells = new List<Tuple<int, int>>();

            // go around mine cell
            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    // center
                    if ((x == 0) && (y == 0))
                    {
                        continue;
                    }

                    // find coordinates of x-y cell related to mine
                    var cx = mine.X + x;
                    var cy = mine.Y + y;

                    // if cell is within mine field boundaries, add it to list
                    if ((cx >= 0) && (cx < width) && (cy >= 0) && (cy < height))
                    {
                        cells.Add(new Tuple<int, int>(cx, cy));
                    }
                }
            }

            return cells;
        }
    }
}
