using CreateDBContext.Data;
using System;

namespace CopyNorthwind
{
    public class Test
    {
        static void Main(string[] args)
        {
            // Change "initial catalog=Northwind" to "initial catalog=NorthwindTwin" in App.congif file
            var ctx = new NorthwindEntities();

            ctx.Database.CreateIfNotExists();
            Console.WriteLine("Database NorthwindTwin created!");
        }
    }
}
