using System.Threading.Tasks;

using MineField.Entities;

namespace MineField
{
    /// <summary>
    /// Mine field parser
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parse mine field represented by string
        /// </summary>
        /// <param name="width">
        /// Field width
        /// </param>
        /// <param name="height">
        /// Field height
        /// </param>
        /// <param name="field">
        /// Data
        /// </param>
        /// <returns>
        /// Async task with result of instance of <see cref="Field"/>
        /// </returns>
        Task<Field> ParseAsync(int width, int height, string field);
    }
}