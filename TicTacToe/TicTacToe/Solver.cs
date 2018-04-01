using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    /// <summary>
    /// Game solver.
    /// </summary>
    public class Solver
    {
        /// <summary>
        /// Winning player.
        /// </summary>
        private readonly Player _player;

        /// <summary>
        /// Opponent player.
        /// </summary>
        private readonly Player _opponent;

        /// <summary>
        /// Initializes a new instance of the <see cref="Solver"/> class.
        /// </summary>
        /// <param name="player">Winning player.</param>
        /// <param name="opponent">Opponent player.</param>
        public Solver(Player player, Player opponent)
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _opponent = opponent ?? throw new ArgumentNullException(nameof(opponent));

            if (player.Equals(opponent))
            {
                throw new ArgumentException("Both players are the same, does not compute.", nameof(opponent));
            }
        }

        /// <summary>
        /// Calculates the best move for given playground state.
        /// </summary>
        /// <param name="playground">Game playground.</param>
        /// <returns>
        /// Returns index of field of the best move for player.
        /// </returns>
        public (bool CanTurn, int Index) CalulateBestMove(Playground playground)
        {
            if (playground == null)
            {
                throw new ArgumentNullException(nameof(playground));
            }

            FieldScore result = MiniMax(playground, true);

            return result.Index > 0
                ? (true, result.Index)
                : (false, 0);
        }

        /// <summary>
        /// Evaluate every possible move using minimax algorithm.
        /// </summary>
        /// <param name="playground">Game playground.</param>
        /// <param name="isMaximizing"><c>true</c> if player's move, <c>false</c> if opponent's move.</param>
        /// <returns>
        /// Returns field-score.
        /// </returns>
        private FieldScore MiniMax(Playground playground, bool isMaximizing)
        {
            PlaygroundState state = playground.GetState();

            // board is in final state, return score immediately
            // (since we are not aware of previous move (chosen field)
            //  we return only score part)
            if (state.State != GameState.NotComplete)
            {
                return state.State == GameState.Tie
                    ? new FieldScore { Score = 0 }
                    : _player.Equals(state.Player)
                        ? new FieldScore { Score = 1 }
                        : new FieldScore { Score = -1 };
            }

            Player currentPlayer = isMaximizing 
                ? _player 
                : _opponent;

            // calculate scores for each possible move
            // (NB! recursion is about to happen)
            IEnumerable<FieldScore> moves = playground.EmptyFields()
                .Select(
                    f => new FieldScore
                    {
                        Index = f.Index,
                        Score = MiniMax(playground.Turn(f.Index, currentPlayer), !isMaximizing).Score
                    });

            // captain obvious to the service:
            // player - get the highest score (ORDER BY score DESC)
            // opponent - get the lowest score (ORDER BY score ASC)
            moves = isMaximizing 
                ? moves.OrderByDescending(m => m.Score) 
                : moves.OrderBy(m => m.Score);

            return moves.First();
        }

        /// <summary>
        /// Temporary structure for keeping field-score pair.
        /// </summary>
        private struct FieldScore
        {
            /// <summary>
            /// Gets or sets playground field index.
            /// </summary>
            public int Index { get; set; }

            /// <summary>
            /// Gets or sets move score.
            /// </summary>
            public int Score { get; set; }
        }
    }
}
