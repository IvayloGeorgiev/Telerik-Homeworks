namespace T01to05_NorthwindInSSMS
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    class MainEntry
    {
        private const string DB_CONNECTION_STRING =
            "Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true";
        private const string DEST_IMAGE_FILE_NAME = "..\\..\\db-cat-image";
        private static SqlConnection dbCon = null;

        static void Main(string[] args)
        {
            dbCon = new SqlConnection(DB_CONNECTION_STRING);
            dbCon.Open();
            using (dbCon)
            {
                GetRowsInCategories();
                GetCategoriesWithDescription();
                GetProductsByCategories();
                Console.WriteLine("\n-----------------------------------\n");
                GetProductsByCategoriesUsingT10FromLastHomework();
                //int index = AddProduct("Shisharki", true);
                //Console.WriteLine(index);
                //index = AddProduct("Leshnici", false);
                //Console.WriteLine(index);
                ExtractAllImages();
            }
        }

        //T01 - Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.
        public static void GetRowsInCategories()
        {
            SqlCommand com = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories", dbCon);
            int rowCount = (int)com.ExecuteScalar();
            Console.WriteLine("The number of rows in the {0} table is {1}.", "Categories", rowCount);
        }

        //T02 - Write a program that retrieves the name and description of all categories in the Northwind DB.
        public static void GetCategoriesWithDescription()
        {
            SqlCommand com = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
            SqlDataReader reader = com.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];

                    Console.WriteLine("Name: {0}\nDescription: {1}\n", name, description);
                }
            }
        }

        //T03 - Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. Can you do this with a single SQL query (with table join)?
        public static void GetProductsByCategories()
        {
            SqlCommand com = new SqlCommand(
                "SELECT c.CategoryName, p.ProductName " +
                "FROM Categories c " +
                "INNER JOIN Products p "+
                "ON c.CategoryID = p.CategoryID "+
                "ORDER BY c.CategoryName", dbCon);
            SqlDataReader reader = com.ExecuteReader();
            using (reader)
            {
                string cat = string.Empty;
                string products = string.Empty;
                while (reader.Read())
                {
                    string curCat = (string)reader["CategoryName"];
                    string curProduct = (string)reader["ProductName"];
                    if (cat != curCat)
                    {
                        if (cat != string.Empty && products != string.Empty)
                        {
                            Console.WriteLine("{0} -> {1}", cat, products);
                            products = string.Empty;
                        }
                        cat = curCat;
                    }

                    if (products == string.Empty)
                    {
                        products += curProduct;
                    }
                    else
                    {
                        products += ", " + curProduct;
                    }
                }
                Console.WriteLine("{0} -> {1}", cat, products);
            }
        }

        //T03 - Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
        //Done with some code from last homework.
        public static void GetProductsByCategoriesUsingT10FromLastHomework()
        {
            SqlCommand com = new SqlCommand("SELECT c.CategoryName, [master].[dbo].StringConcat(p.ProductName) as [ProductNames] " +
                "FROM Categories c " +
                "INNER JOIN Products p " +
                "ON c.CategoryID = p.CategoryID " +
                "GROUP BY c.CategoryName", dbCon);
            SqlDataReader reader = com.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string cat = (string)reader["CategoryName"];
                    string products = (string)reader["ProductNames"];

                    Console.WriteLine("{0} -> {1}", cat, products);
                }
            }
        }


        //T04 - Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
        public static int AddProduct(string prodName, bool discontinued)
        {
            int insertedIndex = -1;

            SqlCommand command = new SqlCommand(
                "INSERT INTO Products(ProductName, Discontinued)" +
                "VALUES (@name, @disc)", dbCon);

            command.Parameters.AddWithValue("@name", prodName);
            command.Parameters.AddWithValue("@disc", discontinued);
            command.ExecuteNonQuery();

            SqlCommand getInsertedIndex = new SqlCommand("SELECT @@Identity", dbCon);
            insertedIndex = (int)(decimal)getInsertedIndex.ExecuteScalar();

            return insertedIndex;
        }

        //T05 - Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
        public static void ExtractAllImages()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT Picture, CategoryID FROM Categories " +
                "WHERE Picture IS NOT NULL", dbCon);
            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int id = (int)reader["CategoryID"];
                    byte[] image = (byte[])reader["Picture"];
                    using (Image pic = Image.FromStream(new MemoryStream(image, 78, image.Length - 78)))
                    {
                        pic.Save(DEST_IMAGE_FILE_NAME + id + ".jpg", ImageFormat.Jpeg);
                    }
                }
            }
        }
    }
}
