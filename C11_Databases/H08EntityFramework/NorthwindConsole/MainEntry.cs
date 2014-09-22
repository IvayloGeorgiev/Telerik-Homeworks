namespace NorthwindConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    
    using System.Data.Entity.Infrastructure;
    using System.Text;
    using System.Data.SqlClient;

    class MainEntry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 2:\n");
            TestAffectCustomers();
            Console.WriteLine("\n-------------------------------\n");
            Console.WriteLine("Task 3:\n");
            List<Customer> after1997FromCanada = GetCustomers(new DateTime(1997, 1, 1), "Canada");
            foreach (var customer in after1997FromCanada)
            {
                Console.WriteLine(customer.ContactName);
            }
            Console.WriteLine("\n-------------------------------\n");
            Console.WriteLine("Task 4:\n");
            List<Customer> after1997FromCanadaSql = GetCustomersSql(new DateTime(1997, 1, 1), "Canada");
            foreach (var customer in after1997FromCanadaSql)
            {
                Console.WriteLine(customer.ContactName);
            }
            Console.WriteLine("\n-------------------------------\n");            
            Console.WriteLine("Task 5:\n");
            List<Order> orders = GetSalesByRegionAndPeriod(null, new DateTime(1997, 1, 1), new DateTime(2005, 12, 1));
            foreach (var order in orders)
            {
                Console.WriteLine(order.OrderDate + " " + order.OrderID);
            }
            Console.WriteLine("\n-------------------------------\n");
            //Console.WriteLine("Task 6:\n");
            //CloneNorthwind();
            //Console.WriteLine("\n-------------------------------\n");
            Console.WriteLine("Task 7:\n");
            ConcurentChanges();
            Console.WriteLine("\n-------------------------------\n");
            Console.WriteLine("Task 9:\n");
            CreateFiveOrders();
            Console.WriteLine("\n-------------------------------\n");
            Console.WriteLine("Task 10:\n");
            TotalIncomeForSupplie("Tokyo Traders", new DateTime(1997, 1, 1), new DateTime(1997, 12, 31));
            Console.WriteLine("\n-------------------------------\n");
        }

        private static void TestAffectCustomers()
        {
            PrintCustomerCompName("boby");
            AffectCustomers.InsertCustomer("boby", "turboto");
            PrintCustomerCompName("boby");
            AffectCustomers.ModifyCustomer("boby", "bobeto", "bobkov");
            PrintCustomerCompName("boby");
            AffectCustomers.DeleteCustomer("boby");
            PrintCustomerCompName("boby");
        }

        private static void PrintCustomerCompName(string id)
        {
            using (var context = new NorthwindEntities())
            {
                var customer = context.Customers.Find(id);
                if (customer != null)
                {
                    Console.WriteLine(context.Customers.Find(id).CompanyName);
                }
                else
                {
                    Console.WriteLine("No such object.");
                }
            }
        }


        // Task 3: Write a method that finds all customers who have orders made in 1997 and shipped to Canada.         
        private static List<Customer> GetCustomers(DateTime year, string shippingCountry)
        {
            List<Customer> customers;
            using (var context = new NorthwindEntities())
            {                
                customers = context.Orders
                    .Where((o) => o.ShippedDate.Value.Year == year.Year && o.ShipCountry == shippingCountry)
                    .Select((o) => o.Customer)
                    .Distinct()
                    .ToList();
            }
            return customers;
        }

        // Task 4: Implement previous by using native SQL query and executing it through the DbContext.
        private static List<Customer> GetCustomersSql(DateTime year, string shippingCountry)
        {
            List<Customer> customers;
            using (var context = new NorthwindEntities())
            {                
                customers = context.Customers.SqlQuery(
                    "SELECT DISTINCT c.* " +
                    "FROM Customers c " +
                    "INNER JOIN Orders o " +
                    "ON c.CustomerID = o.CustomerID " +
                    "WHERE o.ShipCountry = @p0 " +
                    "AND format(o.OrderDate, 'yyyy') = @p1", shippingCountry, year.Year).ToList();
            }
            return customers;
        }

        //  Task 5: Write a method that finds all the sales by specified region and period (start / end dates).

        private static List<Order> GetSalesByRegionAndPeriod(string region, DateTime periodStart, DateTime periodEnd)
        {
            List<Order> result;
            using (var context = new NorthwindEntities())
            {
                result = context.Orders
                    .Where((o) => o.OrderDate.HasValue && o.OrderDate.Value >= periodStart && o.OrderDate.Value <= periodEnd && o.ShipRegion == region)
                    .ToList();
            }
            return result;
        }

        // Task 6: Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext. Find for the API for schema generation in MSDN or in Google.
        private static void CloneNorthwind()
        {
            SqlConnection createDB = new SqlConnection("Server=.\\SQLEXPRESS; Database=master; Integrated Security=true");
            createDB.Open();
            using (createDB)
            {
                SqlCommand command = new SqlCommand("CREATE DATABASE [NorthwindTwin]", createDB);
                command.ExecuteNonQuery();
            }

            StringBuilder script = new StringBuilder();            
            IObjectContextAdapter context = new NorthwindEntities();
            script.Append(context.ObjectContext.CreateDatabaseScript());
            Console.WriteLine(script.ToString());
            SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS; Database=NorthwindTwin; Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(script.ToString(), connection);
                command.ExecuteNonQuery();
            }
        }

        // Task 7: Try to open two different data contexts and perform concurrent changes on the same records. What will happen at SaveChanges()? How to deal with it?
        private static void ConcurentChanges()
        {
            AffectCustomers.InsertCustomer("goji", "nekvi tam");
            using (var firstConnection = new NorthwindEntities())
            {
                using (var secondConnection = new NorthwindEntities())
                {
                    var customerFirst = firstConnection.Customers.Find("goji");
                    customerFirst.CompanyName = "lala land";
                    var customerSecond = secondConnection.Customers.Find("goji");
                    customerSecond.CompanyName = "gaga land";
                    PrintCustomerCompName("goji");
                    firstConnection.SaveChanges();
                    PrintCustomerCompName("goji");
                    secondConnection.SaveChanges();
                    PrintCustomerCompName("goji");
                }
            }
            PrintCustomerCompName("goji");
            AffectCustomers.DeleteCustomer("goji");
        }

        // Task 9: Create a method that places a new order in the Northwind database. The order should contain several order items. Use transaction to ensure the data consistency.
        private static void CreateFiveOrders()
        {
            //Transactions are kinda pointless since unlike EF5, EF6 does them automatically. Still, a task is a task.

            using (var dbCon = new NorthwindEntities())
            {
                using (var dbTranscation = dbCon.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var order = new Order() { ShipName = string.Format("Dummy order {0}", i)};
                            dbCon.Orders.Add(order);
                            dbCon.SaveChanges();
                        }
                        dbTranscation.Commit();
                    }
                    catch (Exception e)
                    {
                        dbTranscation.Rollback();
                    }
                }
            }
        }

        // Task 10: Create a stored procedures in the Northwind database for finding the total incomes for given supplier name and period (start date, end date). Implement a C# method that calls the stored procedure and returns the retuned record set.
        private static decimal TotalIncomeForSupplie(string compName, DateTime periodStart, DateTime periodEnd)
        {
            decimal income = 0;
            using (NorthwindEntities dbCon = new NorthwindEntities())
            {
                income = dbCon.usp_TotalIncome(compName, periodStart, periodEnd).First().Value;
                Console.WriteLine(compName + " " + income);
            }
            return income;
        }

    }
}
