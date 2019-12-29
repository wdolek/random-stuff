namespace TicTacToe
{
    /// <summary>
    /// Playground state.
    /// </summary>
    public class PlaygroundState
    {
        /// <summary>
        /// Game not completed yet.
        /// </summary>
        public static readonly PlaygroundState NotComplete = new PlaygroundState(GameState.NotComplete, Player.Blank);

        /// <summary>
        /// Game completed with tie.
        /// </summary>
        public static readonly PlaygroundState Tie = new PlaygroundState(GameState.Tie, Player.Blank);

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaygroundState"/> class.
        /// </summary>
        /// <param name="state">Game state.</param>
        /// <param name="player">Winning player.</param>
        private PlaygroundState(GameState state, Player player)
        {
            State = state;
            Player = player;
        }

        /// <summary>
        /// Gets game state.
        /// </summary>
        public GameState State { get; }

        /// <summary>
        /// Gets winning player.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Creates winning playground state.
        /// </summary>
        /// <param name="player">Winning player.</param>
        /// <returns>
        /// Winning playground state.
        /// </returns>
        public static PlaygroundState Winner(Player player) => new PlaygroundState(GameState.Winning, player);
    }
}