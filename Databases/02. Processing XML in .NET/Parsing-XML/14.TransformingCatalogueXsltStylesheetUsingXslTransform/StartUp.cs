using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace _14.TransformingCatalogueXsltStylesheetUsingXslTransform
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            XDocument xDoc = XDocument.Load("../../../input-files/catalogue.xml");

            XDocument transformedDoc = new XDocument();
            using (XmlWriter writer = transformedDoc.CreateWriter())
            {
                XslCompiledTransform transform = new XslCompiledTransform();
                transform.Load(XmlReader.Create(new StreamReader("../../../input-files/catalogue-style.xslt")));
                transform.Transform(xDoc.CreateReader(), writer);
            }

            transformedDoc.Save("../../../output-files/transformed-catalogue.html");
            Console.WriteLine("Html saved. Please open output-files/transformed-catalogue.html in browser");
        }
    }
}