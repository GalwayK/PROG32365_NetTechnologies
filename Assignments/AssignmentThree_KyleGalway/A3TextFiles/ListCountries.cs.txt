using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3KyleGalway
{
    /*
    Name: Kyle Galway 
    Email: galwayk@sheridanc.on.ca
    Description: This class models a List of Countries with implementation of the INotifyCollectionChanged interface
    */

    public class ListCountries: List<Country>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        // Check if Country ID is contained in list
        public bool Contains(int countryID)
        {
            foreach(Country country in this)
            {
                if (country.countryID == countryID)
                {
                    return true;
                }
            }
            return false; 
        }

        // Notify subscribers of Collection changes
        public void NotifyCollectionChange()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

    }
}
