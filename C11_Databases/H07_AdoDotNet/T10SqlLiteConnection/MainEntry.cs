namespace T10SqlLiteConnection
{
    using System;
    using System.Data.SQLite;

    class MainEntry
    {
        private static string pathToData = "Data Source=../../../SQLLiteDatabase";

        static void Main(string[] args)
        {
            ListAllBooks();
            FindBookByName("Words");
            InsertBook("Starship Troopers", "Robert A. Heinlein", new DateTime(1959, 12, 1), "0450025764");
            ListAllBooks();
        }

        public static void ListAllBooks()
        {
            SQLiteConnection connection = new SQLiteConnection(pathToData);
            connection.Open();
            using (connection)
            {
                string commandContent = "SELECT * FROM Books";
                SQLiteCommand command = new SQLiteCommand(commandContent, connection);
                Console.WriteLine("++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine("Listing all books");
                Console.WriteLine("\n--------------------------------\n");
                SQLiteDataReader reader = command.ExecuteReader();                
                while (reader.Read())
                {                    
                    Console.WriteLine("Book ID: {0}\nTitle: {1}\nAuthor: {2}\nPublished: {3}\nISBN: {4}", reader.GetInt32(0),
                        reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                    Console.WriteLine("\n--------------------------------\n");
                }
            }            
        }
        
        public static void FindBookByName(string name)
        {
            SQLiteConnection connection = new SQLiteConnection(pathToData);
            connection.Open();
            using (connection)
            {
                string commandContent = "SELECT * FROM Books WHERE title LIKE @title";
                SQLiteCommand command = new SQLiteCommand(commandContent, connection);
                command.Parameters.AddWithValue("@title", "%" + name + "%");
                SQLiteDataReader reader = command.ExecuteReader();
                Console.WriteLine("++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine("Books with \"{0}\" in the title:", name);
                Console.WriteLine("\n--------------------------------\n");
                while (reader.Read())
                {
                    Console.WriteLine("Book ID: {0}\nTitle: {1}\nAuthor: {2}\nPublished: {3}\nISBN: {4}", reader.GetInt32(0),
                        reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                    Console.WriteLine("\n--------------------------------\n");
                }
            }            
        }
        
        public static void InsertBook(string title, string author, DateTime publishDate, string isbn)
        {
            SQLiteConnection myCon = new SQLiteConnection(pathToData);
            myCon.Open();
            using (myCon)
            {
                string commandContent =
                    "INSERT INTO Books (Title, Author, PublishDate, ISBN) " +
                    "VALUES (@title, @author, @publish, @isbn)";
                SQLiteCommand command = new SQLiteCommand(commandContent, myCon);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@publish", publishDate);
                command.Parameters.AddWithValue("@isbn", isbn);
                Console.WriteLine("++++++++++++++++++++++++++++++++++++\n");
                Console.WriteLine("Inserting a book:\n");
                command.ExecuteNonQuery();
            }            
        }
    }
}
