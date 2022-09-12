using System.Text;

namespace Entretien
{
    public class Statistics
    {
        public Statistics(int length)
        {
            AverageInTime = new double[length];
            StandardDeviationInTime = new double[length];
        }

        public double[] AverageInTime { get; set; }

        public double[] StandardDeviationInTime { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"AVG : {string.Join("|", AverageInTime.Select(x => Math.Round(x, 2)))}");
            builder.AppendLine();
            builder.AppendLine($"STD : {string.Join("|", StandardDeviationInTime.Select(x => Math.Round(x, 2)))}");
            return builder.ToString();
        }
    }
}
