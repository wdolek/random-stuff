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
            (0, 1, 2), // 1st row
            (3, 4, 5), // 2nd row
            (6, 7, 8), // 3rd row
            (0, 3, 6), // 1st col
            (1, 4, 7), // 2nd col
            (2, 5, 8), // 3rd col
            (0, 4, 8), // top left -> bottom right
            (2, 4, 6), // bottom left -> upper right
        };

        /// <summary>
        /// Playground fields.
        /// </summary>
        private readonly Field[] _fields;

        /// <summary>
        /// Counter of empty fields remaining (to avoid checking fields array over and over).
        /// </summary>
        private readonly int _emptyFields;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Playground()
        {
            _fields = new Field[9];
            _emptyFields = _fields.Length;

            // initialize fields
            for (var i = 0; i < _fields.Length; i++)
            {
                _fields[i] = new Field(i + 1);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="field">Playground field.</param>
        private Playground(Field[] field)
        {
            _fields = field;
            _emptyFields = _fields.Count(f => f.Player == null);
        }

        /// <summary>
        /// Gets all playground fields.
        /// </summary>
        public IReadOnlyList<Field> Fields => _fields;

        /// <summary>
        /// Performs player turn and gives new playground state.
        /// </summary>
        /// <param name="index">Field index.</param>
        /// <param name="player">Turning player.</param>
        /// <returns>
        /// New playground state.
        /// </returns>
        public Playground Turn(int index, Player player)
        {
            if (index < 1 || index > _fields.Length)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    $"Invalid turn, allowed index is in range [1..{_fields.Length}]");
            }

            if (Player.IsBlank(player))
            {
                throw new ArgumentException("Cannot turn with blank player.", nameof(player));
            }

            if (!_fields[index - 1].IsEmpty)
            {
                throw new ArgumentException($"Field {index} is already occupied.", nameof(index));
            }

            // copying array of structs - copying values
            var fields = new Field[9];
            _fields.CopyTo(fields, 0);

            // turn with player
            fields[index - 1].Player = player;

            return new Playground(fields);
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
                return !Player.IsBlank(f1.Player) && f1.Player.Equals(f2.Player);
            }

            // try to find winner (rows, cols, diagonales)
            foreach ((int, int, int) i in WinningCoords)
            {
                (int a, int b, int c) = i;
                if (FieldEqual(_fields[a], _fields[b]) && FieldEqual(_fields[b], _fields[c]))
                {
                    return PlaygroundState.Winner(_fields[a].Player);
                }
            }

            return _emptyFields == 0
                ? PlaygroundState.Tie
                : PlaygroundState.NotComplete;
        }
    }
}