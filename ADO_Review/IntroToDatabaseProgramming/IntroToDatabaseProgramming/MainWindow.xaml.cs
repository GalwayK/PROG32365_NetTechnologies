using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IntroToDatabaseProgramming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["NorthwindDatabase"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
            GetAllProducts();
        }

        private void LoadEmployees(object sender, RoutedEventArgs e)
        {
            loadEmployees();
            loadEmployeeCount();
        }

        private void loadEmployees()
        {
            Console.WriteLine(connectionString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string strQuery = "SELECT EmployeeID, LastName, FirstName, Title FROM Employees";

                SqlCommand command = new SqlCommand(strQuery, connection);
                command.Parameters.AddWithValue("maxEmployeeID", 10);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No employees found!");
                }
                else
                {
                    DataTable tblEmployees = new DataTable();
                    tblEmployees.Load(reader);
                    listDatabaseItems.ItemsSource = tblEmployees.AsDataView();
                }

                /*
                                while (reader.Read())
                                {
                                    listDatabaseItems.ItemsSource = reader;
                                    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]} {reader[3]}");
                                }*/

            }
        }

        private void refreshEmployeesList()
        {
            loadEmployees();
            loadEmployeeCount();
        }

        private void loadEmployeeCount()
        {
            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                string sqlQuery = "SELECT count(EmployeeID) from Employees";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();

                txtCountEmployees.Text = Convert.ToString(command.ExecuteScalar());
            }
        }

        private void addEmployee(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLasttName.Text;
            string title = txtTitle.Text;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Employees (FirstName, LastName, Title) " +
                    "VALUES (@firstName, @lastName, @title)";
                SqlCommand command = new SqlCommand( sqlQuery, connection);

                command.Parameters.AddWithValue("firstName", firstName);
                command.Parameters.AddWithValue("lastName", lastName);
                command.Parameters.AddWithValue("title", title);

                connection.Open();
                int count = command.ExecuteNonQuery();

                if (count > 0) 
                {
                    Console.WriteLine("Added employee!");
                }
            }

            refreshEmployeesList();
        }
        
        private void GetAllProducts()
        {
            using(SqlConnection connection = new SqlConnection( connectionString))
            {
                string strQuery = "SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(strQuery, connection);

                DataSet dataset = new DataSet();
                adapter.Fill(dataset, "RetrievedProducts");

                DataTable tblProducts = dataset.Tables["RetrievedProducts"];

                

                foreach (DataRow row in tblProducts.Rows)
                {
                    Console.WriteLine($"{row[0]} {row[1]} {row[2]} {row[3]}");
                }

                string strMultiQuery = "SELECT * FROM Employees";

                DataSet multiSet = new DataSet();

                SqlDataAdapter multiSetAdapter = new SqlDataAdapter( strMultiQuery, connection);
                multiSetAdapter.Fill(multiSet);

                /*                DataTable tblCategories = multiSet.Tables[0];*/
                DataTable tblEmployees = multiSet.Tables[0];
/*
                foreach (DataRow rowCategory in tblCategories.Rows)
                {
                    Console.WriteLine("Printing Categories ");
                    Console.WriteLine($"{rowCategory[0]} {rowCategory[1]} {rowCategory[2]} {rowCategory[3]}");
                }
*/
                foreach (DataRow rowEmployee in tblEmployees.Rows)
                {
                    Console.WriteLine("Printing Employees!");
                    Console.WriteLine($"{rowEmployee[0]} {rowEmployee[1]} {rowEmployee[2]} {rowEmployee[3]}");
                }

                DataRow newEmployee = tblEmployees.NewRow();

                SqlCommandBuilder builder = new SqlCommandBuilder(multiSetAdapter);    

                newEmployee["FirstName"] = "Maegor";
                newEmployee["LastName"] = "the Cruel";
                newEmployee["Title"] = "King of the Andals";

                tblEmployees.Rows.Add(newEmployee);

               multiSetAdapter.InsertCommand = builder.GetInsertCommand();
                multiSetAdapter.Update(tblEmployees);

            }
        }

    }
}
