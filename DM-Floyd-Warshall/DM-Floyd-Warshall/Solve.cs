namespace DM_Floyd_Warshall;

public class Solve
{
    public static int solve(int n, int m, int s, int d, List<(int vertex1, int vertex2, int weight)> edges)
    {
        if (s == d) return 0;
        var matrix = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
            {
                if(i==j)
                    matrix[i, j] = 0;
                else
                    matrix[i, j] = int.MaxValue;
            }

        foreach(var edge in edges)
        {
            matrix[edge.vertex1 - 1, edge.vertex2 - 1] = edge.weight;
            matrix[edge.vertex2 - 1, edge.vertex1 - 1] = edge.weight;
        }

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

        return matrix[s - 1, d - 1];
    }
}