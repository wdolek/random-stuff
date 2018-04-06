using MineField.Entities;

namespace MineField
{
    /// <summary>
    /// Mine counter
    /// </summary>
    public interface IMineCounter
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
        int[,] Calculate(Field field);
    }
}
