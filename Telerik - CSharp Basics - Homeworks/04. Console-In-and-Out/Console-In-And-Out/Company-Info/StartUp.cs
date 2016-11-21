using System;

namespace Company_Info
{
    public class StartUp
    {
        public static void Main()
        {
            string companyName = Console.ReadLine();
            string companyAddress = Console.ReadLine();
            string phoneNumber = Console.ReadLine();
            string faxNumber = Console.ReadLine();
            if (faxNumber == string.Empty)
            {
                faxNumber = "(no fax)";
            }
            string website = Console.ReadLine();
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string phone = Console.ReadLine();
            Console.WriteLine("{0}", companyName);
            Console.WriteLine("Address: {0}", companyAddress);
            Console.WriteLine("Tel. {0}", phoneNumber);
            Console.WriteLine("Fax: {0}", faxNumber);
            Console.WriteLine("Web site: {0}", website);
            Console.WriteLine("Manager: {0} {1} " + "(age: {2}, tel. {3})", firstName, lastName, age, phone);
        }
    }
}
