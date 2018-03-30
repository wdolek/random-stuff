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
        public static readonly Player Blank = new Player('\0', false);

        /// <summary>
        /// Player's opponent.
        /// </summary>
        private Player _opponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> struct.
        /// </summary>
        /// <param name="mark">Player mark.</param>
        /// <param name="isMaximizing">Whether player should maximize own score.</param>
        public Player(char mark, bool isMaximizing)
        {
            Mark = mark;
            IsMaximizing = isMaximizing;
        }

        /// <summary>
        /// Gets player mark.
        /// </summary>
        public char Mark { get; }

        /// <summary>
        /// Gets a value indicating whether player should maximize own score.
        /// </summary>
        public bool IsMaximizing { get; }

        /// <summary>
        /// Gets or sets player's opponent.
        /// </summary>
        public Player Opponent
        {
            get => _opponent;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (ReferenceEquals(this, value))
                {
                    throw new ArgumentException("Cannot set self as opponent.", nameof(value));
                }

                if (Equals(value))
                {
                    throw new ArgumentException("Both players are equal.", nameof(value));
                }

                // save reference to opponent
                _opponent = value;

                // set opponent's opponent to self
                // (NB! assign field directly otherwise you end up in infinite setter loop)
                _opponent._opponent = this;
            }
        }

        /// <summary>
        /// Determines whether provided player instance is empty.
        /// </summary>
        /// <param name="player">Player instance.</param>
        /// <returns>
        /// Returns <c>true</c> if player is not set, <c>false</c> otherwise.
        /// </returns>
        public static bool IsBlank(Player player) =>
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