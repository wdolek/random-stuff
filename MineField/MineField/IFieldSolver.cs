using MineField.Entities;

namespace MineField
{
    /// <summary>
    /// Mine field solver
    /// </summary>
    public interface IFieldSolver
    {
        /// <summary>
        /// Gets representation of solved mine field
        /// </summary>
        /// <param name="field">
        /// Mine field
        /// </param>
        /// <returns>
        /// Output-friendly representation of mine field
        /// </returns>
        char[,] GetTextualRepresentation(Field field);
    }
}
