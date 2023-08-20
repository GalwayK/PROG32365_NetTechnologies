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

namespace A3KyleGalway.AddWindows
{
    /*
    Name: Kyle Galway 
    Email: galwayk@sheridanc.on.ca
    Description: This view class is responsible for handling the user's input for adding Continents to the Database
    */

    public partial class AddContinentWindow : Window
    {
        DatabaseController controller = DatabaseController.DataController;

        public AddContinentWindow()
        {
            InitializeComponent();
        }

        // Reset input field
        private void ResetField()
        {
            txtAddContinentName.Text = "";
        }

        // Handle logic and error checking for adding continent
        private void HandleAddContinent(object sender, RoutedEventArgs e)
        {
            string continentName = txtAddContinentName.Text;
            if (string.IsNullOrEmpty( continentName ) ) 
            {
                lblStatus.Content = "Error adding Continent, please add required fields";
            }
            else
            {
                int effectedRows = controller.AddContinent(continentName);
                lblStatus.Content = "Successfully added Continent";
            }
            ResetField();
        }

        // Close window when Exit Button is selected
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
