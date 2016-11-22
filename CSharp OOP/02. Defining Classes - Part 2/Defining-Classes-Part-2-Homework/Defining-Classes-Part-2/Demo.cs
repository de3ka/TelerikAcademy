using System;
using Defining_Classes_Part_2._01_04_Structure;
using Defining_Classes_Part_2._05_07_Generic_Class;
using Defining_Classes_Part_2._08_10_Matrix;
using Defining_Classes_Part_2._11_Version_Attribute;

namespace Defining_Classes_Part_2
{
    [Version_Attribute(1, 5)]
    public class Demo
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("**********TASK1**********\n");

            Console.WriteLine("-----POINT COORDINATES-----");
            Point3D p = new Point3D(3, 5, 6);
            Console.WriteLine(p.ToString());

            Console.WriteLine("\n**********TASK2**********\n");

            Console.WriteLine("-----ZERO POINT COORDINATES-----");
            Point3D zeroPoint = new Point3D();
            Console.WriteLine(zeroPoint.ToString());

            Console.WriteLine("\n**********TASK3**********\n");

            Console.WriteLine("-----POINT ONE COORDINATES-----");

            Point3D p1 = new Point3D(8, 6, 4);
            Console.WriteLine(p1.ToString());

            Console.WriteLine("-----POINT TWO COORDINATES-----");

            Point3D p2 = new Point3D(2, 3.4, 0);
            Console.WriteLine(p2.ToString());

            Console.WriteLine("-----THE DISTANCE BETWEEN TWO POINTS-----");

            var distance = CalculateDistanceBetween2Points.DistansBetweenTowPoints(p1, p2);
            Console.WriteLine("{0}", distance);

            Console.WriteLine("\n**********TASK4**********\n");

            Path path = new Path();
            path.AddPoint(new Point3D(1, 2, 3));
            path.AddPoint(new Point3D(6, 8, 6));
            path.AddPoint(new Point3D(2, 5, 7));
            path.AddPoint(new Point3D(1, 2, 0));

            Console.WriteLine("-----SAVING POINTS COORDINATES TO FILE-----");

            PathStorage.SavePath(path, "file");
            Path loadedPath = PathStorage.LoadPath("file");

            Console.WriteLine("-----LOADING POINTS COORDINATES FROM FILE-----");

            foreach (var item in loadedPath.PointList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n**********TASK5**********\n");

            GenericList<int> genericList = new GenericList<int>(5);
            genericList.AddElement(5);
            genericList.AddElement(11);

            Console.WriteLine("---ADDING ELEMENT TO THE LIST---");
            Console.WriteLine("{0}", genericList[0]);
            Console.WriteLine("---ADDING ELEMENT TO THE LIST---");
            Console.WriteLine("{0}", genericList[1]);
            Console.WriteLine("{0}", genericList.ToString());

            Console.WriteLine("---REMOVING ELEMENT FROM THE LIST---");
            Console.WriteLine("Element value: {0}\nRemoved from position: {1}", genericList[0], 0);

            genericList.RemoveElementByIndex(0);
            Console.WriteLine("{0}", genericList.ToString());

            genericList.InsertElementAtPosition(0, 100);
            Console.WriteLine("Element {0} is inserted at position {1}", genericList[0], 0);
            Console.WriteLine("{0}", genericList.ToString());

            genericList.AddElement(5);
            genericList.AddElement(1);
            genericList.AddElement(2);
            genericList.AddElement(3);

            Console.WriteLine("Element's index is: {0}", genericList.FindElementByItsValue(100));
            Console.WriteLine("Element value is: {0}\n", genericList[0]);
            Console.WriteLine("Element's index is: {0}", genericList.FindElementByItsValue(11));
            Console.WriteLine("Element value is: {0}\n", genericList[1]);
            Console.WriteLine("{0}", genericList.ToString());

            genericList.ClearAllElements();
            Console.WriteLine("{0}", genericList.ToString());
            
            Console.WriteLine("**********TASK6**********\n");

            Console.WriteLine("---THE LIST IS GROWING AUTOMATICALY---");

            Console.WriteLine("\n**********TASK7**********\n");

            genericList.AddElement(5);
            genericList.AddElement(1);
            genericList.AddElement(2);
            genericList.AddElement(3);
            genericList.AddElement(231);

            Console.WriteLine("{0}", genericList.ToString());
            Console.WriteLine("{0}", genericList.Min());
            Console.WriteLine("{0}", genericList.Max());

            Console.WriteLine("\n**********TASK8**********\n");

            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            matrix1[0, 0] = 5;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 15;

            Console.WriteLine("-----MATRIX 1-----");
            Console.WriteLine(matrix1.ToString());

            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            matrix2[0, 0] = 6;
            matrix2[0, 1] = 7;
            matrix2[1, 0] = -5;
            matrix2[1, 1] = 0;

            Console.WriteLine("-----MATRIX 2-----");
            Console.WriteLine(matrix2.ToString());

            Console.WriteLine("\n**********TASK9**********\n");

            Console.WriteLine("-----ACCESSING ELEMENTS OF MATRIX 1-----");
            Console.WriteLine(matrix1[0, 0] + ", " + matrix1[0, 1] + ", " + matrix1[1, 0] + ", " + matrix1[1, 1]);

            Console.WriteLine("-----ACCESSING ELEMENTS OF MATRIX 2-----");
            Console.WriteLine(matrix2[0, 0] + ", " + matrix2[0, 1] + ", " + matrix2[1, 0] + ", " + matrix2[1, 1]);

            Console.WriteLine("\n**********TASK10**********\n");

            Console.WriteLine("-----MATRIX 1 + MATRIX 2-----");
            Console.WriteLine(matrix1 + matrix2);

            Console.WriteLine("-----MATRIX 1 - MATRIX 2-----");
            Console.WriteLine(matrix1 - matrix2);

            Console.WriteLine("-----MATRIX 1 * MATRIX 2-----");
            Console.WriteLine(matrix1 * matrix2);

            Console.WriteLine("-----CHECKING FOR TRUE/FALSE IN MATRIX 1-----");
            Console.WriteLine("(If there is zero in the matrix the result is False)");

            if (matrix1)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            Console.WriteLine("-----CHECKING FOR TRUE/FALSE IN MATRIX 2-----");
            Console.WriteLine("(If there is zero in the matrix the result is False)");

            if (matrix2)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            Console.WriteLine("\n**********TASK11**********\n");

            var type = typeof(Demo);
            var attributes = type.GetCustomAttributes(false);

            foreach (Version_Attribute atr in attributes)
            {
                Console.WriteLine("Version: {0}", atr.ToString());
            }
        }
    }
}
