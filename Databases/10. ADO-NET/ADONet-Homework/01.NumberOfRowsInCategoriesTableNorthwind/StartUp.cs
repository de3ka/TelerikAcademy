using System;
using System.Data.SqlClient;

namespace _01.NumberOfRowsInCategoriesTableNorthwind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection(
                    "Server=.; " +
                    "Database=Northwind; " +
                    "Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT COUNT(*) FROM Categories", dbCon);

                int categoriesCount = (int)command.ExecuteScalar();

                Console.WriteLine("Categories count: {0}", categoriesCount);
            }
        }
    }
}
