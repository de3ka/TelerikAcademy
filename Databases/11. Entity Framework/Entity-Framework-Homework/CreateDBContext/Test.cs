using CreateDBContext.Data;
using System;
using System.Linq;

namespace CreateDBContext
{
    public class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********TASK2**********");

            DatabaseAccess.InsertCustomer("AAAAA", "Telerik", "aaa", "bbb", "Mladost 1", "Sofia", "Mladost", "2506", "Bulgaria", "0885555555", "094-2132-12");

            Customer customer;
            using (var db = new NorthwindEntities())
            {
                customer = db.Customers.Where(c => c.CompanyName == "Telerik").First();
            }

            DatabaseAccess.UpdateCustomerPhone(customer.CustomerID, "0886666666");

            DatabaseAccess.DeleteCustomer(customer.CustomerID);
            
            Console.WriteLine("\n**********TASK3**********");
            DatabaseAccess.CustomersWithOrdersShippedToCanadaIn1997();

            Console.WriteLine("\n**********TASK4**********");
            DatabaseAccess.CustomersWithOrdersShippedToCanadaIn1997NativeSQL();

            Console.WriteLine("\n**********TASK5**********");
            DatabaseAccess.GetSalesBetween(new DateTime(1997, 6, 1), new DateTime(1997, 7, 15));

            Console.WriteLine("\n**********TASK7**********");
            Console.WriteLine("When we try to make concurrent changes with two database context the last one to call save changes wins.");
            Console.WriteLine("You can use pessimistic concurrency to be sure that the user will see the changes in the db.");
            Console.WriteLine("You can use transactions in order to be sure that everything is consistent.");
            DatabaseAccess.MakeConcurrentChanges();

            Console.WriteLine("\n**********TASK8**********");
            DatabaseAccess.AccessingEmployeesTerritorries();
        }
    }
}