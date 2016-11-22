using System;
using System.IO;
using System.Xml.Linq;

namespace _07.CreateXmlFromText
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = "../../../input-files/person.txt";
            string output = "../../../output-files/person.xml";

            GenerateXmlFromTextFile(input, output);
        }

        private static void GenerateXmlFromTextFile(string input, string output)
        {
            StreamReader reader = new StreamReader(input);

            var xml = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var root = new XElement("people");

            var line = reader.ReadLine();

            while (line != null)
            {
                var person = new XElement("person");
                person.Add(new XElement("name", line));
                line = reader.ReadLine();

                person.Add(new XElement("address", line));
                line = reader.ReadLine();

                person.Add(new XElement("phone", line));
                line = reader.ReadLine();

                root.Add(person);
            }

            xml.Add(root);

            Console.WriteLine(xml);

            xml.Save(output);
        }
    }
}