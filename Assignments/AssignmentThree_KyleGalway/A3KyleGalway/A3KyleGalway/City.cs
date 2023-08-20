using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3KyleGalway
{
    /*
    Name: Kyle Galway 
    Email: galwayk@sheridanc.on.ca
    Description: This class models a City's data as retrieved from the Database
    */

    public class City
    {

        // Property fields of City for potential use in Data Binding
        public int CityID
        {
            get;
            set;
        }

        public string CityName
        {
            get;
            set;
        }

        public string Population
        {
            get;
            set;
        }

        public bool IsCapital
        { 
            get; 
            set;
        }

        public int CountryID
        {
            get;
            set;
        }

        // All args constructor for complete initialization
        public City(int cityID, string cityName, string population, bool isCapital, int countryID)
        {
            CityID = cityID;
            CityName = cityName;
            Population = population;
            IsCapital = isCapital;
            CountryID = countryID;
        }

        // No args constructor for data binding and accessibility
        public City() 
        {
            CityID = 0;
            Population = "";
            IsCapital = false;
            CityName = "";
            CountryID = 0;
        }

        // Overridden ToString for display
        public override string ToString()
        {
            return $"{CityID}. {CityName}";
        }
    }
}
