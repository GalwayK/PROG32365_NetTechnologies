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
        private Order orderTemplate = new Order();
        private Customer customerTemplate = Customer.PlaceholderCustomer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeWindowItems(object sender, RoutedEventArgs e)
        {
            void initializeStatusBar()
            {
                lblCustomer.DataContext = customerTemplate;
                lblOrder.DataContext = orderTemplate;
            }

            void initializePlaceOrderTab()
            {
                listSideItems.ItemsSource = MiscItem.listOtherItems;
                listDrinkItems.ItemsSource = MiscItem.listDrinkItems;

                listSize.ItemsSource = PizzaItem.listAvailablePizzaSizes;
                listType.ItemsSource = PizzaItem.listAvailablePizzaTypes;

                listSize.SelectedIndex = 0;
                listType.SelectedIndex = 0;

                lblPizzaTemplate.DataContext = this.pizzaItemTemplate;

                listRemoveTopping.ItemsSource = PizzaItem.listAvailableToppings;
                listAddTopping.ItemsSource = PizzaItem.listAvailableToppings;

                listRemoveTopping.SelectedIndex = 0;
                listAddTopping.SelectedIndex = 0;
            }

            void initializeConfirmOrderTabItems()
            {
                listOpenOrders.DataContext = pizzaShop.listOrders;

                listSelectedItems.DataContext = orderTemplate;
                InitializeCostLabels();
            }

            void initializeCustomerInformationTabItems()
            {
                pizzaShop.customerList.Add(new Customer("Liam", "Galway", "", "", "", "", "", ""));

                txtAmountDue.DataContext = orderTemplate;
                listCustomers.DataContext = pizzaShop.customerList;
            }

            AddOrderToListOrders(orderTemplate);
            initializeStatusBar();
            initializePlaceOrderTab();
            initializeConfirmOrderTabItems();
            initializeCustomerInformationTabItems();
        }

        private void MoveToPlaceOrderTab()
        {
            TabOrder.Focus();     
        }

        private void MoveToConfirmOrderTab()
        {
            TabConfirm.Focus();
        }

        private void MoveToCustomerInformationTab()
        {
            TabCustomerInformation.Focus();
        }

        void InitializeCostLabels()
        {
            lblCost.DataContext = orderTemplate;
            lblTax.DataContext = orderTemplate;
            lblTotalCost.DataContext = orderTemplate;
        }

        void ResetPizzaTemplate()
        {
            pizzaItemTemplate = new PizzaItem();
        }

        void ResetOrderTemplate()
        {
            Order lastOrder = pizzaShop.GetLastOrder();
            if (lastOrder.Price == 0.0M && lastOrder.statusCode == Order.OrderStatusCode.IN_PROGRESS)
            {
                orderTemplate = lastOrder;
            }
            else 
            {
                orderTemplate = new Order();
                pizzaShop.listOrders.Add(orderTemplate);
            }
            
        }

        void ResetPizzaInputs()
        {
            listAddTopping.SelectedIndex = 0;
            listRemoveTopping.SelectedIndex = 0;
            listType.SelectedIndex = 0;
            listSize.SelectedIndex = 0;
        }

        void ResetListSides()
        {
            listSideItems.SelectedIndex = 0;
        }

        void ResetListDrinks()
        {
            listDrinkItems.SelectedIndex = 0;
        }

        void ResetPlaceOrderTab()
        {
            ResetPizzaInputs();
            ResetListSides();
            ResetListDrinks();
        }

        void ResetConfirmOrderTab()
        {
            InitializeCostLabels();
            listSelectedItems.DataContext = orderTemplate;
        }

        void ResetStatusBar()
        {
            lblOrder.DataContext = orderTemplate;
            lblCustomer.DataContext = customerTemplate;
        }

        void ResetOrderTabs()
        {
            ResetPlaceOrderTab();
            ResetConfirmOrderTab();
            ResetStatusBar();
        }

        private void AddOrderToListOrders(Order order)
        {
            pizzaShop.listOrders.Add(order);
        }

        private void AddToppingToTemplatePizza(object sender, RoutedEventArgs e)
        {
            int toppingIndex = listAddTopping.SelectedIndex;
            Topping topping = PizzaItem.listAvailableToppings[toppingIndex];
            this.pizzaItemTemplate.AddTopping(topping);
        }

        private void RemoveToppingFromTemplatePizza(object sender, RoutedEventArgs e)
        {
            int toppingIndex = listRemoveTopping.SelectedIndex;
            Topping topping = PizzaItem.listAvailableToppings[toppingIndex];
            this.pizzaItemTemplate.RemoveTopping(topping);
        }

        private void UpdatePizzaTemplateType(object sender, SelectionChangedEventArgs e)
        {
            int typeIndex = listType.SelectedIndex;
            PizzaItem.PizzaType pizzaType = PizzaItem.listAvailablePizzaTypes[typeIndex];
            pizzaItemTemplate.ChangeType(pizzaType);
        }

        private void UpdatePizzaTemplateSize(object sender, SelectionChangedEventArgs e)
        {
            int sizeIndex = listSize.SelectedIndex;
            PizzaItem.PizzaSize pizzaSize = PizzaItem.listAvailablePizzaSizes[sizeIndex];
            pizzaItemTemplate.ChangeSize(pizzaSize);
        }

        private void AddPizzaToOrderTemplate(object sender, RoutedEventArgs e)
        {
            orderTemplate.Add(pizzaItemTemplate, 1);
            ResetPizzaTemplate();
            ResetPizzaInputs();
        }

        private void AddSideToOrderTemplate(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Adding Side!");
            try
            {
                int intQuantity = Convert.ToInt32(txtSideQuantity.Text);
                if (intQuantity < 0) 
                {
                    throw new FormatException();
                }
                int sideIndex = listSideItems.SelectedIndex;
                MiscItem sideItem = MiscItem.listOtherItems[sideIndex];
                orderTemplate.Add(sideItem, intQuantity);

                Console.WriteLine(orderTemplate);

                lblStatus.Content = $"Item: {sideItem.StrName} Quantity: {intQuantity} added to order";
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                lblStatus.Content = "Error Adding Side: Must select a drink to add to order.";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                lblStatus.Content = "Error Adding Side: Please enter a positive number as quantity.";
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                lblStatus.Content = "Error Adding Side: An error occured.";
            }
        }

        private void AddDrinkToOrderTemplate(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Adding Drink!");

            try
            {
                int intQuantity = Convert.ToInt32(txtDrinkQuantity.Text);
                if (intQuantity < 0)
                {
                    throw new FormatException();
                }
                int drinkIndex = listDrinkItems.SelectedIndex;
                MiscItem drinkItem = MiscItem.listDrinkItems[drinkIndex];
                orderTemplate.Add(drinkItem, intQuantity);

                lblStatus.Content = $"Item: {drinkItem.StrName} Quantity: {intQuantity} added to order";
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                lblStatus.Content = "Error Adding Drink: Must select a drink to add to order.";
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                lblStatus.Content = "Error Adding Drink: Please enter a positive number as quantity.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                lblStatus.Content = "Error Adding Drink: An error occured.";
            }

        }

        private void FinalizeOrder(object sender, RoutedEventArgs e)
        {
            PlaceNewOrder();
            MoveToConfirmOrderTab();
        }

        private void OrderAgain(object sender, RoutedEventArgs e)
        {
            PlaceNewOrder();
            MoveToPlaceOrderTab();
        }

        private void PlaceNewOrder()
        {
            Console.WriteLine("Making new order!");
            if (!pizzaShop.listOrders.Contains(orderTemplate))
            {
                this.AddOrderToListOrders(orderTemplate);
            }
            ResetOrderTemplate();
            ResetOrderTabs();
        }

        private void ChangeOrderTemplate(object sender, RoutedEventArgs e)
        {
            int orderIndex = listOpenOrders.SelectedIndex;
            Order order = pizzaShop.listOrders[orderIndex];
            string strStatus = $"Error Changing Order: Selected Order is Complete or Cancelled";
            if (order.statusCode == Order.OrderStatusCode.IN_PROGRESS)
            {
                orderTemplate = pizzaShop.listOrders[orderIndex];
                ResetOrderTabs();
                strStatus = $"Current Order Changed, New Order: {orderTemplate}";
            }
            lblStatus.Content = strStatus;
        }

        private void RemoveItemFromOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemIndex = listSelectedItems.SelectedIndex;
                OrderItem item = orderTemplate[itemIndex].Key;

                orderTemplate.RemoveAt(itemIndex);

                lblStatus.Content = $"Removed item {item}";
            }
            catch (Exception ex)
            {
                lblStatus.Content = $"Error removing item";
            }
        }

        private void ClearOrder(object sender, RoutedEventArgs e)
        {
            orderTemplate.ChangeOrderStatus(Order.OrderStatusCode.CANCELLED);
            ResetOrderTemplate();
            ResetOrderTabs();

            lblStatus.Content = "Order cancelled.";
        }

        private void CheckoutOrder(object sender, RoutedEventArgs e)
        {
            bool isOrderEmpty = orderTemplate.Count == 0;
            bool isOrderInactive = orderTemplate.statusCode != Order.OrderStatusCode.IN_PROGRESS;

            string strStatus = "Cannot checkout empty order";
            if (!isOrderEmpty) 
            {
                strStatus = "Cannot checkout inactive order";
                if (!isOrderInactive)
                {
                    MoveToCustomerInformationTab();
                    strStatus = "Checking out order";
                }
            }
            lblStatus.Content = strStatus;
            
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {

        }
    }
}

/*
    void TestTabs()
        {
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
            PrintPizzaToppings();
            PrintPizzaSizes();
            PrintPizzaTypes();
            PrintDrinkItems();
            PrintOtherItems();
            TestPizzas();
            TestOrder();
        }
 * 
*/
