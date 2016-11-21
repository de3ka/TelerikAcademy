using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parse_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"^((?<protocol>[a-z]+)://)?(?<server>[\w\.\-]+)(?<resource>[\w\.#=&\+\-%\/\?]+)?$";
            Match m = Regex.Match(input, pattern);
            string protocol = "";
            string server = "";
            string resource = "";
            if (m.Success)
            {
                protocol += m.Groups["protocol"].Value;
                server += m.Groups["server"].Value;
                resource += m.Groups["resource"].Value;
            }
            Console.WriteLine("[protocol] = {0}", protocol);
            Console.WriteLine("[server] = {0}", server);
            Console.WriteLine("[resource] = {0}", resource);
        }
    }
}
