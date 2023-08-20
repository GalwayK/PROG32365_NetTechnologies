using A3KyleGalway.AddWindows;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A3KyleGalway
{
    /*
        Name: Kyle Galway 
        Email: galwayk@sheridanc.on.ca
        Description: This is the view class for creating the main display window. 
    */

    public partial class MainWindow : Window
    {
        // DatabaseController instance for accessing Model and Database
        private DatabaseController controller = DatabaseController.DataController;

        // List of Models to set List and DataGrid bindings
        private ListCountries listCountryModels = new ListCountries();
        private ListContinents listContinentModels = new ListContinents();

        // Instance objects to set Country and Continent bindings
        private Country countryModel = DatabaseController.DefaultCountry;
        private Continent continentModel = DatabaseController.DefaultContinent;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Initialize all default controls on load
        private void initializeControls(object sender, RoutedEventArgs e)
        {
            ResetBindings();
            lblStatusText.Content = "Application loaded";
        }

        // Reset all Bindings to default values
        private void ResetBindings()
        {
            ResetListContinentBindings();   

            ResetListCountryBindings();

            ResetContinentBinding();

            ResetCountryBinding();
        }

        // Reset ListContinent bindings
        private void ResetListContinentBindings()
        {
            listContinentModels = controller.GetListContinents();

            listContinents.DataContext = listContinentModels;
            listContinents.ItemsSource = listContinentModels;
            listContinents.SelectedIndex = 0;
        }

        // Reset ListCountry bindings
        private void ResetListCountryBindings()
        {
            listCountryModels = controller.GetListCountries(continentModel.continentID);

            listCountries.DataContext = listCountryModels;
            listCountries.ItemsSource = listCountryModels;
            listCountries.SelectedIndex = 0;
        }

        // Reset Continent binding
        private void ResetContinentBinding()
        {
            lblStatusContinent.DataContext = continentModel;
        }

        // Reset Country Binding
        private void ResetCountryBinding()
        {
            txtLanguage.DataContext = countryModel;

            lblStatusCountry.DataContext = countryModel;

            txtCurrency.DataContext = countryModel;
        }

        // Load Continent from selected item in List of Continents
        private void LoadContinent()
        {
            if (listContinents.SelectedItem is Continent)
            {
                continentModel = listContinents.SelectedItem as Continent;
                ResetContinentBinding();
                ResetListCountryBindings();
                lblStatusText.Content = "Continent changed";
            }
        }

        // Load Country from selected item in List of Countries
        private void LoadCountryModel()
        {
            if (listCountries.SelectedItem is Country)
            {
                countryModel = listCountries.SelectedItem as Country;

                DataTable cityDataTable = controller.GetCityDataByCountryID(countryModel.countryID);
                listCities.ItemsSource = cityDataTable.DefaultView;

                ResetCountryBinding();
                lblStatusText.Content = "Country changed";
            }
            else
            {
                Console.WriteLine("Not changing country");
            }
        }

        // Handle Continent loading and binding on Continent Change
        private void HandleContinentChange(object sender, SelectionChangedEventArgs e)
        {
            if (sender == listContinents) 
            {
                LoadContinent();
            }
            
        }

        // Handle Country loading and binding on Country Change
        private void HandleCountryChange(object sender, SelectionChangedEventArgs e)
        {
            if (sender == listCountries)
            {
                LoadCountryModel();
            }
        }

        // Display Add Continent window for adding new Continent
        private void HandleAddContinent(object sender, RoutedEventArgs e)
        {
            AddContinentWindow addContinentWindow = new AddContinentWindow();

            addContinentWindow.ShowDialog();
            ResetBindings();
            lblStatusText.Content = "Add Continent Window Closed";
        }

        // Display Add Country window for adding new Country
        private void HandleAddCountry(object sender, RoutedEventArgs e)
        {
            AddCountryWindow addCountryWindow = new AddCountryWindow();
        
            addCountryWindow.ShowDialog();
            ResetBindings();
            lblStatusText.Content = "Add Country Window Closed";
        }

        // Display Add City window for adding new City
        private void HandleAddCity(object sender, RoutedEventArgs e)
        {
            AddCityWindow addCityWindow = new AddCityWindow();

            addCityWindow.ShowDialog();
            ResetBindings();
            lblStatusText.Content = "Add City Window Closed";
        }

        // Close application when user is finished
        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
