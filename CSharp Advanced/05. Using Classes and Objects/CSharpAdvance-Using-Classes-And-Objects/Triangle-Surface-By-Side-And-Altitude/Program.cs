using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle_Surface_By_Side_And_Altitude
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double altitude = double.Parse(Console.ReadLine());
            double result = (side * altitude) / 2;
            Console.WriteLine("{0:F2}",result);
        }
    }
}
