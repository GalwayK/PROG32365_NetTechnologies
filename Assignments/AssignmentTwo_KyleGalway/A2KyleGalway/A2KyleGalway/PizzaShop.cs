using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class PizzaShop
    {
        // Static Properties 

        private static PizzaShop pizzaShop = new PizzaShop();

        public static PizzaItem MakeNewPizza()
        {
            return new PizzaItem();
        }

        public Order MakeTrackedOrder()
        {
            return new Order(listOrders.Count + 1);
        }

        public static Order MakeUntrackedOrder()
        {
            return new Order();
        }

        public static Customer DefaultCustomer 
        {
            get =>  Customer.PlaceholderCustomer;
        }
        public static List<MiscItem> PizzaShopListDrinkItems
        {
            get => MiscItem.listDrinkItems;
        }

        public static List<MiscItem> PizzaShopListSideItems
        {
            get => MiscItem.listOtherItems;
        }

        public static List<PizzaItem.PizzaSize> ListPizzaSizes
        {
            get => PizzaItem.listAvailablePizzaSizes;
        }

        public static List<PizzaItem.PizzaType> ListPizzaTypes
        {
            get => PizzaItem.listAvailablePizzaTypes;
        }

        public static List<Topping> ListPizzaToppings
        {
            get => PizzaItem.listAvailableToppings;
        }

        public static List<string> ListPaymentTypes
        {
            get => Customer.GetListPaymentTypes();
        }

        // Non-static Properties

        public OrderList listOrders = new OrderList();
        public CustomerList customerList = new CustomerList();

        public void AddOrderToListOrders(Order order)
        {
            this.listOrders.Add(order);
        }

        internal void AddToppingToPizza(PizzaItem pizzaItem, int toppingIndex)
        {
            Topping topping = ListPizzaToppings[toppingIndex];
            pizzaItem.AddTopping(topping);
        }

        public void RemoveToppingFromPizza(PizzaItem pizzaItem,  int toppingIndex)
        {
            Topping topping = ListPizzaToppings[toppingIndex];
            pizzaItem.RemoveTopping(topping);
        }

        public void UpdatePizzaSize(PizzaItem pizzaItem, int sizeIndex)
        {
            PizzaItem.PizzaSize size = ListPizzaSizes[sizeIndex];
            pizzaItem.ChangeSize(size);
        }

        public void UpdatePizzaType(PizzaItem pizzaItem, int sizeIndex)
        {
            PizzaItem.PizzaType type = ListPizzaTypes[sizeIndex];
            pizzaItem.ChangeType(type);
        }

        public void AddPizzaItemToOrder(Order order, PizzaItem pizzaItem, int quantity=1)
        {
            order.Add(pizzaItem, quantity);
        }

        public void AddSideItemToOrder(Order order, int sideIndex, int quantity=1)
        {
            MiscItem sideItem = PizzaShopListSideItems[sideIndex];
            order.Add(sideItem, quantity);
        }

        public void AddDrinkItemToOrder(Order order, int drinkIndex, int quantity)
        {
            MiscItem drinkItem = PizzaShopListDrinkItems[drinkIndex];
            order.Add(drinkItem, quantity);
        }

        public void AddOrderToOrderList(Order order)
        {
            if (!this.listOrders.Contains(order))
            {
                this.listOrders.Add(order);
            }
        }

        public Order GetOrder(int orderIndex)
        {
            return this.listOrders[orderIndex];
        }

        public void RemoveItemFromOrder(Order order, int itemIndex)
        {
            order.RemoveAt(itemIndex);
        }

        public void CancelOrder(Order order)
        {
            order.ChangeOrderStatus(Order.OrderStatusCode.CANCELLED);
        }

        public void ConfirmOrder(Order order)
        {
            order.ChangeOrderStatus(Order.OrderStatusCode.CONFIRMED);
        }

        public void CreateNewCustomer(string firstName, string lastName, string address, string postalCode,
            string phoneNumber, string province = "", string city = "", string email = "")
        {
            Customer customer = new Customer(firstName, lastName, address, postalCode, phoneNumber,
                province = "", city = "", email = "");
            customerList.Add(customer);
        }
        
        public Customer GetCustomer(int customerIndex)
        {
            return customerList[customerIndex];
        }

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

        public Order GetLastOrder()
        {

            return listOrders.Count > 0 
                ? listOrders.Last<Order>()
                : null;
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
