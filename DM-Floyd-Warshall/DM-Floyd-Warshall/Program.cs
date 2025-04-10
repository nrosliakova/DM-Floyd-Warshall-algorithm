
namespace DM_Floyd_Warshall;
internal class Program
{
    static void Main(string[] args)
    {
        GenerateGraph generator = new GenerateGraph();
        var matrix = generator.Generate(10, 2);
        Graph.PrintMatrix(matrix, 10);
        var aList = Graph.ConvertMatrixToList(matrix, 5);
        Graph.PrintList(aList);
        var m2 = Graph.ConvertListToMatrix(aList);
        Graph.PrintMatrix(m2, 5);

        Solve solver = new Solve();
        Console.WriteLine("\nSolved matrix:");
        var distancematrix = solver.SolveMatrix(matrix);
        Graph.PrintMatrix(distancematrix, distancematrix.GetLength(0));
    }
}
