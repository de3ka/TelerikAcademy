﻿using System;
using System.Data.SqlClient;

namespace _08.SearchInProductsNorthwind
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Inser a keyword to search for: ");
            var keyword = Console.ReadLine();

            SearchProducts(keyword);
        }

        private static void SearchProducts(string keyword)
        {
            SqlConnection dbCon = new SqlConnection(
                "Server=.; " +
                "Database=Northwind; " +
                "Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * " +
                  "FROM Products p " +
                  "WHERE CHARINDEX(@keyword, ProductName) > 0", dbCon);

                command.Parameters.AddWithValue("@keyword", keyword);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string product = (string)reader["ProductName"];
                        Console.WriteLine(product);
                    }
                }
            }
        }
    }
}
