using System;
using System.Collections.Generic;
using System.Xml;

namespace _03.ExtractArtistsXPath
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            GetAllArtistsFromFileXPath(path);

        }

        private static void GetAllArtistsFromFileXPath(string path)
        {
            Dictionary<string, int> artistAlbums = new Dictionary<string, int>();
            string xPathQuery = "/catalogue/album";

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList root = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in root)
            {
                var artist = node["artist"].InnerText;
                if (!artistAlbums.ContainsKey(artist))
                {
                    artistAlbums.Add(artist, 0);
                }

                artistAlbums[artist]++;
            }

            foreach (var item in artistAlbums)
            {
                Console.WriteLine($"Artist: {item.Key}\nNumber of albums: {item.Value} albums\n");
            }
        }
    }
}