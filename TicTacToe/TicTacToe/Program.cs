using System.Diagnostics;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Player('X');
            var p2 = new Player('O');

            var s1 = new Solver(p1, p2);
            var s2 = new Solver(p2, p1);

            var playground = new Playground();

            playground = playground.Turn(s1.CalulateBestMove(playground).Index, p1);
            playground.Print();

            playground = playground.Turn(s2.CalulateBestMove(playground).Index, p2);
            playground.Print();

            playground = playground.Turn(s1.CalulateBestMove(playground).Index, p1);
            playground.Print();

            playground = playground.Turn(s2.CalulateBestMove(playground).Index, p2);
            playground.Print();

            playground = playground.Turn(s1.CalulateBestMove(playground).Index, p1);
            playground.Print();

            playground = playground.Turn(s2.CalulateBestMove(playground).Index, p2);
            playground.Print();

            playground = playground.Turn(s1.CalulateBestMove(playground).Index, p1);
            playground.Print();

            playground = playground.Turn(s2.CalulateBestMove(playground).Index, p2);
            playground.Print();

            playground = playground.Turn(s2.CalulateBestMove(playground).Index, p1);
            playground.Print();

            Debugger.Break();
        }
    }
}
