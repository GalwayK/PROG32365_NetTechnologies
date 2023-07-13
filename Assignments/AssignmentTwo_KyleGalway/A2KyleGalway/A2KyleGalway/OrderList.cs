using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class OrderList: List<Order>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Order> ListOrders
        {
            get => this;
        }

        public new void Add(Order order)
        {
            base.Add(order);

            CollectionChanged?.Invoke(this, new
              NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListOrders)));
        }

        public new void Remove(Order order)
        {
            base.Remove(order);

            CollectionChanged?.Invoke(this, new
               NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListOrders)));
        }

        public new void RemoveAt(int orderIndex)
        {
            Order order = this[orderIndex];
            base.RemoveAt(orderIndex);

            CollectionChanged?.Invoke(this, new
               NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListOrders)));
        }

        public override string ToString()
        {
            return $"Orders: {this.Count}";
        }
    }
}
