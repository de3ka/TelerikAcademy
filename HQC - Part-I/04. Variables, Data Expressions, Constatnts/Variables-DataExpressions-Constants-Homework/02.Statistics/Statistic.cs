using System.Linq;
using Statistics.Contracts;

namespace Statistics
{
    public class Statistic
    {
        private IPrinter printer;

        public Statistic(IPrinter printer)
        {
            this.printer = printer;
        }

        public void PrintStatistics(double[] data)
        {
            if (data.Length == 0)
            {
                return;
            }

            var maximumValue = data.Max();
            var minimumValue = data.Min();
            var averageValue = data.Average();

            this.printer.Print("Minimum Value: ", minimumValue);
            this.printer.Print("Maximum Value: ", maximumValue);
            this.printer.Print("Average Value: ", averageValue);
        }
    }
}