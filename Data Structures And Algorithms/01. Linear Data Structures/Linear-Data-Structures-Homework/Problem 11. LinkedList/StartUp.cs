using System;

namespace Problem_11.LinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var list = new LinkedList<int>();

            var firstElement = new ListItem<int> { Value = 1 };
            var secondElement = new ListItem<int> { Value = 2 };
            var thirdElement = new ListItem<int> { Value = 3 };
            var fourthElement = new ListItem<int> { Value = 4 };

            thirdElement.NextItem = fourthElement;
            secondElement.NextItem = thirdElement;
            firstElement.NextItem = secondElement;
            list.FirstElement = firstElement;

            Console.WriteLine("Elements of the list: ");
            var element = list.FirstElement;
            Console.Write("{0}", element.Value);

            while (element.NextItem != null)
            {
                element = element.NextItem;
                Console.Write("-{0}", element.Value);
            }

            Console.WriteLine();
        }
    }
}