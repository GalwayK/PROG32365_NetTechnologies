using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3KyleGalway
{
    /*
    Name: Kyle Galway 
    Email: galwayk@sheridanc.on.ca
    Description: This class services the Database by handling all Database transactions
    */

    public class DatabaseRepository
    {
        // Connection string retrieved from Application Configuration
        private string _strConnection = ConfigurationManager.ConnectionStrings["WorldDB"].ConnectionString;

        // Singleton Repository
        private static DatabaseRepository _singletonRepository = new DatabaseRepository();

        // Private constructor to disallow multiple instances
        private DatabaseRepository()
        {
        }

        // Test Connection to verify successful Database Access
        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strQuery = "SELECT * FROM City";


                SqlCommand command = new SqlCommand(strQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                }
            }
        }

        // Retrieve Countries from Database by Continent as List
        public List<Country> ReadCountries(int searchContinentID)
        {
            List<Country> listCountries = new List<Country>();
            using(SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strCountryQuery = "SELECT * FROM Country WHERE ContinentID = @continentID";

                SqlCommand command = new SqlCommand( strCountryQuery, connection);
                command.Parameters.AddWithValue("continentID", searchContinentID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    int countryID = (int)reader[0];
                    string countryName = (string)reader[1];
                    string language = (string)reader[2];
                    string currency = (string)reader[3];
                    int continentID = (int)reader[4];

                    Country country = new Country(countryID, countryName, language, currency, continentID);

                    listCountries.Add(country);
                }
            }

            return listCountries;
        }

        // Rerieve Continents from Database as List
        public List<Continent> ReadContinents()
        {
            List<Continent> listContinents = new List<Continent>();

            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strContinentQuery = "SELECT * FROM Continent";

                SqlCommand command = new SqlCommand(strContinentQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int continentID = (int)reader[0];
                    string continentName = (string)reader[1];

                    Continent continent = new Continent(continentID, continentName);

                    listContinents.Add(continent);
                }
            }

            return listContinents;
        }

        // Retrieve Cities from Database by Country ID as Data Table to display in DataGrid
        public DataTable ReadCitiesByCountryID(int searchCountryID)
        {
            DataTable cityDataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strCountryQuery = "SELECT * FROM City WHERE CountryId = @CountryID";

                SqlCommand command = new SqlCommand(strCountryQuery, connection);
                command.Parameters.AddWithValue("CountryID", searchCountryID);

                SqlDataReader reader = command.ExecuteReader();

                cityDataTable.Load(reader);
            }

            return cityDataTable;
        }

        // Retrieve all Cities from Database as List
        public List<City> ReadCities()
        {
            List<City> listCities = new List<City>();

            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strCityQuery = "SELECT * FROM City";

                SqlCommand command = new SqlCommand(strCityQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int cityID = (int)reader[0];
                    string cityName = (string)reader[1];
                    bool isCapital = (bool)reader[2];
                    string population = (string)reader[3];
                    int countryID = (int)reader[4];

                    City city = new City(cityID, cityName, population, isCapital, countryID);

                    listCities.Add(city);
                }
            }
            return listCities;
        }

        // Retrieve all Countries from Database as List
        public List<Country> ReadAllCountries()
        {
            List<Country> listCountries = new List<Country>();
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strCountryQuery = "SELECT * FROM Country";

                SqlCommand command = new SqlCommand(strCountryQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int countryID = (int)reader[0];
                    string countryName = (string)reader[1];
                    string language = (string)reader[2];
                    string currency = (string)reader[3];
                    int continentID = (int)reader[4];

                    Country country = new Country(countryID, countryName, language, currency, continentID);

                    listCountries.Add(country);
                }
            }
            return listCountries;
        }

        // Insert new Continent in Database
        public int CreateContinent(string continentName)
        {
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strContinentInsert = "INSERT INTO Continent (ContinentName) VALUES (@continentName)";

                SqlCommand command = new SqlCommand(strContinentInsert, connection);
                command.Parameters.AddWithValue("@continentName", continentName);

                return command.ExecuteNonQuery();
            }
        }

        // Insert new Country into Database
        public int CreateCountry(string countryName, string currency, string language, int continentID)
        {
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strCountryInsert = "INSERT INTO Country (CountryName, Language, Currency, ContinentID) VALUES (@CountryName, @Language, @Currency, @ContinentID)";

                SqlCommand command = new SqlCommand(strCountryInsert, connection);

                command.Parameters.AddWithValue("CountryName", countryName);
                command.Parameters.AddWithValue("Language", language);
                command.Parameters.AddWithValue("Currency", currency);
                command.Parameters.AddWithValue("ContinentID", continentID);

                return command.ExecuteNonQuery();
            }
        }

        // Insert new City into Database
        public int CreateCity(string cityName, bool isCapital, string population, int countryID)
        {
            using (SqlConnection connection = new SqlConnection(StrConnection))
            {
                connection.Open();
                string strCityInsert = "INSERT INTO City (CityName, IsCapital, Population, CountryID) VALUES (@CityName, @IsCapital, @Population, @CountryID)";

                SqlCommand command = new SqlCommand(strCityInsert, connection);

                command.Parameters.AddWithValue("CityName", cityName);
                command.Parameters.AddWithValue("IsCapital", isCapital);
                command.Parameters.AddWithValue("Population", population);
                command.Parameters.AddWithValue("CountryID", countryID);

                return command.ExecuteNonQuery();
            }
        }

        // Retrieve singleton Repository instance
        public static DatabaseRepository DataRepository
        {
            get => _singletonRepository; 
        }


        // Get Connection String
        public string StrConnection
        {
            get => _strConnection;
        }
    }
}
