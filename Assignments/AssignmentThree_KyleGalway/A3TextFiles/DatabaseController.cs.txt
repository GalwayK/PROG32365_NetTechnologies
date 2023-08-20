using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace A3KyleGalway
{
    /*
    Name: Kyle Galway 
    Email: galwayk@sheridanc.on.ca
    Description: This is the controller for allowing the view to interact with the Models and Database
    */

    public class DatabaseController
    {
        // Singleton Instance of Controller to make available to view classes
        private static DatabaseController _databaseController = new DatabaseController();

        // Repository class for performing Database operations
        private DatabaseRepository repository = DatabaseRepository.DataRepository;

        // List Continents property for displaying Continents
        private ListContinents listContinents;

        // Make available List of Continents
        public ListContinents GetListContinents()
        {
            listContinents = LoadListContinents();
            return listContinents;
        }

        // Make available List of Countries organized by Continent
        public ListCountries GetListCountries(int searchContinentID)
        {
            ListCountries countries = new ListCountries();
            
            countries.AddRange(repository.ReadCountries(searchContinentID));

            return countries;
        }

        // Refresh Continents from Database
        private ListContinents LoadListContinents()
        {
            ListContinents listContinents = new ListContinents();

            listContinents.AddRange(repository.ReadContinents());

            return listContinents;
        }

        // Load DataTable from Database to display City information by Country
        public DataTable GetCityDataByCountryID(int searchCountryID)
        {
            DataTable cityDataTable = repository.ReadCitiesByCountryID(searchCountryID);

            return cityDataTable;
        }


        // Retrieve all Countries stored in Database as List
        public List<Country> GetAllCountries()
        {
            List<Country> countries = repository.ReadAllCountries();

            return countries;
        }

        // Retrieve all Cities stored in Database as List
        public List<City> GetAllCities()
        {
            List<City> cityList = repository.ReadCities();
            
            return cityList;
        }


        // Add new Continent to Database
        public int AddContinent(string continentName)
        {
            int numEffectedRows = 0;
            if (!string.IsNullOrEmpty(continentName))
            {
                numEffectedRows = repository.CreateContinent(continentName);
                listContinents = LoadListContinents();
            }
            return numEffectedRows;
        }
        
        // Add new Country to Database
        public int AddCountry(string countryName, string currency, string language, int continentID)
        {
            if (!(string.IsNullOrEmpty(countryName)
                || string.IsNullOrEmpty(currency)
                || string.IsNullOrEmpty(language)))
            {
                return repository.CreateCountry(countryName, currency, language, continentID);
            }
            return 0;
        }

        // Add new City to Database
        public int AddCity(string cityName, bool isCapital, string population, int countryID)
        {
            if (!(string.IsNullOrEmpty(cityName)))
            {
                return repository.CreateCity(cityName, isCapital, population, countryID);
            }
            return 0;
        }

        // Private Constructor to allow only single instance of Controller 
        private DatabaseController()
        {
            listContinents = LoadListContinents();
        }

        // Retrieve Singleton Controller instance 
        public static DatabaseController DataController
        {
            get => _databaseController;
        }

        // Retrieve Default Continent for unselecting
        public static Continent DefaultContinent
        {
            get => Continent.DefaultContinent;
        }

        // Retrieve Default Country for unselecting
        public static Country DefaultCountry
        {
            get => Country.DefaultCountry;
        }
    }
}
