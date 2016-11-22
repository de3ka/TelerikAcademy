using System;

namespace Defining_Classes_Part_2._01_04_Structure
{
    public struct Point3D
    {
        private static readonly Point3D zeroPoint;
        private double x;
        private double y;
        private double z;

        static Point3D()
        {
            zeroPoint = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
        }

        public static Point3D Parse(string pointToParse)
        {
            string[] splittedPoint = pointToParse.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Point3D resultPoint = new Point3D(double.Parse(splittedPoint[0]),
                                              double.Parse(splittedPoint[1]),
                                              double.Parse(splittedPoint[2]));
            return resultPoint;
        }
    }
}