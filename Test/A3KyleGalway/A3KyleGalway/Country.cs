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
    Description: This class models a Country's data as retrieved from the Database
    */

    public class Country
    {
        // Property fields for Data Binding
        public int countryID
        {
            get; set;
        }

        public string countryName
        {
            get;
            set;
        }

        public string countryLanguage
        {
            get;
            set;
        }

        public string currency
        {
            get;
            set;
        }

        public int continentID
        {
            get;
            set;
        }

        // All args constructor for complete initialization
        public Country()
        {
            countryID = 0;
            countryName = "";
            countryLanguage = "";
            currency = "";
            continentID = 0;
        }

        // No args constructor for Data Binding and accessibility
        public Country(int countryID, string countryName, string countryLanguage, string currency, int continentID)
        {
            this.countryID = countryID;
            this.countryName = countryName;
            this.countryLanguage = countryLanguage;
            this.currency = currency;
            this.continentID = continentID;
        }

        // Overridden ToString for display
        public override string ToString()
        {
            return $"{countryID}. {countryName}";
        }

        // Default Country for unselecting
        public static Country DefaultCountry = new Country(0, "No Country Selected", "NA", "NA", 0);
    }
}
