namespace _01.Shapes.Shapes
{

    public class Square:Rectangle
    {
       public Square(double width)
            : base(width, width)
        {

        }
       public override double CalculateSurface()
       {
           return this.Width * this.Width;
       }
    }
}
