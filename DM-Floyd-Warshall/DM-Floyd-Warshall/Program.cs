using System.Diagnostics;
namespace DM_Floyd_Warshall;
internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        GenerateGraph generator = new GenerateGraph();
        var matrix = generator.Generate(172, 0.7);
        Graph.PrintMatrix(matrix, matrix.GetLength(0));
    
        Solve solver = new Solve();
        Console.WriteLine("\nSolved matrix:");
        stopwatch.Start();
        var distancematrix = solver.SolveMatrix(matrix);
        stopwatch.Stop();
        Graph.PrintMatrix(distancematrix, distancematrix.GetLength(0));
        Console.WriteLine($"\nЧас виконання: {stopwatch.ElapsedTicks} мс або {stopwatch.ElapsedMilliseconds}");
        CountCombinations creator = new CountCombinations();
        //creator.CreateTable();
    }
}
