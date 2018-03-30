using System;
using System.Diagnostics;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Player(Guid.NewGuid(), 'O');
            var p2 = new Player(Guid.NewGuid(), 'X');

            var playground = new Playground();
            playground.Print();

            Debugger.Break();
        }

        public static int GetScore(PlaygroundState state, Player player)
        {
            if (state.State == GameState.NotComplete)
            {
                return 0;
            }

            if (state.State == GameState.Tie)
            {
                return 0;
            }

            return state.Player == player 
                ? 1 
                : -1;
        }
    }
}
