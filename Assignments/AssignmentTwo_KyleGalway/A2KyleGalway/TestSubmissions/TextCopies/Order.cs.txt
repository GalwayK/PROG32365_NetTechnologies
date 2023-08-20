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
        // Event Handler to notify GUI on property or collection change
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        // OrderID getter and setter
        public int OrderID 
        { 
            get; set; 
        }

        // Constructors for Order
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

        // Property to return list of orders for GUI binding purposes
        public Order DisplayList 
        {
            get => this;
        }

        // Field to retrieve status code of Order
        public OrderStatusCode statusCode = OrderStatusCode.IN_PROGRESS;

        // Unused field to assign customer to Order
        public Customer Customer { get; set; }

        // Getter to return current status of Order
        public string Status 
        { 
            get => arrOrderStatuses[(int)statusCode];
        }

        // Getter for Tax Price formatted as money
        public string StrTaxPrice
        {
            get => TaxPrice.ToString("C");
        }

        // Getter for TotalPrice formatted as money
        public string StrTotalPrice
        {
            get => TotalPrice.ToString("C");
        }

        // Getter for Price formatted as money
        public string StrPrice
        {
            get => Price.ToString("C");
        }

        // Getter and Setter for unformatted Tax Price
        public decimal TaxPrice
        {
            get; set;
        }

        // Getter and Setter for unformatted Total Price
        public decimal TotalPrice
        { 
            get; set; 
        }

        // Getter and Setter for unformatted Price
        public decimal Price
        {
            get
            {
                return TotalPrice + TaxPrice;
            }
        }

        // Method to change Order status code
        public void ChangeOrderStatus(OrderStatusCode statusCode)
        {
            this.statusCode = statusCode;
            UpdateProperties();
        }

        // Method to update all properties of Order whenever a change occurs
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

        // Method to add new Order Item to order as KeyValuePair
        public new void Add(KeyValuePair<OrderItem, int> orderPair)
        {
            base.Add(orderPair);

            CollectionChanged?.Invoke(this, new
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            CalculateFinalOrderPrice();
            UpdateProperties();
        }

        // Method to add new Order Item to order as OrderItem and int combination
        public void Add(OrderItem item, int quantity)
        {
            KeyValuePair<OrderItem, int> orderPair = new KeyValuePair<OrderItem, int>(item, quantity);
            base.Add(orderPair);

            CollectionChanged?.Invoke(this, new
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            CalculateFinalOrderPrice();
            UpdateProperties();
        }

        // Method to remove Order Item from Order
        public new void RemoveAt(int index)
        {
            KeyValuePair<OrderItem, int> orderPair = this[index];
            base.RemoveAt(index);

            CollectionChanged?.Invoke(this, new
                NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

            CalculateFinalOrderPrice();
            UpdateProperties();
        }

        // Method to recalculate total price whenever an item is added or removed
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

        // Getter to retrieve Order as String property to bind to GUI
        public string OrderString
        {
            get
            {
                return this.ToString();
            }
        }

        // Property to retrieve Order list as property to bind to GUI
        public List<string> DisplayItems
        {
            get 
            { 
                return this.GetDisplayItems(); 
            }
        }

        // Property to retrieve Order list formatted as strings for display purposes
        public List<string> GetDisplayItems()
        {
            List<string> displayList = new List<string>();
            foreach (KeyValuePair<OrderItem, int> orderInfo in this) 
            { 
                displayList.Add($"{orderInfo.Key.ToString()}, quantity: {orderInfo.Value}");
            }

            return displayList;
        }

        // Overridden ToString()
        public override string ToString()
        {
            return $"ID: {OrderID} Total Price: {Price:C} Status: {Status}";
        }

        //  Enum containing all viable OrderStatusCodes
        public enum OrderStatusCode: int
        {
            IN_PROGRESS = 0, 
            CONFIRMED = 1, 
            CANCELLED = 2 
        }

        // Readonly array of viable OrderStatusMessages
        static readonly string[] arrOrderStatuses = {"In-progress", "Confirmed", "Cancelled"};
    }
}
