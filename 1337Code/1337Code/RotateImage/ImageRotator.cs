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
            // rotate 4 points:
            // A > B
            // ^   v
            // D < C
            //
            // x,y    x,y  ?
            // -------------
            // 0,0 -> 0,2  *
            // 0,1 -> 1,2  *
            // 0,2 -> 2,2  *
            // 1,0 -> 0,1  *
            // 1,1 -> 1,1  *
            // 1,2 -> 2,1
            // 2,0 -> 0,0
            // 2,1 -> 1,0
            // 2,2 -> 2,0

            var length = matrix.Length;
            for (var i = 0; i < length / 2; i++)
            {
                for (var j = i; j < length - i - 1; j++)
                {
                    // a = [i][j];
                    // b = [j][length - i - 1];
                    // c = [length - i - 1][length - j - 1];
                    // d = [length - j - 1][i];

                    var newX = length - i - 1;
                    var newY = length - j - 1;

                    var tmp = matrix[i][j];
                    matrix[i][j] = matrix[newY][i];
                    matrix[newY][i] = matrix[newX][newY];
                    matrix[newX][newY] = matrix[j][newX];
                    matrix[j][newX] = tmp;
                }
            }
        }
    }
}
