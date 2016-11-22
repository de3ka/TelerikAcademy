using MySql.Data.MySqlClient;
using System;

namespace _09.BooksMySQL
{
    public class StartUp
    {
        public static void Main()
        {
            //set your pass and server
            //the script to the database is in the root folder
            //before importing the script make sure you've created a database named books (execute a query in workbench: CREATE DATABASE books;)
            MySqlConnection dbConnection = new MySqlConnection(
              "Server=127.0.0.1; Port=3306; Database=books; Uid = root; Pwd = root; pooling = true"); 
            dbConnection.Open();

            ListAllBooks(dbConnection);

            InsertBook(dbConnection, "Inferno", "Dan Brown", DateTime.Now, "99999999999");

            Console.WriteLine("Enter a keyword to search: ");
            string keyword = Console.ReadLine();
            SearchBooks(dbConnection, keyword);
        }

        private static void SearchBooks(MySqlConnection dbConnection, string keyword)
        {
            Console.WriteLine("Search for :{0}", keyword);

            var command = new MySqlCommand(
              "SELECT * " +
              "FROM Books " +
              "WHERE LOCATE(@keyword, Title)", dbConnection);

            command.Parameters.AddWithValue("@keyword", keyword);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishData"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate, isbn);
                }
            }
        }

        private static void ListAllBooks(MySqlConnection dbConnection)
        {
            Console.WriteLine("Listing all books:");

            var command = new MySqlCommand(@"SELECT * FROM Books", dbConnection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishData"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate, isbn);
                }
            }
        }

        private static void InsertBook(MySqlConnection dbConnection, string title, string author, DateTime publishDate, string isbn)
        {
            Console.WriteLine("Book inserted!");

            var command = new MySqlCommand(@"INSERT INTO Books (Title, Author, PublishData, isbn) VALUES (@title, @author, @date, @isbn) ", dbConnection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@date", publishDate);
            command.Parameters.AddWithValue("@isbn", isbn);

            command.ExecuteNonQuery();
        }
    }
}