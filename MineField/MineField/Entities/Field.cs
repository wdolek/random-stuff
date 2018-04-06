using System;
using System.Collections.Generic;
using System.Linq;

namespace MineField.Entities
{
    /// <summary>
    /// Representation of mine field
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Field width, boundary for X
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Field height, boundary for Y
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Mines, because nothing else matters
        /// </summary>
        public IEnumerable<MinePoint> Mines { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class. 
        /// </summary>
        /// <param name="width">
        /// Field width
        /// </param>
        /// <param name="height">
        /// Field height
        /// </param>
        /// <param name="mines">
        /// Mines
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when passed array of mines is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when there are more mines than could fit into mine field
        /// </exception>
        public Field(int width, int height, IEnumerable<MinePoint> mines)
        {
            if (mines == null)
            {
                throw new ArgumentNullException("mines");
            }

            Width = width;
            Height = height;

            // check number of mines
            var minePoints = mines as IList<MinePoint> ?? mines.ToList();
            var max = width * height;

            if (minePoints.Count() > max)
            {
                throw new ArgumentException("Too many mines", "mines");
            }

            Mines = minePoints;
        }
    }
}
