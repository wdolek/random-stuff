using System;

namespace TicTacToe
{
    /// <summary>
    /// Player representation.
    /// </summary>
    public class Player : IEquatable<Player>
    {
        /// <summary>
        /// Blank (dummy) player.
        /// </summary>
        public static readonly Player Blank = new Player('\0');

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> struct.
        /// </summary>
        /// <param name="mark">Player mark.</param>
        public Player(char mark)
        {
            Mark = mark;
        }

        /// <summary>
        /// Gets player mark.
        /// </summary>
        public char Mark { get; }

        /// <summary>
        /// Determines whether provided player instance is empty.
        /// </summary>
        /// <param name="player">Player instance.</param>
        /// <returns>
        /// Returns <c>true</c> if player is not set, <c>false</c> otherwise.
        /// </returns>
        public static bool IsNullOrBlank(Player player) =>
            player == null || player.Equals(Blank);

        /// <inheritdoc />
        public bool Equals(Player other) =>
            other != null
            && Mark == other.Mark;

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Player player && Equals(player);
        }

        /// <inheritdoc />
        public override int GetHashCode() =>
            Mark.GetHashCode();
    }
}