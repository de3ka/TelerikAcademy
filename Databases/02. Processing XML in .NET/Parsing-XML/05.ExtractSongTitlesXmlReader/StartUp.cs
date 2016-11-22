using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _05.ExtractSongTitlesXmlReader
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            ExtractAllSongsName(path);
        }

        private static void ExtractAllSongsName(string path)
        {
            var songs = new List<string>();
            
            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.Name == "song")
                    {
                        songs.Add(reader.GetAttribute("title"));
                    }
                }
            }
            songs = songs.OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, songs));
        }
    }
}