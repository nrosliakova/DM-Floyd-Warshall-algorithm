namespace DM_Floyd_Warshall;

public class Solve
{
    public int[,] SolveMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (var k = 0; k < n; k++)
        {
            for (var i = 0; i < n; i++)
            {
                if (matrix[i, k] == int.MaxValue) continue;
                for (var j = n-1; j >= i; j--)
                {
                    var now = matrix[i, j];
                    var left = matrix[i, k];
                    var up = matrix[k, j];
                    if (matrix[k, j] == int.MaxValue) continue;

                    matrix[i, j] = Math.Min(now, left + up);
                    matrix[j, i] = matrix[i, j];
                }
            }
        }

        return matrix;
    }
}