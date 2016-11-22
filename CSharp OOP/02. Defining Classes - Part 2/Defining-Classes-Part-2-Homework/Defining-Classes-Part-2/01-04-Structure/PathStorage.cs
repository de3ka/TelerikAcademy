using System.IO;

namespace Defining_Classes_Part_2._01_04_Structure
{
    public static class PathStorage
    {
        public static void SavePath(Path path, string fileName)
        {
            using (StreamWriter sw = new StreamWriter("..//..//" + fileName + ".txt"))
            {
                for (int i = 0; i < path.PointList.Count; i++)
                {
                    sw.WriteLine(path.PointList[i]);
                }
            }
        }

        public static Path LoadPath(string filePath)
        {
            filePath = "..//..//" + filePath + ".txt";
            Path path = new Path();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.EndOfStream == false)
                {
                    string nextPointTxt = sr.ReadLine();
                    Point3D nextPoint = Point3D.Parse(nextPointTxt);
                    path.AddPoint(nextPoint);
                }
            }

            return path;
        }
    }
}

