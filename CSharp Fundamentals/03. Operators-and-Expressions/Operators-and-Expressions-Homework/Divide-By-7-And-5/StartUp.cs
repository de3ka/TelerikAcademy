using System;

namespace Divide_By_7_And_5
{
    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            //bool divide = true;
            if (num % 7 == 0 && num % 5 == 0)
            {
                Console.WriteLine("true" + " {0}", num);
            }
            else
            {
                Console.WriteLine("false" + " {0}", num);
            }
        }
    }
}
