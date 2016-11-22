using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _16.ValidateXmlAgainstXsd
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var xmlSchemaName = new XmlSchemaSet();
            xmlSchemaName.Add(string.Empty, "../../../input-files/catalogue.xsd");

            XDocument doc = XDocument.Load("../../../input-files/catalogue.xml");
            XDocument invalidDoc = XDocument.Load("../../../input-files/invalid-catalogue.xml");

            PrintValidationResult(doc, xmlSchemaName);
            Console.WriteLine(new string('-', 20));
            PrintValidationResult(invalidDoc, xmlSchemaName);

        }

        private static void PrintValidationResult(XDocument doc, XmlSchemaSet xmlSchema)
        {
            bool errors = false;
            doc.Validate(xmlSchema, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            }, true);

            Console.WriteLine("doc {0}\n", errors ? "did not validate" : "validated");
        }
    }
}