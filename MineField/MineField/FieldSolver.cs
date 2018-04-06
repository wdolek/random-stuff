using System;
using System.Globalization;

using MineField.Entities;

namespace MineField
{
    /// <summary>
    /// Mine field solver
    /// </summary>
    public class FieldSolver : IFieldSolver
    {
        /// <summary>
        /// Mine counter
        /// </summary>
        private readonly IMineCounter _mineCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldSolver"/> class. 
        /// </summary>
        /// <param name="mineCounter">
        /// Mine counter
        /// </param>
        public FieldSolver(IMineCounter mineCounter)
        {
            if (mineCounter == null)
            {
                throw new ArgumentNullException("mineCounter");
            }

            _mineCounter = mineCounter;
        }

        /// <summary>
        /// Converts mine field to textual representation
        /// </summary>
        /// <param name="field">
        /// Mine field
        /// </param>
        /// <returns>
        /// Two dimensional array representing mine field
        /// </returns>
        public char[,] GetTextualRepresentation(Field field)
        {
            var counterField = _mineCounter.Calculate(field);

            // transform to textual form
            var representation = new char[field.Height, field.Width];
            for (var y = 0; y < counterField.GetLength(0); y++)
            {
                for (var x = 0; x < counterField.GetLength(1); x++)
                {
                    var c = counterField[y, x];
                    representation[y, x] = ConvertCounterValue(c);
                }
            }

            return representation;
        }

        /// <summary>
        /// Gets counter value representation
        /// </summary>
        /// <param name="count">
        /// Mines count
        /// </param>
        /// <returns>
        /// Char representation of value
        /// </returns>
        private char ConvertCounterValue(int count)
        {
            switch (count)
            {
                case 0:
                    return Constants.Safe;
                case -1:
                    return Constants.Mine;
                default:
                    return Char.Parse(count.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
