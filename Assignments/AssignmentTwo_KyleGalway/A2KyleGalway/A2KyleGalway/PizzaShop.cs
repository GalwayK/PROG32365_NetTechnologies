using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class PizzaShop
    {

        /*
         * Main controller for interfacing between GUI and models
        */

        // Static Properties 

        // Create singleton pizzaShop instance
        private static PizzaShop pizzaShop = new PizzaShop();

        // Make a new pizza 
        public static PizzaItem MakeNewPizza()
        {
            return new PizzaItem();
        }

        // Make an order that is added to list of orders
        public Order MakeTrackedOrder()
        {
            return new Order(listOrders.Count + 1);
        }

        // Make a new order that is not added to list of orders
        public static Order MakeUntrackedOrder()
        {
            return new Order();
        }

        // Retrieve default customer when no customer is signed in
        public static Customer DefaultCustomer 
        {
            get =>  Customer.PlaceholderCustomer;
        }

        // Retrieve List of drinks available in shop
        public static List<MiscItem> PizzaShopListDrinkItems
        {
            get => MiscItem.listDrinkItems;
        }

        // Retrieve list of side items available in shop
        public static List<MiscItem> PizzaShopListSideItems
        {
            get => MiscItem.listOtherItems;
        }


        // Retrieve list of sizes for Pizzas in shop
        public static List<PizzaItem.PizzaSize> ListPizzaSizes
        {
            get => PizzaItem.listAvailablePizzaSizes;
        }

        // Retrieve list of types for Pizzas in shop
        public static List<PizzaItem.PizzaType> ListPizzaTypes
        {
            get => PizzaItem.listAvailablePizzaTypes;
        }


        // Retrieve list of toppings for Pizzas in shop
        public static List<Topping> ListPizzaToppings
        {
            get => PizzaItem.listAvailableToppings;
        }

        // Retrieve list of payment types for Orders
        public static List<string> ListPaymentTypes
        {
            get => Customer.GetListPaymentTypes();
        }

        // Non-static Properties

        // Lists of Orders recorded and Customers of shop
        public OrderList listOrders = new OrderList();
        public CustomerList listCustomers = new CustomerList();

        // Add an Order to the List of Orders
        public void AddOrderToListOrders(Order order)
        {
            this.listOrders.Add(order);
        }

        // Add a Topping to Pizza from list of toppings
        internal void AddToppingToPizza(PizzaItem pizzaItem, int toppingIndex)
        {
            Topping topping = ListPizzaToppings[toppingIndex];
            pizzaItem.AddTopping(topping);
        }

        // Remove a Topping from Pizza from list of toppings
        public void RemoveToppingFromPizza(PizzaItem pizzaItem,  int toppingIndex)
        {
            Topping topping = ListPizzaToppings[toppingIndex];
            pizzaItem.RemoveTopping(topping);
        }

        // Update the size of Pizza from list of Pizza sizes
        public void UpdatePizzaSize(PizzaItem pizzaItem, int sizeIndex)
        {
            PizzaItem.PizzaSize size = ListPizzaSizes[sizeIndex];
            pizzaItem.ChangeSize(size);
        }

        // Update the type of Pizza from list of Pizza types
        public void UpdatePizzaType(PizzaItem pizzaItem, int sizeIndex)
        {
            PizzaItem.PizzaType type = ListPizzaTypes[sizeIndex];
            pizzaItem.ChangeType(type);
        }

        // Add Pizza to Order with optional quantity
        public void AddPizzaItemToOrder(Order order, PizzaItem pizzaItem, int quantity=1)
        {
            order.Add(pizzaItem, quantity);
        }

        // Add side item to Order from list of side items
        public void AddSideItemToOrder(Order order, int sideIndex, int quantity=1)
        {
            MiscItem sideItem = PizzaShopListSideItems[sideIndex];
            order.Add(sideItem, quantity);
        }

        // Add drink item to Order from list of drink items
        public void AddDrinkItemToOrder(Order order, int drinkIndex, int quantity)
        {
            MiscItem drinkItem = PizzaShopListDrinkItems[drinkIndex];
            order.Add(drinkItem, quantity);
        }

        // Add Order to Order List (all tracked orders)
        public void AddOrderToOrderList(Order order)
        {
            if (!this.listOrders.Contains(order))
            {
                this.listOrders.Add(order);
            }
        }

        // Get specified Order from List of tracked Orders
        public Order GetOrder(int orderIndex)
        {
            return this.listOrders[orderIndex];
        }

        // Remove Item from order based on itemIndex
        public void RemoveItemFromOrder(Order order, int itemIndex)
        {
            order.RemoveAt(itemIndex);
        }

        // Set Order status to cancelled
        public void CancelOrder(Order order)
        {
            order.ChangeOrderStatus(Order.OrderStatusCode.CANCELLED);
        }

        // Set Order status to confirmed
        public void ConfirmOrder(Order order)
        {
            order.ChangeOrderStatus(Order.OrderStatusCode.CONFIRMED);
        }

        // Create new customer based on input fields
        public void CreateNewCustomer(string firstName, string lastName, string address, string postalCode,
            string phoneNumber, string province = "", string city = "", string email = "")
        {
            Customer customer = new Customer(firstName, lastName, address, postalCode, phoneNumber,
                province = "", city = "", email = "");
            listCustomers.Add(customer);
        }
        
        // Get customer from List of Shop Customers
        public Customer GetCustomer(int customerIndex)
        {
            return listCustomers[customerIndex];
        }

        // Get the Last Added Order for PizzaShop
        public Order GetLastOrder()
        {

            return listOrders.Count > 0 
                ? listOrders.Last<Order>()
                : null;
        }

        // Default constructor to disallow multiple PizzaShop instances
        private PizzaShop() { }

        // Return Singleton of PizzaShop
        public static PizzaShop SingletonPizzaShopFactory()
        {
            return pizzaShop;
        }
    }
}
