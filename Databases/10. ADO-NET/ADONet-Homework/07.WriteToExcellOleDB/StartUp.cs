using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.WriteToExcellOleDB
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\scores.xlsx;Extended Properties=Excel 12.0 XML";

            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                dbConnection.Open();

                var excelSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

                AddToExcell(dbConnection, sheetName, "Miro", 10);
                PrintResults(dbConnection, sheetName);

            }
        }
        public static void AddToExcell(OleDbConnection dbConnection, string sheetName, string userName, int score)
        {
            var addResultOleDbCommand = new OleDbCommand($"INSERT INTO [{sheetName}] VALUES(@Name, @Score)", dbConnection);
            addResultOleDbCommand.Parameters.AddWithValue("@Name", $"{userName}");
            addResultOleDbCommand.Parameters.AddWithValue("@Score", $"{score}");

            try
            {
                var rowsAffected = addResultOleDbCommand.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
            }
            catch (OleDbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void PrintResults(OleDbConnection dbConnection, string sheetName)
        {
            var allResultsOleDbCommand = new OleDbCommand($"SELECT * FROM [{sheetName}]", dbConnection);

            using (var reader = allResultsOleDbCommand.ExecuteReader())
            {
                reader.Read();
                while (reader.Read())
                {
                    Console.WriteLine($"name: {reader["Name"]}, score: {reader["Score"]}");
                }
            }
        }
    }
}