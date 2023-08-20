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
    Description: This view class is responsible for handling the user's input for adding Cities to the Database
    */

    public partial class AddCityWindow : Window
    {
        DatabaseController controller = DatabaseController.DataController;

        public AddCityWindow()
        {
            InitializeComponent();
        }

        // Initialize default control bindings for selecting Country
        private void InitializeControls(object sender, RoutedEventArgs e)
        {
            List<Country> countryList = controller.GetAllCountries();
            listAddCityCountry.DataContext = countryList;
            listAddCityCountry.ItemsSource = countryList;

            listAddCityCountry.SelectedIndex = 0;
        }

        // Reset all inputs to default values
        private void ResetInputs()
        {
            txtAddCityName.Text = string.Empty;
            txtAddCityPopulation.Text = string.Empty;
            listAddCityCountry.SelectedIndex = 0;
            blnIsCaptial.IsChecked = false;
        }

        // Handle logic and error checking for adding City 
        private void AddCity(object sender, RoutedEventArgs e)
        {
            try
            {
                string cityName = txtAddCityName.Text;
                string cityPopulation = txtAddCityPopulation.Text;
                bool isCaptial = blnIsCaptial.IsChecked == true;
                int countryID = (listAddCityCountry.SelectedItem as Country).countryID;

                if (string.IsNullOrEmpty(cityName) || string.IsNullOrEmpty(cityPopulation))
                {
                    throw new Exception("Missing required data");
                }

                controller.AddCity(cityName, isCaptial, cityPopulation, countryID);
                lblStatus.Content = "Successfully added City";
                ResetInputs();
            }
            catch (Exception)
            {
                lblStatus.Content = "Error adding City, please add required fields";
            }
        }

        // Close window when Exit Button is selected
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
