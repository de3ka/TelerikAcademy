using System;
using System.Linq;
using System.Xml.Linq;

namespace _06.ExtractSongTitlesXDocumentAndLINQ
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string path = "../../../input-files/catalogue.xml";
            ExtractSongsNameLinq(path);
        }

        private static void ExtractSongsNameLinq(string path)
        {
            var xml = XDocument.Load(path);

            var songs = xml.Descendants()
                .Where(x => x.Name == "song")
                .OrderBy(x => x.Attribute("title").ToString())
                .Select(x => x.Attribute("title").Value);

            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}