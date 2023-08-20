using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FinalKyleGalway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // Retrieve Controller for allowing access to database
        private NorthwindController DataController = NorthwindController.DataController;
       
        public MainWindow()
        {
            InitializeComponent();
        }

        // Retrieve all Products from Database
        private void GetAllProducts(object sender, RoutedEventArgs e)
        {
            DataView productsView = DataController.GetAllProducts();

            gridProducts.DataContext = productsView;
            gridProducts.ItemsSource = productsView;

            lblStatus.Content = "Retrieved all products in database...";
            RefreshInputs();
        }

        // Clear All Data from Table
        private void ClearAllData(object sender, RoutedEventArgs e)
        {
            RefreshAllData();
            RefreshInputs();
            lblStatus.Content = "Cleared product data from display table...";
        }

        // Clear Text Input for Product Name
        void RefreshInputs()
        {
            txtAddProductName.Text = string.Empty;
        }

        // Clear all data displayed on application
        void RefreshAllData()
        {
            gridProducts.DataContext = null;
            gridProducts.ItemsSource = null;

            RefreshInputs();
            ResetGridList();
        }

        // Reset the Grid to an empty table
        void ResetGridList()
        {
            List<Category> listCategories = DataController.GetAllCategories();
            comboCategories.DataContext = listCategories;
            comboCategories.ItemsSource = listCategories;
            comboCategories.SelectedIndex = -1;
        }

        // Initialize components with default bindings
        private void InitializeComponents(object sender, RoutedEventArgs e)
        {
            ResetGridList();
        }

        // Retrieve Products by Category
        private void GetProductsByCategory(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Category category = comboCategories.SelectedItem as Category;
                if (category == null )
                {
                    throw new Exception("Invalid Category");
                }
                DataView productsView = DataController.GetProductsByCategoryId(category.id);

                gridProducts.DataContext = productsView;
                gridProducts.ItemsSource = productsView;
                lblStatus.Content = $"Successfully retrieved products of category {category.id}";
                RefreshInputs();
            }
            catch (Exception ex) 
            {
                lblStatus.Content = "Error, unable to retrieve products by category";
            }
        }

        // Retrieve Products by matching Product Name
        private void GetProductsByName(object sender, RoutedEventArgs e)
        {
            string productName = txtAddProductName.Text;

            if (String.IsNullOrEmpty(productName))
            {
                lblStatus.Content = "Error, please enter a product name...";
                return;
            }

            DataView productView = DataController.GetProductsByName(productName);

            gridProducts.DataContext = productView;
            gridProducts.ItemsSource = productView;

            if (productView.Count == 0)
            {
                lblStatus.Content = $"No matching products for {productName}";
                RefreshInputs();
            }
            else
            {
                lblStatus.Content = $"Retrieved products matching Name: {productName}";
            }
        }

        // Show Add Product Window
        private void ShowAddProductWindow(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
            ResetGridList();

            RefreshAllData();

            lblStatus.Content = "Closed add product window...";
            return;
        }

        // Close program and exit
        private void CloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
