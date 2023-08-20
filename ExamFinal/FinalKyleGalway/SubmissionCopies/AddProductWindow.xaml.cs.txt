using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalKyleGalway
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private NorthwindController DataController = NorthwindController.DataController;

        public AddProductWindow()
        {
            InitializeComponent();
        }

        // Initialize Category Bindings
        private void InitializeCategories(object sender, RoutedEventArgs e)
        {
            List<Category> listCategories = DataController.GetAllCategories();
            comboCategory.DataContext = listCategories;
            comboCategory.ItemsSource = listCategories;
            comboCategory.SelectedIndex = 0;
        }


        // Clear Text  Inputs
        private void ClearInputs()
        {
            txtProductName.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            comboCategory.SelectedIndex = -1;
        }

        // Add Product to Database
        private void AddProduct(object sender, RoutedEventArgs e)
        {
            string productName = txtProductName.Text;
            string strProductPrice = txtProductPrice.Text;

            if (String.IsNullOrEmpty(productName) || String.IsNullOrEmpty(strProductPrice))
            {
                lblStatus.Content = "Error, please add required fields...";
                return;
            }
            else 
            {
                try
                {
                    decimal numProductPrice = Convert.ToDecimal(strProductPrice);

                    Category category = comboCategory.SelectedItem as Category;

                    if (category == null) 
                    {
                        lblStatus.Content = "Error, please select a category";
                        return;
                    }

                    int result = DataController.AddProduct(productName, numProductPrice, category.id);

                    if (result == 0) 
                    {
                        lblStatus.Content = "Error, unable to add product";
                    }
                    else
                    {
                        lblStatus.Content = "Successully added product...";
                        ClearInputs();
                    } 
                        
                }
                catch (Exception ex) 
                {
                    lblStatus.Content = "Error, please add price as a number..";
                }
            }
        }

        // Close window
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
