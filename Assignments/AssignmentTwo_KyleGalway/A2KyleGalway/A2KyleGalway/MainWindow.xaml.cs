using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A2KyleGalway
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private PizzaShop pizzaShop = PizzaShop.SingletonPizzaShopFactory();
        private PizzaItem pizzaItemTemplate = new PizzaItem();

        public MainWindow()
        {
            InitializeComponent();

            PrintPizzaToppings();
            PrintPizzaSizes();
            PrintPizzaTypes();
            PrintDrinkItems();
            PrintOtherItems();
            TestPizzas();
            TestOrder();
        }

        void TestPizzas()
        {
            PizzaItem pizzaOne = new PizzaItem();
            pizzaOne.ChangeSize(PizzaItem.listAvailablePizzaSizes[2]);
            pizzaOne.ChangeType(PizzaItem.listAvailablePizzaTypes[2]);
            pizzaOne.AddTopping(PizzaItem.listAvailableToppings[0]);
            pizzaOne.AddTopping(PizzaItem.listAvailableToppings[10]);

            Console.WriteLine("\n" + pizzaOne);

            PizzaItem pizzaTwo = new PizzaItem(PizzaItem.listAvailablePizzaSizes[3], 
                PizzaItem.listAvailablePizzaTypes[2]);
            Console.WriteLine("\n" + pizzaTwo);

            pizzaTwo.AddTopping(PizzaItem.listAvailableToppings[4]);
            Console.WriteLine("\n" + pizzaTwo);
            pizzaTwo.AddTopping(PizzaItem.listAvailableToppings[13]);
            Console.WriteLine("\n" + pizzaTwo);
            pizzaTwo.AddTopping(PizzaItem.listAvailableToppings[7]);
            Console.WriteLine("\n" + pizzaTwo);            
        }

        void TestOrder()
        {
            int orderNumber = pizzaShop.MakeNewOrder();
            pizzaShop.AddDrinkItem(orderNumber, 3, 3);
            pizzaShop.AddOtherItem(orderNumber, 5, 3);

            PizzaItem pizzaOne = new PizzaItem();
            pizzaOne.ChangeSize(PizzaItem.listAvailablePizzaSizes[2]);
            pizzaOne.ChangeType(PizzaItem.listAvailablePizzaTypes[2]);
            pizzaOne.AddTopping(PizzaItem.listAvailableToppings[0]);
            pizzaOne.AddTopping(PizzaItem.listAvailableToppings[10]);

            pizzaShop.AddPizzaToOrder(orderNumber, pizzaOne);

            Console.WriteLine("\nTesting Order: ");
            foreach (KeyValuePair<OrderItem, int> order in pizzaShop.listOrders[orderNumber])
            {
                OrderItem item = order.Key;
                int quantity = order.Value;
                Console.WriteLine($"{item} Quantity: {quantity}");
            }
            Console.WriteLine(pizzaShop.GetOrder(orderNumber));
            pizzaShop.CancelOrder(orderNumber);
            Console.WriteLine(pizzaShop.GetOrder(orderNumber));

            int orderTwoNumber = pizzaShop.MakeNewOrder();
            pizzaShop.AddDrinkItem(orderTwoNumber, 0, 10);

            Console.WriteLine("\nTesting Order: ");
            foreach (KeyValuePair<OrderItem, int> order in pizzaShop.listOrders[orderTwoNumber])
            {
                OrderItem item = order.Key;
                int quantity = order.Value;
                Console.WriteLine($"{item} Quantity: {quantity}");
            }
            Console.WriteLine(pizzaShop.GetOrder(orderTwoNumber));
            pizzaShop.ConfirmOrder(orderTwoNumber);
            Console.WriteLine(pizzaShop.GetOrder(orderTwoNumber));

            Customer customer = new Customer("Kyle", "Galway", "2535 Barcella Crescent", "L5K1E5", "647-978-8468");
            pizzaShop.AddCustomerToOrder(orderTwoNumber, customer);
            Order testOrder = pizzaShop.GetOrder(orderTwoNumber);
            Console.WriteLine($"Customer #{testOrder.Customer.Id}: {testOrder.Customer.FirstName} {testOrder.Customer.LastName}");

        }

        void PrintPizzaSizes()
        {
            foreach (PizzaItem.PizzaSize pizzaSize in PizzaItem.listAvailablePizzaSizes)
            {
                Console.WriteLine($"Pizza Type #{pizzaSize.id}: {pizzaSize.strSize} {pizzaSize.numSizePrice:C}");
            }
            Console.WriteLine();
        }

        void PrintPizzaTypes()
        {
            foreach (PizzaItem.PizzaType pizzaType in PizzaItem.listAvailablePizzaTypes)
            {
                Console.WriteLine($"Pizza Type #{pizzaType.id}: {pizzaType.strType} {pizzaType.numTypePrice:C}");
            }
            Console.WriteLine();
        }

        void PrintPizzaToppings()
        {
            foreach (Topping topping in PizzaItem.listAvailableToppings)
            {
                Console.WriteLine($"Topping #{topping.id}: {topping.strName} {topping.GetToppingPrice():C}");
            }
            Console.WriteLine();
        }

        void PrintDrinkItems()
        {
            foreach (MiscItem item in MiscItem.listDrinkItems)
            {
                Console.WriteLine($"Drink #{item.ItemId}: {item.StrName} {item.NumPrice:C}");
            }
            Console.WriteLine();
        }

        void PrintOtherItems()
        {
            foreach (MiscItem item in MiscItem.listOtherItems)
            {
                Console.WriteLine($"Item #{item.ItemId}: {item.StrName} {item.NumPrice:C}");
            }
            Console.WriteLine();
        }

        private void initializeLists(object sender, RoutedEventArgs e)
        {
            listSideItems.ItemsSource = MiscItem.listOtherItems;
            listDrinkItems.ItemsSource = MiscItem.listDrinkItems;
            listSize.ItemsSource = PizzaItem.listAvailablePizzaSizes;
            listType.ItemsSource = PizzaItem.listAvailablePizzaTypes;
            lblPizzaTemplate.DataContext = this.pizzaItemTemplate;
            lblPizzaTemplate.Content = lblPizzaTemplate.DataContext.ToString();
            listRemoveTopping.ItemsSource = PizzaItem.listAvailableToppings;
            listAddTopping.ItemsSource = PizzaItem.listAvailableToppings;
        }
    }
}
