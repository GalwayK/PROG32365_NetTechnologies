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
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public List<Customer> DisplayList
        {
            get => this;
        }

        public new void Add(Customer customer)
        {
            base.Add(customer);

            CollectionChanged?.Invoke(this, new
               NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
