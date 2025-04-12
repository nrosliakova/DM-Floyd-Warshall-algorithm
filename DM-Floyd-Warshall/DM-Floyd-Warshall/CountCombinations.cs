using System.Diagnostics;
namespace DM_Floyd_Warshall;

public class CountCombinations
{
    public void CreateTable()
    {
        List<Combination> combinations = new List<Combination>();
        List<double> averages = new List<double>();
        

        int n = 0;
        while (n!=20)
        {
            string[] combo = Console.ReadLine().Split('/');
            int vertAmount = Convert.ToInt32(combo[0]);
            double density = Convert.ToDouble(combo[1]);
            Combination combination = new Combination(vertAmount, density*100);
            combinations.Add(combination);
            n++;

        }
        long[,] counting = new long[20,combinations.Count];
        string combosToTable = "";
        using (StreamWriter writer = new StreamWriter("/Users/darynaburdak/Desktop/table.csv"))
        {
            foreach (var combination in combinations)
            {
                combosToTable += combination.VertAmount;
                combosToTable += "/";
                combosToTable += combination.Density;
                combosToTable += ",";
            }

            writer.WriteLine(combosToTable);



            for (int i = 0; i < combinations.Count; i++)
            {
                n = 0;
                while (n != 20)
                {
                    counting[n, i] = CountingForCombo(combinations[i]);
                    n ++;
                }
            }

            string row = "";
            for (int k = 0; k < 20; k++)
            {
                row = "";
                for (int i = 0; i < combinations.Count; i++)
                {
                    row += counting[k, i];
                    row += ",";
                }
                writer.WriteLine(row);
            }
            writer.WriteLine();

            row = "";
            for (int k = 0; k < combinations.Count(); k++)
            {
                long sum = 0;
                for (int i = 0; i < 20; i++)
                {
                    sum += counting[i, k];
                    
                }
                
                double average = sum / 20;
                row += average ;
                row += ",";
            }
            writer.WriteLine(row);

        }


    }

    public long CountingForCombo(Combination combo)
    {
        Stopwatch stopwatch = new Stopwatch();
        GenerateGraph generator = new GenerateGraph();
        var matrix = generator.Generate(combo.VertAmount, combo.Density);
    
        Solve solver = new Solve();
        stopwatch.Start();
        var distancematrix = solver.SolveMatrix(matrix);
        stopwatch.Stop();
        return stopwatch.ElapsedTicks;
    }
}