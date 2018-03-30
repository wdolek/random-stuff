using System;

namespace TicTacToe
{
    /// <summary>
    /// Player representation.
    /// </summary>
    public struct Player : IEquatable<Player>
    {
        /// <summary>
        /// Empty (dummy) player.
        /// </summary>
        public static readonly Player NoPlayer = new Player(Guid.Empty, string.Empty);

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> struct.
        /// </summary>
        /// <param name="id">Player ID.</param>
        /// <param name="mark">Player mark.</param>
        public Player(Guid id, string mark)
        {
            Id = id;
            Mark = mark;
        }

        /// <summary>
        /// Gets player ID.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets player mark.
        /// </summary>
        public string Mark { get; }

        /// <summary>
        /// Compares two instances for equality.
        /// </summary>
        /// <param name="a">First player.</param>
        /// <param name="b">Another player.</param>
        /// <returns>
        /// Returns <c>true</c> if both players are the same.
        /// </returns>
        public static bool operator ==(Player a, Player b) =>
            a.Equals(b);

        /// <summary>
        /// Compares two instances for inequality.
        /// </summary>
        /// <param name="a">First player.</param>
        /// <param name="b">Another player.</param>
        /// <returns>
        /// Returns <c>true</c> if player differs.
        /// </returns>
        public static bool operator !=(Player a, Player b) =>
            !a.Equals(b);

        /// <inheritdoc />
        public bool Equals(Player other) =>
            Id.Equals(other.Id) && string.Equals(Mark, other.Mark);

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
        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^ (Mark != null ? Mark.GetHashCode() : 0);
            }
        }
    }
}