using CreateDBContext.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreateDBContext
{
    public static class DatabaseAccess
    {
        //2.Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers.
        public static void InsertCustomer(
            string customerID,
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
            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(new Customer()
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax
                });

                db.SaveChanges();
            }

            Console.WriteLine("Inserted new customer!");
        }

        public static void DeleteCustomer(string customerId)
        {
            using (var db = new NorthwindEntities())
            {
                var customerToRemove = db.Customers.Where(c => c.CustomerID == customerId).First();
                db.Customers.Remove(customerToRemove);

                db.SaveChanges();
            }

            Console.WriteLine("Customer deleted!");
        }

        public static void UpdateCustomerPhone(
            string customerId, string phone)
        {
            using (var db = new NorthwindEntities())
            {
                var customerToUpdate = db.Customers.Where(c => c.CustomerID == customerId).First();

                customerToUpdate.Phone = phone;

                db.SaveChanges();
            }

            Console.WriteLine("Customer phone changed!");
        }

        //3.Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
        public static void CustomersWithOrdersShippedToCanadaIn1997()
        {
            using (var db = new NorthwindEntities())
            {
                var customersID = db.Orders
                    .Where(o => o.ShipCountry == "Canada" && o.OrderDate.Value.Year == 1997)
                    .Select(c => c.Customer.CustomerID)
                    .Distinct();
                var customersNames = db.Orders
                    .Where(o => o.ShipCountry == "Canada" && o.OrderDate.Value.Year == 1997)
                    .Select(c => c.Customer.ContactName)
                    .Distinct();

                Console.WriteLine("Customer IDs with orders in 1997 to Canada:\n");

                foreach (var customer in customersID)
                {
                    Console.WriteLine(customer);
                }

                Console.WriteLine("\n********************");

                Console.WriteLine("Customer Names with orders in 1997 to Canada:\n");

                foreach (var customer in customersNames)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        //4.Implement previous by using native SQL query and executing it through the DbContext.
        public static void CustomersWithOrdersShippedToCanadaIn1997NativeSQL()
        {
            using (var db = new NorthwindEntities())
            {
                string query = "SELECT * FROM Orders WHERE ShipCountry like 'Canada' AND OrderDate LIKE '%1997%'";
                var customersID = db.Orders.SqlQuery(query).Select(c => c.CustomerID).Distinct();
                var customersName = db.Orders.SqlQuery(query).Select(c => c.Customer.ContactName).Distinct();

                Console.WriteLine("Customer IDs with orders in 1997 to Canada with native SQL:\n");

                foreach (var customer in customersID)
                {
                    Console.WriteLine(customer);
                }

                Console.WriteLine("\n********************");
                Console.WriteLine("Customer Names with orders in 1997 to Canada with native SQL:\n");

                foreach (var customer in customersName)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        //5.Write a method that finds all the sales by specified region and period (start / end dates).
        public static void GetSalesBetween(DateTime start, DateTime end)
        {
            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders.Where(o => o.OrderDate >= start && o.OrderDate <= end);

                Console.WriteLine("Sales between {0} - {1}\n", start, end);

                foreach (var sale in sales)
                {
                    Console.WriteLine("{0} - {1}", sale.OrderID, sale.OrderDate);
                }
            }
        }

        //7.Try to open two different data contexts and perform concurrent changes on the same records.
        public static void MakeConcurrentChanges()
        {
            using (var db = new NorthwindEntities())
            {
                using (var anotherDB = new NorthwindEntities())
                {
                    var category = db.Categories.Where(c => c.CategoryName == "Beverages").First();
                    category.Description = "First change";

                    var category2 = anotherDB.Categories.Where(c => c.CategoryName == "Beverages").First();
                    category2.Description = "Second Change";

                    db.SaveChanges();
                    anotherDB.SaveChanges();
                }
            }
        }

        public static void AccessingEmployeesTerritorries()
        {
            using (var ctx = new NorthwindEntities())
            {
                var employee = ctx.Employees.FirstOrDefault();
                employee = ctx.Employees.FirstOrDefault();
                Console.WriteLine("Employee {0} territories:", employee.FirstName);

                foreach (var territory in employee.TerritoriesSet)
                {
                    Console.WriteLine(territory.TerritoryDescription);
                }
            }
        }
    }
}