namespace Entretien
{
    public static class MtfSimulator
    {
        public static double[] GenerateScenario(double p0, int horizon, double variation)
        {
            var scenario = new double[horizon];
            var randomGenerator = new Random();
            for (var i = 0; i < horizon; i++)
            {
                var factor = randomGenerator.NextDouble() * randomGenerator.Next(-1, 2);
                var previousPrice = i > 0 ? scenario[i - 1] : p0;
                scenario[i] = previousPrice * (1 + factor * variation);
            }
            return scenario;
        }

        public static double[,] GenerateMtf(double p0, int horizon, double variation, int nbScenarios)
        {
            var mtf = new double[nbScenarios, horizon];
            for (var i = 0; i < nbScenarios; i++)
            {
                var scenario = GenerateScenario(p0, horizon, variation);
                for (var j = 0; j < scenario.Length; j++)
                    mtf[i, j] = scenario[j];
            }
            return mtf;
        }

        public static Statistics CalculateStatistics(double[,] mtf)
        {
            var horizon = mtf.GetLength(1);
            var statistics = new Statistics(horizon);

            for (var i = 0; i < horizon; i++)
            {
                var column = mtf.GetColumn(i);
                var average = column.Average();
                statistics.AverageInTime[i] = average;
                statistics.StandardDeviationInTime[i] = column.StandardDeviation(average);
            }
            return statistics;
        }
    }
}
