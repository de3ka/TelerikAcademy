using System;
using System.Collections.Generic;
using System.Xml;

namespace _02.ExtractArtists
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            GetAllArtistsFromFile(path);

        }

        private static void GetAllArtistsFromFile(string path)
        {
            Dictionary<string, int> artistAlbums = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
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