namespace DM_Floyd_Warshall;

public class GenerateGraph
{
    public int[,] Generate(int vertexNumber, double density)
    {
        int edgesNumber = (int)(density * vertexNumber * (vertexNumber - 1)) / 2;
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
        
        int count = 0;
        for (int i = 0; i < edgesNumber; i++)
        {
            Random rand = new Random();
            int randomI = rand.Next(0, vertexNumber-1);
            int randomJ = rand.Next(0, vertexNumber-1);
            List<int> visitedI = new List<int>();
            List<int> visitedJ = new List<int>();

            if (!visitedI.Contains(randomI) && !visitedJ.Contains(randomJ) && matrix[randomI, randomJ] != 0)
            {
                matrix[randomI, randomJ] = rand.Next(1, 10);
                count++;
                visitedI.Add(randomI);
                visitedJ.Add(randomJ);
            }
        }
        Console.WriteLine($"Edges count:{count}");
        return matrix;
    }
}