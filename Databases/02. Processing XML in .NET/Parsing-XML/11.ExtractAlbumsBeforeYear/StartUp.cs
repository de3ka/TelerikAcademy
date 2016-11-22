using System;
using System.Collections.Generic;
using System.Xml;

namespace _11.ExtractAlbumsBeforeYear
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = "../../../input-files/catalogue.xml";

            OldAlbumsPricesXPath(5, input);

        }

        private static void OldAlbumsPricesXPath(int years, string path)
        {
            string xPathQuery = "/catalogue/album";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList list = doc.SelectNodes(xPathQuery);

            List<string> albums = new List<string>();

            foreach (XmlNode node in list)
            {
                var year = int.Parse(node["year"].InnerText);
                if (year + 5 < DateTime.Now.Year)
                {
                    albums.Add("Album: " + node["name"].InnerText);
                    albums.Add("Artist: " + node["artist"].InnerText);
                    albums.Add("Year: " + node["year"].InnerText);
                    albums.Add("Price: " + node["price"].InnerText);
                    albums.Add("\n");
                }
            }

            Console.WriteLine("Prices of albums published 5 years ago:\n");
            foreach (var item in albums)
            {
                Console.WriteLine(item);
            }
        }
    }
}