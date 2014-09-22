/*Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by name and adding a book.*/

namespace T09MySQLConnection
{
    using System;
    using MySql.Data.MySqlClient;

    class MainEntry
    {
        private static string connectionString = "server=127.0.0.1;uid=root;pwd=root;database=BookList"; //Change the password to suit your needs.

        static void Main(string[] args)
        {
            ListAllBooks();
            FindBookByName("words");
            //InsertBook("Starship Troopers", "Robert A. Heinlein", new DateTime(1959, 12, 1), "0450025764");
            //ListAllBooks();
        }

        public static void ListAllBooks()
        {
            MySqlConnection myCon = new MySqlConnection(connectionString);      
            myCon.Open();
            using (myCon)
            {
                string commandContent = "SELECT * FROM Books";
                MySqlCommand command = new MySqlCommand(commandContent, myCon);
                Console.WriteLine("++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine("Listing all books");
                Console.WriteLine("\n--------------------------------\n");
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Book ID: {0}\nTitle: {1}\nAuthor: {2}\nPublished: {3}\nISBN: {4}", reader.GetString("BookID"), 
                        reader.GetString("Title"), reader.GetString("Author"), reader.GetDateTime("PublishDate"), reader.GetString("ISBN"));
                    Console.WriteLine("\n--------------------------------\n");
                }
            }
            myCon.Close();
        }

        public static void FindBookByName(string name)
        {
            MySqlConnection myCon = new MySqlConnection(connectionString);
            myCon.Open();
            using (myCon)
            {
                string commandContent = "SELECT * FROM Books WHERE title LIKE @title";
                MySqlCommand command = new MySqlCommand(commandContent, myCon);
                command.Parameters.AddWithValue("@title", "%" + name + "%");
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine("Books with \"{0}\" in the title:", name);
                Console.WriteLine("\n--------------------------------\n");
                while (reader.Read())
                {
                    Console.WriteLine("Book ID: {0}\nTitle: {1}\nAuthor: {2}\nPublished: {3}\nISBN: {4}", reader.GetString("BookID"),
                        reader.GetString("Title"), reader.GetString("Author"), reader.GetDateTime("PublishDate"), reader.GetString("ISBN"));
                    Console.WriteLine("\n--------------------------------\n");
                }
            }
            myCon.Close();
        }

        public static void InsertBook(string title, string author, DateTime publishDate, string isbn)
        {
            MySqlConnection myCon = new MySqlConnection(connectionString);
            myCon.Open();
            using (myCon)
            {
                string commandContent = 
                    "INSERT INTO Books (Title, Author, PublishDate, ISBN) " + 
                    "VALUES (@title, @author, @publish, @isbn)";
                MySqlCommand command = new MySqlCommand(commandContent, myCon);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@publish", publishDate);
                command.Parameters.AddWithValue("@isbn", isbn);                
                Console.WriteLine("++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine("Inserting a book:\n");
                command.ExecuteNonQuery();                
            }
            myCon.Close();
        }
    }
}
