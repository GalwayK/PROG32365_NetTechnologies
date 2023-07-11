using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace A2KyleGalway
{
    internal class Order: List<KeyValuePair<OrderItem, int>>
    {
        public Order() 
        {
            CalculateFinalOrderPrice();
        }

        private OrderStatusCode statusCode = OrderStatusCode.IN_PROGRESS;
        public Customer Customer { get; set; }

        public string Status 
        { 
            get => arrOrderStatuses[(int)statusCode]; 
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
        }

        public new void Add(KeyValuePair<OrderItem, int> item)
        {
            base.Add(item);
            CalculateFinalOrderPrice();
        }

        public new void Remove(KeyValuePair<OrderItem, int> item)
        {
            base.Remove(item);
            CalculateFinalOrderPrice();
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

        public override string ToString()
        {
            return $"Total Price: {Price:C} Status: {Status}";
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
