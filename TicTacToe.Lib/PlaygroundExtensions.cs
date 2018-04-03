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
    }
}
