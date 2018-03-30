using System;

namespace TicTacToe
{
    /// <summary>
    /// Field representation.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="player">Player occupying field.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if given player can't occupy field.
        /// </exception>
        public Field(Player player)
        {
            if (player == Player.NoPlayer)
            {
                throw new ArgumentException("Cannot instantiate field without player.", nameof(player));
            }

            Player = player;
        }

        /// <summary>
        /// Gets player occupying field.
        /// </summary>
        public Player Player { get; }
    }
}