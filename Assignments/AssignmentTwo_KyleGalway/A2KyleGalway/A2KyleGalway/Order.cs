using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace A2KyleGalway
{
    internal class Order: List<KeyValuePair<OrderItem, int>>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public int OrderID 
        { 
            get; set; 
        }

        public Order() 
        {
            this.OrderID = 0;
            CalculateFinalOrderPrice();
        }

        public Order(int orderID)
        {
            this.OrderID = orderID;
            CalculateFinalOrderPrice();
        }

        public Order DisplayList 
        {
            get => this;
        }

        public OrderStatusCode statusCode = OrderStatusCode.IN_PROGRESS;

        public Customer Customer { get; set; }

        public string Status 
        { 
            get => arrOrderStatuses[(int)statusCode];
        }

        public string StrTaxPrice
        {
            get => TaxPrice.ToString("C");
        }

        public string StrTotalPrice
        {
            get => TotalPrice.ToString("C");
        }

        public string StrPrice
        {
            get => Price.ToString("C");
        }

        public decimal TaxPrice
        {
            get; set;
        }

        public decimal TotalPrice
        { 
            get; set; 
        }

        public decimal Price
        {
            get
            {
                return TotalPrice + TaxPrice;
            }
        }

        public void ChangeOrderStatus(OrderStatusCode statusCode)
        {
            this.statusCode = statusCode;
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayList)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxPrice)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPrice)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StrPrice)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StrTaxPrice)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StrTotalPrice)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderString)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayItems)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
        }

        public new void Add(KeyValuePair<OrderItem, int> orderPair)
        {
            base.Add(orderPair);

            CollectionChanged?.Invoke(this, new
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            CalculateFinalOrderPrice();
            UpdateProperties();
        }

        public void Add(OrderItem item, int quantity)
        {
            KeyValuePair<OrderItem, int> orderPair = new KeyValuePair<OrderItem, int>(item, quantity);
            base.Add(orderPair);

            CollectionChanged?.Invoke(this, new
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            CalculateFinalOrderPrice();
            UpdateProperties();
        }

        public new void RemoveAt(int index)
        {
            KeyValuePair<OrderItem, int> orderPair = this[index];
            base.RemoveAt(index);

            CollectionChanged?.Invoke(this, new
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            CalculateFinalOrderPrice();
            UpdateProperties();
        }

        private decimal CalculateFinalOrderPrice()
        {
            decimal CalculateTotalOrderPrice()
            {
                TotalPrice = 0.0M;
                void CalculateTotalPrice(KeyValuePair<OrderItem, int> order)
                {
                    OrderItem item = order.Key;
                    int quantity = order.Value;

                    TotalPrice += item.CalculatePrice() * quantity;
                };

                this.ForEach(CalculateTotalPrice);

                return TotalPrice;
            }

            decimal CalculateTotalTaxPrice()
            {
                TaxPrice = TotalPrice * 0.13M;
                return TaxPrice;
            }

            CalculateTotalOrderPrice();
            CalculateTotalTaxPrice();
            return Price;
        }

        public string OrderString
        {
            get
            {
                return this.ToString();
            }
        }

        public List<string> DisplayItems
        {
            get 
            { 
                return this.GetDisplayItems(); 
            }
        }

        public List<string> GetDisplayItems()
        {
            List<string> displayList = new List<string>();
            foreach (KeyValuePair<OrderItem, int> orderInfo in this) 
            { 
                displayList.Add($"{orderInfo.Key.ToString()}, quantity: {orderInfo.Value}");
            }

            return displayList;
        }

        public override string ToString()
        {
            return $"ID: {OrderID} Total Price: {Price:C} Status: {Status}";
        }

        public enum OrderStatusCode: int
        {
            IN_PROGRESS = 0, 
            CONFIRMED = 1, 
            CANCELLED = 2 
        }

        static string[] arrOrderStatuses = {"In-progress", "Confirmed", "Cancelled"};
    }
}
