/*
 * Task 2: Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
 */

namespace NorthwindConsole
{
    using System;
    using System.Linq;

    public static class AffectCustomers
    {
        public static void InsertCustomer(
            string id,
            string companyName,
            string contactName = null,
            string contactTitle = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            using (var context = new NorthwindEntities())
            {
                var customer = new Customer()
                {
                    CustomerID = id,
                    CompanyName = companyName,
                    ContactName = contactName,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                };
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public static void DeleteCustomer(string id)
        {
            using (var context = new NorthwindEntities())
            {
                var toRemove = context.Customers.Find(id);
                context.Customers.Remove(toRemove);
                context.SaveChanges();
            }
        }

        public static void ModifyCustomer(string customerIDToModify, string companyName, string contactName)
        {
            using (var context = new NorthwindEntities())
            {
                var toUpdate = context.Customers.Find(customerIDToModify);                
                toUpdate.CompanyName = companyName;
                toUpdate.ContactName = contactName;                
                context.SaveChanges();
            }
        }

    }
}
