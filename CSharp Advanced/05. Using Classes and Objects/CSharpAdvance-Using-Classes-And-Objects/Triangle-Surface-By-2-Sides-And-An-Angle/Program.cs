using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_Surface_By_2_Sides_And_An_Angle
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstSide = double.Parse(Console.ReadLine());
            double secondSide = double.Parse(Console.ReadLine());
            double angle = double.Parse(Console.ReadLine());
            const double deg = Math.PI / 180;
            double sin = Math.Sin(angle * deg);

            double area = (firstSide * secondSide*sin ) / 2;
            Console.WriteLine("{0:F2}", area);
        }
    }
}
