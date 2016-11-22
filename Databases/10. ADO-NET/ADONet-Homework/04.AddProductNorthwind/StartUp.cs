using System.Data.SqlClient;

namespace _04.AddProductNorthwind
{
    public class StartUp
    {
        private static SqlConnection dbCon;

        public static void Main()
        {
            dbCon = new SqlConnection(
                "Server=.; " +
                "Database=Northwind; " +
                "Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                InsertProduct("Sirene", 4, 4, true);
            }
        }

        private static void InsertProduct(string name, int supplierID, int categoryID, bool discontinued)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
              "(ProductName, SupplierID, CategoryID, Discontinued) VALUES " +
              "(@name, @suppl, @cat, @disc)", dbCon);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@suppl", supplierID);
            cmd.Parameters.AddWithValue("@cat", categoryID);
            cmd.Parameters.AddWithValue("@disc", discontinued);

            cmd.ExecuteNonQuery();
        }
    }
}
