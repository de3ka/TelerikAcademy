using System;
using System.Xml;

namespace _04.DeleteAlbumsFromCatalogue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            decimal price = 20;
            string path = "../../../input-files/catalogueToDeleteExpensiveAlbums.xml";
            DeleteAllOverAPriceDOM(path, price);
        }

        private static void DeleteAllOverAPriceDOM(string path, decimal maxPrice)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlElement rootNode = doc.DocumentElement;

            foreach (XmlElement element in rootNode.ChildNodes)
            {
                if (decimal.Parse(element["price"].InnerText) > maxPrice)
                {
                    rootNode.RemoveChild(element);
                }
            }

            doc.Save(path);
            Console.WriteLine("Document saved. Check 'catalogueToDeleteExpensiveAlbums.xml' to view cheap albums.");
        }
    }
}
