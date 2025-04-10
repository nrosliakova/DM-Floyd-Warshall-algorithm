namespace DM_Floyd_Warshall;

public class GenerateGraph
{
    public int[,] Generate(int vertexNumber, int density)
    {
        int edgesNumber = (density * vertexNumber * (vertexNumber - 1)) / 2;
        int[,] matrix = new int[vertexNumber, vertexNumber];
        
        for (int i = 0; i < vertexNumber; i++)
        {
            for (int j = 0; j < vertexNumber; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = 0;
                }
                else
                {
                    matrix[i, j] = int.MaxValue;
                }
            }
        }

        for (int i = 0; i < edgesNumber-1; i++)
        {
            Random rand = new Random();
            int randomI = rand.Next(0, vertexNumber);
            int randomJ = rand.Next(0, vertexNumber);
            List<int> visitedI = new List<int>();
            List<int> visitedJ = new List<int>();

            if (!visitedI.Contains(randomI) && !visitedJ.Contains(randomJ) && matrix[randomI, randomJ] != 0)
            {
                matrix[randomI, randomJ] = rand.Next(1, 10);
                visitedI.Add(randomI);
                visitedJ.Add(randomJ);
            }
        }

        return matrix;
    }
}