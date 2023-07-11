using System.Configuration;
using System.Data.SqlClient;

namespace Week9Lesson1
{
    internal class Program
    {
        static DataConnectionTest testConnection = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string strConnection = "Data Source = (localdb)\\MSSQLLocalDB; " +
                "Initial Catalog = Northwind; Integrated Security = True;";

            testConnection = new DataConnectionTest(strConnection);
            // TestSelect(5.0M);
            SearchForEmployee();
        }

        static void TestSelect(decimal numPrice)
        {
            string strQuery = "SELECT ProductID, UnitPrice, ProductName FROM dbo.products" +
                " WHERE UnitPrice > @pricePoint ORDER BY UnitPrice DESC";

            using (SqlConnection connection = new SqlConnection(Program.testConnection.StrConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strQuery, connection);
                sqlCommand.Parameters.AddWithValue("pricePoint", numPrice);

                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Opswy woopswy swomwthwin wehn fwooksy: {ex}");
                }
            }
        }

        static void SearchForEmployee()
        {
            Console.Write("Please enter an employee name: ");
            string empName = "";
            try
            {
                empName = Console.ReadLine();
                string strConnection = ConfigurationManager.ConnectionStrings["NWDB"].ConnectionString;
                Console.WriteLine(strConnection);

                using (SqlConnection connection = new SqlConnection(Program.testConnection.StrConnection))
                {
                    string strQuery = "SELECT employeeID, firstName, lastName, birthDate" +
                        " FROM employees where firstName = @empName";

                    SqlCommand command = new SqlCommand(strQuery, connection);
                    command.Parameters.AddWithValue("empName", empName);


                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine($"Found: {reader["EmployeeID"]}\t{reader["FirstName"]}\t{reader["LastName"]}\t{reader["BirthDate"]}");
                    }
                    else
                    {
                        Console.WriteLine($"No one named: {empName}");
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Opswy woopswy swomwthwin wehn fwooksy: {ex}");

            }

        }
    }
}