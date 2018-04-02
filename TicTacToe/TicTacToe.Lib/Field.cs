using System;
using System.Diagnostics;

namespace TicTacToe
{
    /// <summary>
    /// Playground field representation.
    /// </summary>
    [DebuggerDisplay("{Index}: {Player != null ? Player.Mark.ToString() : \"-\"}")]
    public struct Field
    {
        /// <summary>
        /// Player position.
        /// </summary>
        private Player _player;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Field(int index)
        {
            Index = index;
            _player = null;
        }

        /// <summary>
        /// Gets field index.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Gets a value indicating whether field is not occupied.
        /// </summary>
        public bool IsEmpty => _player == null;

        /// <summary>
        /// Gets or sets player occupying field.
        /// </summary>
        public Player Player
        {
            get => _player;
            set => _player = value ?? throw new ArgumentException("Cannot set null player.");
        }
    }
}