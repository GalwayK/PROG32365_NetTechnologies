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
    Description: This class models a List of Continents implementing the INotifyCollectionChanged interface
    */

    public class ListContinents: List<Continent>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler? CollectionChanged;


        // Check if List contains Continent Name
        public bool Contains(string continentName)
        {
            foreach (Continent continent in this)
            {
                if (continent.continentName.Equals(continentName))
                {
                    return true;
                }
            }

            return false; 
        }

        // Add new Continent to List
        public new void Add(Continent continent) 
        { 
            base.Add(continent);
            this.NotifyCollectionChange();
        }

        // Notify subscribers when Collection changes
        private void NotifyCollectionChange()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
