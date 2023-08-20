using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace FinalKyleGalway
{
    internal class NorthwindRepository
    {
        // Retrieve Connection string from configuration files
        private static string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        
        private SqlConnection connection;

        // Retrieve all products
        public DataTable ReadAllProducts()
        {
            string strQuery = "SELECT * from Products";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, connection);

            DataSet productData = new DataSet();

            dataAdapter.Fill(productData, "Product");

            DataTable productTable = productData.Tables["Product"];

            return productTable;
        }

        // Retrieve all products by Category
        public DataTable ReadProductsByCategoryId(int categoryId)
        {
            string strQuery = "SELECT * from Products WHERE CategoryID = @categoryId";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, connection);

            dataAdapter.SelectCommand.Parameters.AddWithValue("categoryId", categoryId);

            DataSet productData = new DataSet();

            dataAdapter.Fill(productData, "Product");

            DataTable productTable = productData.Tables["Product"];

            return productTable;
        }

        // Retrieve Products by Matching Name
        public DataTable ReadProductsByProductName(string productName)
        {
            String strQuery = "SELECT * from Products WHERE UPPER(ProductName) LIKE UPPER(@productName)";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, connection);

            dataAdapter.SelectCommand.Parameters.AddWithValue("productName", $"%{productName}%");

            DataSet productData = new DataSet();

            dataAdapter.Fill(productData, "Product");

            DataTable productTable = productData.Tables["Product"];

            return productTable;
        }


        // Retrieve All Categories
        public List<Category> ReadAllCategories()
        {
            List<Category> listCategories = new List<Category>();

            string strQuery = "SELECT * FROM Categories";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, connection);
            DataSet categoryData = new DataSet();

            dataAdapter.Fill(categoryData, "Category");

            DataTable categoryTable = categoryData.Tables["Category"];

            foreach (DataRow row in categoryTable.Rows)
            {
                int id = (int)row[0];
                string name = (string)row[1];
                string description = (string)row[2];   

                listCategories.Add(Category.CategoryFactory(id, name, description));
            }
            return listCategories;
        }

        // Create new Product from Provided Fields
        public int CreateProduct(string name, decimal price, int categoryId)
        {
            int results = 0; 
            try
            {
                string strQuery = "SELECT * from Products";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, connection);

                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

                DataTable productTable = ReadAllProducts();

                DataRow newRow = productTable.NewRow();

                newRow[1] = name;

                newRow[5] = price;

                newRow[3] = categoryId;

                productTable.Rows.Add(newRow);

                dataAdapter.InsertCommand = builder.GetInsertCommand();

                results = dataAdapter.Update(productTable);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return results;
        }

        // Constructor
        public NorthwindRepository() 
        { 
            this.connection = new SqlConnection(connectionString);
        }
    }
}
