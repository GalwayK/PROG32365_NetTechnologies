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

namespace A3KyleGalway
{
    /*
    Name: Kyle Galway 
    Email: galwayk@sheridanc.on.ca
    Description: This view class is responsible for handling the user's input for adding Countries to the Database
    */

    public partial class AddCountryWindow : Window
    {
        DatabaseController controller = DatabaseController.DataController;

        public AddCountryWindow()
        {
            InitializeComponent();
        }

        // Initialize control bindings for selecting Continent
        private void IntializeControls(object sender, RoutedEventArgs e)
        {
            listAddCountryContinent.DataContext = controller.GetListContinents();
            listAddCountryContinent.ItemsSource = controller.GetListContinents();
            listAddCountryContinent.SelectedIndex = 0;
        }

        // Reset inputs to default values
        private void ResetInput()
        {
            listAddCountryContinent.SelectedIndex = 0;
            txtAddCountryCurrency.Text = string.Empty;
            txtAddCountryLanguage.Text = string.Empty;
            txtAddCountryName.Text = string.Empty;  
        }

        // Handle logic and error checking for adding Country
        private void AddCountry(object sender, RoutedEventArgs e)
        {
            try
            {
                string countryName = txtAddCountryName.Text;
                string countryCurrency = txtAddCountryCurrency.Text;
                string countryLanguage = txtAddCountryLanguage.Text;
                int continentID = (listAddCountryContinent.SelectedItem as Continent).continentID;

                if (!(string.IsNullOrEmpty(countryName)
                    || string.IsNullOrEmpty(countryCurrency)
                    || string.IsNullOrEmpty(countryLanguage)))
                {
                    controller.AddCountry(countryName, countryCurrency, countryLanguage, continentID);
                    lblStatus.Content = "Successfully added country";
                    ResetInput();
                }
                else
                {
                    throw new Exception("Error, invalid data.");
                }
            }
            catch (Exception)
            {
                lblStatus.Content = "Error adding Country, please add required fields";
            }
            
        }

        // Close Window when Exit Button is clicked
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
