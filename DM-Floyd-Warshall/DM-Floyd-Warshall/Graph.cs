
namespace DM_Floyd_Warshall;

public static class Graph
{
    public static void PrintMatrix(int[,] matrix, int rowLength)
    {
        var n = 1;
        foreach (var el in matrix)
        {
            if (n == rowLength + 1)
            {
                Console.Write("\n");
                n = 1;
            }
            Console.Write($"{el} ");
            n++;
        }
        Console.Write("\n");
    }
    public static void PrintList(Dictionary<int, List<(int vertex, int weight)>> adjacencyList)
    {
       foreach(var pair in adjacencyList)
       {
            var current_vertex = pair.Key;
            var neighbours = pair.Value;
            Console.Write($"{current_vertex} -> ");

            foreach (var edge in neighbours)
            {
                var neibhor_vertex = edge.vertex;
                var edge_weight = edge.weight;
                if (edge_weight == int.MaxValue)
                    continue;
                Console.Write($"{neibhor_vertex} (weight = {edge_weight}); ");
            }
            Console.WriteLine();
       }
    }
    public static Dictionary<int, List<(int vertex, int weight)>> ConvertMatrixToList(int[,] matrix, int vertexAmount)
    {
        Dictionary<int, List<(int vertex, int weight)>> adjacencyList = new();
        var edgeList = new List<(int vertex, int weight)>();
        for (var i = 0; i < vertexAmount; i++)
        {
            edgeList = new();
            for (var j = 0; j < vertexAmount; j++)
            {
                edgeList.Add((j, matrix[i, j]));
            }
            adjacencyList[i] = edgeList;
        }
        return adjacencyList;
    }
    public static int[,] ConvertListToMatrix(Dictionary<int, List<(int vertex, int weight)>> adjacencyList)
    {
        int vertexAmount = adjacencyList.Count;
        var matrix = new int[vertexAmount, vertexAmount];
        foreach (var element in adjacencyList)
        {
            var row_vertex = element.Key;
            var neighbours = element.Value;
            foreach (var edge in neighbours)
            {
                var column_vertex = edge.vertex;
                var edge_weight = edge.weight;
                matrix[row_vertex, column_vertex] = edge_weight;
            }
        }
        return matrix;
    }

}