using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    /// <summary>
    /// Playground representation.
    /// </summary>
    public class Playground
    {
        /// <summary>
        /// Array of winning coord tuples.
        /// </summary>
        private static readonly (int, int, int)[] WinningCoords =
        {
            (1, 2, 3), // 1st row
            (4, 5, 6), // 2nd row
            (7, 8, 9), // 3rd row
            (1, 4, 7), // 1st col
            (2, 5, 8), // 2nd col
            (3, 6, 9), // 3rd col
            (1, 5, 9), // top left -> bottom right
            (3, 5, 7), // bottom left -> upper right
        };

        /// <summary>
        /// Playground fields.
        /// </summary>
        private readonly Field[] _field;

        /// <summary>
        /// Counter of empty fields remaining (to avoid checking fields array over and over).
        /// </summary>
        private readonly int _emptyFields;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Playground()
        {
            _field = new Field[9];
            _emptyFields = _field.Length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="field">Playground field.</param>
        private Playground(Field[] field)
        {
            _field = field;
            _emptyFields = _field.Count(f => f == null);
        }

        /// <summary>
        /// Gets empty field indexes.
        /// </summary>
        public IEnumerable<int> EmptyFields =>
            _field.Select((f, i) => new { Index = i + 1, IsEmpty = f == null })
                .Where(f => f.IsEmpty)
                .Select(f => f.Index);

        /// <summary>
        /// Performs player turn and gives new playground state.
        /// </summary>
        /// <param name="index">Field index.</param>
        /// <param name="player">Turning player.</param>
        /// <returns>
        /// New playground state.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if trying to turn to invalid field.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if trying to turn to already taken field.
        /// </exception>
        public Playground Turn(int index, Player player)
        {
            if (index < 1 || index > _field.Length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    $"Invalid turn, allowed index is in range [1..{_field.Length}]");
            }

            if (player == Player.NoPlayer)
            {
                return this;
            }

            if (_field[index - 1] != null)
            {
                throw new ArgumentException($"Field {index} is already occupied.", nameof(index));
            }

            var newField = new Field[9];
            _field.CopyTo(newField, 0);

            newField[index - 1] = new Field(player);

            return new Playground(newField);
        }

        /// <summary>
        /// Gets playground state identifying whether there's winning player.
        /// </summary>
        /// <returns>
        /// Playground state.
        /// </returns>
        public PlaygroundState GetState()
        {
            // player can win in 5th turn in the best case
            if (_emptyFields > 4)
            {
                return PlaygroundState.NotComplete;
            }

            bool FieldEqual(Field f1, Field f2)
            {
                if (f1 == null || f2 == null)
                {
                    return false;
                }

                return f1.Player == f2.Player;
            }

            // try to find winner (rows, cols, diagonales)
            foreach ((int, int, int) i in WinningCoords)
            {
                (int a, int b, int c) = i;
                if (FieldEqual(_field[a], _field[b]) && FieldEqual(_field[b], _field[c]))
                {
                    return PlaygroundState.Winner(_field[0].Player);
                }
            }

            return _emptyFields == 0
                ? PlaygroundState.Tie
                : PlaygroundState.NotComplete;
        }
    }
}