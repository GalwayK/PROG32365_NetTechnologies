using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DatabaseConnectionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionStr = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Northwind;Integrated Security = True;";

            string query = "Select ProductID, UnitPrice, ProductName from dbo.products" +
                " Where UnitPrice > @pricePoint" +
                " Order By UnitPrice DESC";

            int paramValue = 5;
            using (SqlConnection connection = new SqlConnection(connectionStr)) 
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pricePoint", paramValue);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                Console.WriteLine("Enter the first name of the employee to search: ");
                string fname = Console.ReadLine();
                string connStr = ConfigurationManager.ConnectionStrings["NWDB"].ConnectionString;

                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    string q = "Select EmployeeID, FirstName, LastName, BirthDate " +
                        "from Employees where FirstName = @firstname";
                    
                    SqlCommand sqlCommand = new SqlCommand(q, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@firstname", fname);
                    sqlConnection.Open();

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        int id = (int) reader["EmployeeID"];
                        string fn = (string)reader["FirstName"];
                        string ln = (string)reader["LastName"];
                        DateTime bd = (DateTime)reader["BirthDate"];

                        Console.WriteLine($" {id,6} {fn,-15} {ln,-15} {bd,-10} ");
                    }
                    reader.Close();

                    String q2 = "Select Count(*) from Employees";
                    SqlCommand sqlcmd = new SqlCommand(q2, sqlConnection);
                    //sqlConnection.Open();
                    int noOfRow = (int)sqlcmd.ExecuteScalar();
                    Console.WriteLine("No of records in the employee table: " + noOfRow);
                    sqlConnection.Close();
                }

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}