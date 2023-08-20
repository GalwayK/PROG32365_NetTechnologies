using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class CustomerList: List<Customer>, INotifyCollectionChanged
    {
        // Event Handler to notify GUI on collection changed
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        // Property to retrieve List to display on GUI
        public List<Customer> DisplayList
        {
            get => this;
        }

        // Overridden Add method to notify GUI on collection changed
        public new void Add(Customer customer)
        {
            customer.Id = this.Count + 1;
            base.Add(customer);

            CollectionChanged?.Invoke(this, new
               NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
