using System;
using System.Text.RegularExpressions;

namespace Parse_URL
{
    public class ParseURL
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"^((?<protocol>[a-z]+)://)?(?<server>[\w\.\-]+)(?<resource>[\w\.#=&\+\-%\/\?]+)?$";
            Match match = Regex.Match(input, pattern);

            string protocol = "";
            string server = "";
            string resource = "";

            if (match.Success)
            {
                protocol += match.Groups["protocol"].Value;
                server += match.Groups["server"].Value;
                resource += match.Groups["resource"].Value;
            }

            Console.WriteLine("[protocol] = {0}", protocol);
            Console.WriteLine("[server] = {0}", server);
            Console.WriteLine("[resource] = {0}", resource);
        }
    }
}
