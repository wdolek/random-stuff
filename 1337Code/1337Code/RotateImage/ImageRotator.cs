namespace _1337Code.RotateImage
{
    // https://leetcode.com/problems/rotate-image/
    public sealed class ImageRotator
    {
        public void Rotate(int[][] matrix)
        {
            // from:
            // [1,2,3],
            // [4,5,6],
            // [7,8,9]
            //
            // to:
            // [7,4,1],
            // [8,5,2],
            // [9,6,3]
            //
            // i,j -> i,j  switch
            // ------------------
            // 0,0 -> 0,2       Y
            // 0,1 -> 1,2       Y
            // 0,2 -> 2,2       Y
            // 1,0 -> 0,1       Y
            // 1,1 -> 1,1       Y
            // 1,2 -> 2,1       N
            // 2,0 -> 0,0       N
            // 2,1 -> 1,0       N
            // 2,2 -> 2,0       N
            //
            // move all four points in single iteration
            // ----------------------------------------
            //
            //   TL --> TR
            //   ^      |
            //   |      v
            //   BL <-- BR
            //

            var length = matrix.Length;

            // iterate half rows only
            // (other half will be handled within processing first half)
            for (var row = 0; row < length / 2; row++)
            {
                var lastRowIndex = length - row - 1;

                // iterate over less columns on further rows
                // (processing half of the matrix, split diagonally)
                for (var col = row; col < length - row - 1; col++)
                {
                    var lastColIndex = length - col - 1;

                    // keep "top left" value
                    var tmp = matrix[row][col];

                    // move "bottom left" to "top left"
                    matrix[row][col] = matrix[lastColIndex][row];

                    // move "bottom right" to "bottom left"
                    matrix[lastColIndex][row] = matrix[lastRowIndex][lastColIndex];

                    // move "top right" to "bottom right"
                    matrix[lastRowIndex][lastColIndex] = matrix[col][lastRowIndex];

                    // move "top left" to "top right"
                    matrix[col][lastRowIndex] = tmp;
                }
            }
        }
    }
}
