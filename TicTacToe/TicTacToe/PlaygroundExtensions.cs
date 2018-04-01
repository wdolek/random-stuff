using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public static class PlaygroundExtensions
    {
        public static IEnumerable<Field> EmptyFields(this Playground playground)
        {
            if (playground == null)
            {
                throw new ArgumentNullException(nameof(playground));
            }

            return playground.Fields.Where(f => f.IsEmpty);
        }

        public static void Print(this Playground playground)
        {
            ConsoleColor foreground = Console.ForegroundColor;

            for (var r = 0; r < 3; r++)
            {
                Console.WriteLine("+---+---+---+");
                for (var c = 0; c < 3; c++)
                {
                    Field field = playground.Fields[r * 3 + c];

                    Console.Write("| ");

                    Console.ForegroundColor = field.IsEmpty ? ConsoleColor.Gray : ConsoleColor.Green;
                    Console.Write(GetFieldValue(field));
                    Console.ForegroundColor = foreground;

                    Console.Write(" ");
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("+---+---+---+");
        }

        private static string GetFieldValue(Field field) =>
            field.IsEmpty
                ? field.Index.ToString("D")
                : field.Player.Mark.ToString();
    }
}
