/*Write a program that reads a string from the console and finds all products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.*/

namespace T08StringSearch
{
    using System;
    using System.Data.SqlClient;    

    class MainEntry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string pattern:");
            string pattern = Console.ReadLine();            
            pattern = pattern.Replace("[", "[[]");            
            pattern = pattern.Replace("_", "[_]");
            pattern = pattern.Replace("%", "[%]");
            pattern = pattern.Replace("'", "''");
            pattern = "%" + pattern + "%";
            Console.WriteLine(pattern);
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE @pattern ", dbCon);
                command.Parameters.AddWithValue("@pattern", pattern);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["ProductName"];

                        Console.WriteLine("Product: {0}", name);
                    }
                }
            }
        }
    }
}
