namespace DM_Floyd_Warshall;

public class GenerateGraph
{
    public int[,] Generate(int vertexNumber, double density)
    {
        int edgesNumber = (int)((density * vertexNumber * (vertexNumber - 1)) / 2);
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
        List<(int, int)> visited = new List<(int, int)>();
        while (visited.Count != edgesNumber*2)
        {
            Random rand = new Random();
            int randomI = rand.Next(0, vertexNumber);
            int randomJ = rand.Next(0, vertexNumber);

            if (!visited.Contains((randomI, randomJ)) && !visited.Contains((randomJ, randomI)) && randomI != randomJ)
            {
                int value = rand.Next(1, 10);
                matrix[randomI, randomJ] = value;
                matrix[randomJ, randomI] = value;
                count++;
                visited.Add((randomI, randomJ));
                visited.Add((randomJ, randomI));
            }
        }
        Console.WriteLine($"Edges count:{count}");
        return matrix;
    }
}