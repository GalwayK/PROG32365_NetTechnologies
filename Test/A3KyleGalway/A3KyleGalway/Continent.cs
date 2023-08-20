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
    Description: This class models a Continent's data as retrieved from the Database
    */

    public class Continent
    {
        // Property fields for Data Binding
        public int continentID
        {
            get;
            set;
        }
        public string continentName
        {
            get;
            set;
        }

        // All args constructor for complete initialization
        public Continent(int continentID, string continentName)
        {
            this.continentID = continentID;
            this.continentName = continentName;
        }

        // No args constructor for data binding and accessibility
        public Continent()
        {
            continentID = 0;
            continentName = string.Empty;
        }

        // Overridden ToString for display
        public override string ToString()
        {
            return $"{this.continentID}. {this.continentName}";
        }

        // Default Continent object for unselecting 
        public static Continent DefaultContinent = new Continent(0, "No Continent Selected");
    }
}
