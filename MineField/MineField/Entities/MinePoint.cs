namespace MineField.Entities
{
    /// <summary>
    /// Describes X-Y position of mine within mine field
    /// </summary>
    public struct MinePoint
    {
        /// <summary>
        /// X position
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Y position
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinePoint"/> struct. 
        /// </summary>
        /// <param name="x">
        /// X position
        /// </param>
        /// <param name="y">
        /// Y position
        /// </param>
        public MinePoint(int x, int y)
            : this()
        {
            X = x;
            Y = y;
        }
    }
}
