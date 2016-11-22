using System;
using _01.Shapes.Shapes;

namespace _01.Shapes
{
    public class Demo
    {
        static void Main(string[] args)
        {
            Shape[] shapes = {
            new Triangle(2.6, 4.7),
            new Rectangle(5.3, 9.6),
            new Square(4),
            new Rectangle(25.4, 35.8),
            new Triangle(32.09, 2),
            new Square(5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}: Surface: {1:F2}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
