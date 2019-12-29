namespace TicTacToe
{
    /// <summary>
    /// Game state.
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Game is not completed yet.
        /// </summary>
        NotComplete,

        /// <summary>
        /// Game is completed with winner.
        /// </summary>
        Winning,

        /// <summary>
        /// Game is completed without winner.
        /// </summary>
        Tie
    }
}