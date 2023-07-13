using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class PizzaShop
    {
        private static PizzaShop pizzaShop = new PizzaShop();
        public OrderList listOrders = new OrderList();
        public CustomerList customerList = new CustomerList();

        public PizzaShop AddDrinkItem(int orderNumber, int drinkIndex, int quantity = 1)
        {
            KeyValuePair<OrderItem, int> orderItem = new KeyValuePair<OrderItem, int>(MiscItem.listDrinkItems[drinkIndex], quantity);
            listOrders[orderNumber].Add(orderItem);
            return this;
        }

        public PizzaShop RemoveItem(int orderNumber, int orderIndex)
        {
            listOrders[orderNumber].RemoveAt(orderIndex);
            return this;
        }

        public PizzaShop AddOtherItem(int orderNumber, int itemIndex, int quantity = 1)
        {
            KeyValuePair<OrderItem, int> orderItem = new KeyValuePair<OrderItem, int>(MiscItem.listOtherItems[itemIndex], quantity);
            listOrders[orderNumber].Add(orderItem);
            return this;
        }

        public PizzaShop AddPizzaToOrder(int orderNumber, PizzaItem pizzaItem, int quantity = 1)
        {
            KeyValuePair<OrderItem, int> orderItem = new KeyValuePair<OrderItem, int>(pizzaItem, quantity);
            listOrders[orderNumber].Add(orderItem);
            return this;
        }

        public KeyValuePair<OrderItem, int> GetItemAtIndex(int orderNumber, int orderIndex)
        {
            return listOrders[orderNumber][orderIndex];
        }

        public Order GetOrderList(int orderNumber)
        {
            return listOrders[orderNumber]; 
        }

        public int MakeNewOrder()
        {
            listOrders.Add(new Order());

            return listOrders.Count - 1;
        }

        public Order GetOrder(int orderNumber)
        {
            return listOrders[orderNumber];
        }

        public Order GetLastOrder()
        {
            return listOrders.Last<Order>();
        }

        public decimal GetTotalOrderPrice(int orderNumber)
        {
            return listOrders[orderNumber].Price;
        }

        public PizzaShop CancelOrder(int orderNumber)
        {
            pizzaShop.GetOrder(orderNumber).ChangeOrderStatus(Order.OrderStatusCode.CANCELLED);
            return this;
        }

        public PizzaShop ConfirmOrder(int orderNumber)
        {
            pizzaShop.GetOrder(orderNumber).ChangeOrderStatus(Order.OrderStatusCode.CONFIRMED);
            return this;
        }

        public Customer CreateNewCustomer(string firstName, string lastName, string address, string postalCode, 
            string phoneNumber,
            string province = "", string city = "", string email = "")
        {
            Customer customer = new Customer(firstName, lastName, address, postalCode, phoneNumber,
                province = "", city = "", email = "");
            customerList.Add(customer);
            return customer;
        }

        public PizzaShop AddCustomerToOrder(int orderNumber, Customer customer)
        {
            Order order = this.GetOrder(orderNumber);
            order.Customer = customer;
            return this;
        }

        private PizzaShop() { }

        public static PizzaShop SingletonPizzaShopFactory()
        {
            return pizzaShop;
        }
    }
}
