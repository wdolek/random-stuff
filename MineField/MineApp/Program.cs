using System;
using System.Text;

using MineField;
using MineField.Entities;

namespace MineApp
{
    // ------------------------------------------------------------------------------------
    //        __           __                   __               __                 __     
    //       / /_  _______/ /_   ____ _   _____/ /_  ____  _____/ /_   ____  ____  / /____ 
    //  __  / / / / / ___/ __/  / __ `/  / ___/ __ \/ __ \/ ___/ __/  / __ \/ __ \/ __/ _ \
    // / /_/ / /_/ (__  ) /_   / /_/ /  (__  ) / / / /_/ / /  / /_   / / / / /_/ / /_/  __/
    // \____/\__,_/____/\__/   \__,_/  /____/_/ /_/\____/_/   \__/  /_/ /_/\____/\__/\___/ 
    //
    // ------------------------------------------------------------------------------------
    //
    // It may look confusing - any two dimensional array is actually created way that first
    // index is value of Y: arr[Y,X] - Y is vertical index/row, X - column.
    //
    // ------------------------------------------------------------------------------------

    /// <summary>
    /// Le Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Max field size
        /// </summary>
        private const int MaxSize = 100;

        /// <summary>
        /// Le Main
        /// </summary>
        /// <param name="args">
        /// Program arguments
        /// </param>
        public static void Main(string[] args)
        {
            var counter = 1;

            // repeat until "0 0" is entered for dimension size input
            while (true)
            {
                // read dimension
                Console.Write("Field dimension (format 'n m'): ");
                string dimensionInput = Console.ReadLine();
                if (String.IsNullOrEmpty(dimensionInput))
                {
                    Console.WriteLine("Expecting dimension input");
                    break;
                }

                string[] dimensionParts = dimensionInput.Trim().Split(new[] { ' ' }, 2);
                if (dimensionParts.Length != 2)
                {
                    Console.WriteLine("Invalid input given, expecting dimension in format \"Width Height\" (e.g. \"4 3\"");
                    break;
                }

                int width, height;
                if (!ParseDimension(dimensionParts[0], "Width", out width))
                {
                    break;
                }

                if (!ParseDimension(dimensionParts[1], "Height", out height))
                {
                    break;
                }

                // validate input
                if (width == 0 && height == 0)
                {
                    break;
                }

                string fieldString = ReadField(width, height);

                // init
                var fieldParser = new FieldParser(MaxSize);
                var mineCounter = new MineCounter();
                var fieldSolver = new FieldSolver(mineCounter);

                Field field = fieldParser.ParseAsync(width, height, fieldString).Result;
                char[,] result = fieldSolver.GetTextualRepresentation(field);

                // output
                Console.WriteLine();
                Console.WriteLine("Field #{0}: ", counter);

                WriteResult(result);
                Console.WriteLine();

                ++counter;
            }
        }

        /// <summary>
        /// Parse dimension input
        /// </summary>
        /// <param name="str">
        /// String value
        /// </param>
        /// <param name="name">
        /// Dimension name (width/height)
        /// </param>
        /// <param name="value">
        /// Variable for storing value
        /// </param>
        /// <returns>
        /// <c>true</c> when parsing is successfull, <c>false</c> otherwise
        /// </returns>
        private static bool ParseDimension(string str, string name, out int value)
        {
            if (!Int32.TryParse(str, out value))
            {
                Console.WriteLine("Value '{0}' is not valid", str);
                return false;
            }

            if (value < 0 || value > MaxSize)
            {
                Console.WriteLine("{0} should be positive number, less-or-equal {1}", name, MaxSize);
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Read mine field
        /// </summary>
        /// <param name="width">
        /// Field width
        /// </param>
        /// <param name="height">
        /// Field height
        /// </param>
        /// <returns>
        /// Field string representation
        /// </returns>
        private static string ReadField(int width, int height)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < height; i++)
            {
                string line;

                // read until we have correct lenght of line
                do
                {
                    Console.Write("Row {0}: ", i + 1);
                    line = Console.ReadLine();

                    if (line == null || line.Length != width)
                    {
                        Console.WriteLine("Line must contain exactly {0} symbols.", width);
                    }
                }
                while (!String.IsNullOrEmpty(line) && line.Length != width);

                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Outptu result
        /// </summary>
        /// <param name="field">
        /// Field
        /// </param>
        private static void WriteResult(char[,] field)
        {
            for (var y = 0; y < field.GetLength(0); y++)
            {
                for (var x = 0; x < field.GetLength(1); x++)
                {
                    Console.Write("{0} ", field[y, x]);
                }

                Console.WriteLine();
            }
        }
    }
}
