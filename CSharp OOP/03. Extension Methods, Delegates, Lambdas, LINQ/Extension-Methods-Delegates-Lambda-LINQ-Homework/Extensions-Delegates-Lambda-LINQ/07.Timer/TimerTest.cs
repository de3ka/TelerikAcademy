using System;

namespace Extensions_Delegates_Lambda_LINQ._07.Timer
{
    public class TimerTest
    {
        public static void Test()
        {
            Console.WriteLine("\n**********TASK7**********");
            Timer timer = new Timer(1);
            timer.InvokeDelegate();
        }
    }
}
