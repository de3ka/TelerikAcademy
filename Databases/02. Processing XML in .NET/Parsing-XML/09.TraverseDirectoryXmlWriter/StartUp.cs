using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _09.TraverseDirectoryXmlWriter
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var writer = XmlWriter.Create("../../../output-files/directories.xml", new XmlWriterSettings() { Indent = true, NewLineChars = Environment.NewLine });
            string path = @"../../../../Parsing-XML";

            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("dirs");
                writer.WriteAttributeString("name", path);
                GetAllFilesAndFoldersRecursively(
                    new DirectoryInfo(path), writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();

                Console.WriteLine("XML created. For details view output-files/directories.xml");
            }
        }

        private static void GetAllFilesAndFoldersRecursively(DirectoryInfo path, XmlWriter writer)
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", path.Name);

            try
            {
                writer.WriteStartElement("files");
                foreach (FileInfo file in path.GetFiles())
                {
                    writer.WriteStartElement("file");
                    writer.WriteElementString("name", file.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            catch (IOException)
            {
                Console.WriteLine("Directory {0}  \n could not be accessed!", path.FullName);
                return;
            }
            
            foreach (DirectoryInfo dir in path.GetDirectories())
            {
                path = dir;
                GetAllFilesAndFoldersRecursively(dir, writer);
            }

            writer.WriteEndElement();
        }
    }
}