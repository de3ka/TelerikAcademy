using System.Collections.Generic;

namespace Defining_Classes_Part_2._01_04_Structure
{
    public class Path
    {
        private List<Point3D> pointList;

        public Path()
        {
            this.PointList = new List<Point3D>();
        }

        public List<Point3D> PointList
        {
            get { return this.pointList; }
            set { this.pointList = value; }
        }

        public void AddPoint(Point3D p)
        {
            this.PointList.Add(p);
        }
    }
}