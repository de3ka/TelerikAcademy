using System;

namespace Point_Circle_Rectangle
{
    public class StartUp
    {
        public static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            if (x >= -1000 && x <= 1000 || y >= -1000 && x <= 1000)
            {
                double circleRadius = 1.5;
                bool circle = (Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2) <= Math.Pow(circleRadius, 2));
                bool rectangle = ((x >= -1 && x <= 5) && (y >= -1 && y <= 1));
                if (circle == true && rectangle == false)
                {
                    Console.WriteLine("inside circle outside rectangle");
                }
                else if (circle == true && rectangle == true)
                {
                    Console.WriteLine("inside circle inside rectangle");

                }
                else if (circle == false && rectangle == true)
                {
                    Console.WriteLine("outside circle inside rectangle");
                }
                else
                {
                    Console.WriteLine("outside circle outside rectangle");
                }
            }
            else
            {

            }
        }
    }
}
