namespace Entretien
{
    internal static class Helper
    {
        internal static double[] GetColumn(this double[,] array, int columnIdx)
        {
            var length = array.GetLength(0);
            var column = new double[length];
            for (var i = 0; i < length; i++)
                column[i] = array[i, columnIdx];
            return column;
        }

        internal static double[] GetRow(this double[,] array, int rowIdx)
        {
            var length = array.GetLength(1);
            var row = new double[length];
            for (var i = 0; i < length; i++)
                row[i] = array[rowIdx, i];
            return row;
        }

        internal static double StandardDeviation(this double[] array, double average)
        {
            double sumOfSquaresOfDifferences = array.Select(x => (x - average) * (x - average)).Sum();
            return Math.Sqrt(sumOfSquaresOfDifferences / array.Length);
        }
    }
}
