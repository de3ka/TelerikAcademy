using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correct_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            char[] exp = expression.ToCharArray();
            Stack<int> st = new Stack<int>();
            bool areAllBacketsCorrect = true;
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    st.Push(i);
                }
                else if (exp[i] == ')')
                {
                    if (st.Count == 0)
                    {
                        areAllBacketsCorrect = false;
                        break;
                    }
                    st.Pop();
                }
            }
            if (!(st.Count == 0))
            {
                areAllBacketsCorrect = false;
            }
            if (areAllBacketsCorrect)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
            
        }
    }
}
