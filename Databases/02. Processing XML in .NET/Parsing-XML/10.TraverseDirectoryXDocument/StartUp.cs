using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _10.TraverseDirectoryXDocument
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string path = @"../../../../Parsing-XML";

            var doc = new XDocument();
            var el = new XElement("dir");
            el.Add(new XAttribute("name", path));
            GetAllFilesAndFoldersRecursivelyXDocument(new DirectoryInfo(path), el);
            doc.Add(el);

            doc.Save("../../../output-files/directories-xdocument.xml");

            Console.WriteLine("XML created. For details view output-files/directories-xdocument.xml");
        }

        private static void GetAllFilesAndFoldersRecursivelyXDocument(DirectoryInfo path, XElement el)
        {
            var files = new XElement("files");

            try
            {
                foreach (FileInfo file in path.GetFiles())
                {
                    files.Add(new XElement("file", file.Name));
                }

                if (path.GetFiles().Any())
                {
                    el.Add(files);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Directory {0}  \n could not be accessed!", path.FullName);
                return;
            }
            
            foreach (DirectoryInfo dir in path.GetDirectories())
            {
                var el1 = new XElement("dir");
                el1.Add(new XAttribute("name", dir.Name));
                el.Add(el1);
                GetAllFilesAndFoldersRecursivelyXDocument(dir, el1);
            }

        }
    }
}