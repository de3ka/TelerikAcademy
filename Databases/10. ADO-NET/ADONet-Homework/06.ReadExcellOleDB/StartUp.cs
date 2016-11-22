using System;
using System.Data.OleDb;

namespace _06.ReadExcellOleDB
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

                PrintResults(dbConnection, sheetName);
                
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