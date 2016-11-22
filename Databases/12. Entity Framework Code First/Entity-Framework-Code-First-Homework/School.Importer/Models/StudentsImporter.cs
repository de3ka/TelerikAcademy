﻿using School.Data;
using School.DatabaseContext;
using School.Importer.Interfaces;
using System;

namespace School.Importer.Models
{
    public static class StudentsImporter
    {
        public static void Import(SchoolDatabaseContext db, int count)
        {
            var generator = RandomGenerator.Instance;

            for (int i = 0; i < count; i++)
            {
                db.Students.Add(new Student()
                {
                    Name = generator.GetRandomString(5, 20),
                    Number = generator.GetRandomNumber(10000, 99999),
                });
            }

            db.SaveChanges();
            Console.WriteLine("{0} Students imported", count);
        }
    }
}
