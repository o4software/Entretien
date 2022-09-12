using Entretien;

internal static class Program
{
    private static void Main()
    {
        var mtf = MtfSimulator.GenerateMtf(100, 20, 0.05, 10); // The limition here : the matrix max authorized size (horizon x nbScenarios) is 4 billion elements 

        for (var i = 0; i < 10; i++)
        {
            var row = mtf.GetRow(i);
            Console.WriteLine(String.Join("|", row.Select(x => Math.Round(x, 2))));
        }
        Console.WriteLine();
        Console.WriteLine();

        var statistics = MtfSimulator.CalculateStatistics(mtf);
        Console.WriteLine(statistics);
    
        Console.ReadKey();
    }
}
