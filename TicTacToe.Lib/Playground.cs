using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    /// <summary>
    /// Playground representation of 3x3 game.
    /// </summary>
    public class Playground
    {
        /// <summary>
        /// Number of playground fields.
        /// </summary>
        private const int NumberOfFields = 9;

        /// <summary>
        /// Minimum number of fields to be taken to win.
        /// </summary>
        private const int MinimumFieldsToWin = 4;

        /// <summary>
        /// Array of winning coords.
        /// </summary>
        private static readonly int[][] WinningCoords =
        {
            new[] { 0, 1, 2 }, // 1st row
            new[] { 3, 4, 5 }, // 2nd row
            new[] { 6, 7, 8 }, // 3rd row
            new[] { 0, 3, 6 }, // 1st col
            new[] { 1, 4, 7 }, // 2nd col
            new[] { 2, 5, 8 }, // 3rd col
            new[] { 0, 4, 8 }, // top left \ bottom right
            new[] { 2, 4, 6 }, // bottom left / upper right
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
            _fields = new Field[NumberOfFields];
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

            if (Player.IsNullOrBlank(player))
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
            if (_emptyFields > MinimumFieldsToWin)
            {
                return PlaygroundState.NotComplete;
            }

            bool FieldEqual(Field f1, Field f2)
            {
                return !Player.IsNullOrBlank(f1.Player) && f1.Player.Equals(f2.Player);
            }

            foreach (int[] wc in WinningCoords)
            {
                int a = wc[0];
                int b = wc[1];
                int c = wc[2];
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