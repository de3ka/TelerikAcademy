using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Replace_Tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
      
            string replacePattern = "[$2]($1)";
            text = Regex.Replace(text, @"<a .*?href=['""](.+?)['""].*?>(.+?)</a>", replacePattern);
            Console.WriteLine(text);

        }
    }
}
