using System;
using HumanCreator.Models;

namespace HumanCreator
{
    internal class StartUp
    {
        internal static void Main()
        {
            var dude = Human.Create(25);
            var chick = Human.Create(22);

            Console.WriteLine(chick.Name);
            Console.WriteLine(dude.Name);
        }
    }
}
