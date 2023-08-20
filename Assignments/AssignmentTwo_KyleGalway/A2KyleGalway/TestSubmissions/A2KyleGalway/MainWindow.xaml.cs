﻿using System;
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
        private PizzaShop pizzaShop;
        private PizzaItem pizzaItemTemplate;
        private Order orderTemplate;
        private Customer customerTemplate;

        // Constructor Method for MainWindow
        public MainWindow()
        {
            pizzaShop = PizzaShop.SingletonPizzaShopFactory();
            pizzaItemTemplate = PizzaShop.MakeNewPizza();
            orderTemplate = pizzaShop.MakeTrackedOrder();
            customerTemplate = PizzaShop.DefaultCustomer;
            InitializeComponent();
        }

        // Method to initialize all bindings to XAML controls
        private void InitializeWindowItems(object sender, RoutedEventArgs e)
        {
            // Function to initialize add order item controls
            void initializePlaceOrderTab()
            {
                listSideItems.ItemsSource = PizzaShop.PizzaShopListSideItems;
                listDrinkItems.ItemsSource = PizzaShop.PizzaShopListDrinkItems;

                listSize.ItemsSource = PizzaShop.ListPizzaSizes;
                listType.ItemsSource = PizzaShop.ListPizzaTypes;

                listRemoveTopping.ItemsSource = PizzaShop.ListPizzaToppings;
                listAddTopping.ItemsSource = PizzaShop.ListPizzaToppings;
            }

            // Function to initialize confirm order tab controls
            void initializeConfirmOrderTabItems()
            {
                listOpenOrders.DataContext = pizzaShop.listOrders;
            }

            // Function to initialize customer information tab controls
            void initializeCustomerInformationTabItems()
            {

                listPaymentType.ItemsSource = PizzaShop.ListPaymentTypes;
                listCustomers.DataContext = pizzaShop.listCustomers;
            }

            // Initialize all tab controls 
            initializePlaceOrderTab();
            initializeConfirmOrderTabItems();
            initializeCustomerInformationTabItems();

            // Reset all model objects for the GUI
            ResetPizzaTemplate();
            ResetOrderTemplate();
            ResetCustomerTemplate();
        }

        // Method to reset bindings for the PizzaItem model
        void ResetPizzaBindings()
        {
            lblPizzaTemplate.DataContext = pizzaItemTemplate;
        }

        // Method to reset bindings for the Order model
        void ResetOrderBindings()
        {
            listSelectedItems.DataContext = orderTemplate;
            listSelectedItems.ItemsSource = orderTemplate;

            lblOrder.DataContext = orderTemplate;
            lblCost.DataContext = orderTemplate;
            lblTax.DataContext = orderTemplate;
            lblTotalCost.DataContext = orderTemplate;
            txtAmountDue.DataContext = orderTemplate;
            listSelectedItems.DataContext = orderTemplate;
            lblOrder.DataContext = orderTemplate;
            txtAmountDue.DataContext = orderTemplate;
        }

        // Method to reset bindings for the Customer model
        void ResetCustomerBindings()
        {
            lblCustomer.DataContext = customerTemplate;
        }

        // Method to reset Pizza model by creating new PizzaItem
        void ResetPizzaTemplate()
        {
            pizzaItemTemplate = PizzaShop.MakeNewPizza();
            ResetPizzaBindings();
        }

        // Method to reset Order model by creating new Order or assigning last Order in list if Order is blank
        void ResetOrderTemplate()
        {
            Order lastOrder = pizzaShop.GetLastOrder();
            if (lastOrder != null && lastOrder.Price == 0.0M && lastOrder.statusCode == Order.OrderStatusCode.IN_PROGRESS)
            {
                orderTemplate = lastOrder;
            }
            else 
            {
                orderTemplate = pizzaShop.MakeTrackedOrder();  
                AddOrderToListOrders(orderTemplate);
            }
            ResetOrderBindings();
            ResetAllOrderInputs();
        }

        // Method to reset Customemr model by replacing customer with default
        void ResetCustomerTemplate()
        {
            customerTemplate = PizzaShop.DefaultCustomer;
            ResetCustomerBindings();
            ResetCustomerInformationInputs();
        }

        // Method to reset inputs for selected drink
        void ResetDrinkInputs()
        {
            listDrinkItems.SelectedIndex = 0;
            txtDrinkQuantity.Text = "1";
        }

        // Method to reset inputs for selected side item
        void ResetSideInputs()
        {
            listSideItems.SelectedIndex = 0;
            txtSideQuantity.Text = "1";
        }

        // Method to reset inputs for Pizza options inputs
        void ResetPizzaInputs()
        {
            listSize.SelectedIndex = 0;
            listType.SelectedIndex = 0;
            listRemoveTopping.SelectedIndex = 0;
            listAddTopping.SelectedIndex = 0;
        }

        // Method to reset add item tab inputs
        void ResetPlaceOrderInputs()
        {
            ResetPizzaInputs();
            ResetSideInputs();
            ResetDrinkInputs();
        }

        // Method to reset confirm order tab inputs
        void ResetConfirmOrderInputs()
        {
            listOpenOrders.SelectedIndex = 0;
            listSelectedItems.SelectedIndex = 0;
        }

        // Method to reset all order tab inputs
        void ResetAllOrderInputs()
        {
            ResetConfirmOrderInputs();
            ResetPlaceOrderInputs();
        }

        // Method to reset customer information tab inputs
        void ResetCustomerInformationInputs()
        {
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtCardNumber.Text = string.Empty;
            listPaymentType.SelectedIndex = 0;
        }

        // Method to reset all inputs
        void ResetAllInputs()
        {
            ResetPlaceOrderInputs();
            ResetConfirmOrderInputs();
            ResetCustomerInformationInputs();
        }

        // Method to add order to list of orders tracked by PizzaShop
        private void AddOrderToListOrders(Order order)
        {
            pizzaShop.AddOrderToListOrders(order);
        }

        // Method for adding topping to PizzaItem model
        private void AddToppingToTemplatePizza(object sender, RoutedEventArgs e)
        {
            int toppingIndex = listAddTopping.SelectedIndex;

            pizzaShop.AddToppingToPizza(pizzaItemTemplate, toppingIndex);
        }

        // Method for removing topping from PizzaItem model
        private void RemoveToppingFromTemplatePizza(object sender, RoutedEventArgs e)
        {
            int toppingIndex = listRemoveTopping.SelectedIndex;

            pizzaShop.RemoveToppingFromPizza(pizzaItemTemplate, toppingIndex);
        }

        // Method for updating PizzaItem model type
        private void UpdatePizzaTemplateType(object sender, SelectionChangedEventArgs e)
        {
            int typeIndex = listType.SelectedIndex;
            
            pizzaShop.UpdatePizzaType(pizzaItemTemplate, typeIndex);
        }

        // Method for updating PizzaItem model size
        private void UpdatePizzaTemplateSize(object sender, SelectionChangedEventArgs e)
        {
            int sizeIndex = listSize.SelectedIndex;

            pizzaShop.UpdatePizzaSize(pizzaItemTemplate, sizeIndex);
        }

        // Method for Adding PizzaItem model to Order model
        private void AddPizzaToOrderTemplate(object sender, RoutedEventArgs e)
        {
            try
            {
                pizzaShop.AddPizzaItemToOrder(orderTemplate, pizzaItemTemplate);

                lblStatus.Content = $"Added {pizzaItemTemplate}";

                ResetPizzaTemplate();
                ResetPizzaInputs();
            }
            catch (Exception)
            {
                lblStatus.Content = "Error adding pizza";
            }
        }

        // Method for adding SideItem to Order model
        private void AddSideToOrderTemplate(object sender, RoutedEventArgs e)
        {
            try
            {
                int intQuantity = Convert.ToInt32(txtSideQuantity.Text);
                int sideIndex = listSideItems.SelectedIndex;
                if (intQuantity <= 0) 
                {
                    throw new FormatException();
                }
                pizzaShop.AddSideItemToOrder(orderTemplate, sideIndex, intQuantity);
                lblStatus.Content = $"Item: {listSideItems.SelectedItem} Quantity: {intQuantity} added to order";

                ResetSideInputs();
            }
            catch (IndexOutOfRangeException)
            {
                lblStatus.Content = "Error Adding Side: Must select a drink to add to order.";
            }
            catch (FormatException)
            {
                lblStatus.Content = "Error Adding Side: Please enter a positive number as quantity.";
            }
            catch (Exception) 
            {
                lblStatus.Content = "Error Adding Side";
            }
        }

        // Method for adding DrinkItem to Order model
        private void AddDrinkToOrderTemplate(object sender, RoutedEventArgs e)
        {
            try
            {
                int intQuantity = Convert.ToInt32(txtDrinkQuantity.Text);
                int drinkIndex = listDrinkItems.SelectedIndex;
                if (intQuantity <= 0)
                {
                    throw new FormatException();
                }

                pizzaShop.AddDrinkItemToOrder(orderTemplate, drinkIndex, intQuantity);
                lblStatus.Content = $"Item: {listDrinkItems.SelectedItem} Quantity: {intQuantity} added to order";

                ResetDrinkInputs();
            }
            catch (IndexOutOfRangeException)
            {
                lblStatus.Content = "Error Adding Drink: Must select a drink to add to order.";
            }
            catch (FormatException)
            {
                lblStatus.Content = "Error Adding Drink: Please enter a positive number as quantity.";
            }
            catch (Exception)
            {
                lblStatus.Content = "Error Adding Drink.";
            }
        }

        // Method for finalizing Order to change tab
        private void FinalizeOrder(object sender, RoutedEventArgs e)
        {
            MoveToConfirmOrderTab();
        }

        // Method for creating new Order model on button click
        private void OrderAgain(object sender, RoutedEventArgs e)
        {
            PlaceNewOrder();
            MoveToPlaceOrderTab();
        }

        // Method for creating a new Order model
        private void PlaceNewOrder()
        {
            pizzaShop.AddOrderToOrderList(orderTemplate);
            ResetOrderTemplate();
            ResetOrderBindings();
        }

        // Method for changing Order model to selected order
        private void SelectOrder(object sender, RoutedEventArgs e)
        {
            string strStatus = $"Error: Cannot select Complete or Cancelled order";
            try
            {
                int orderIndex = listOpenOrders.SelectedIndex;
                Order order = pizzaShop.GetOrder(orderIndex);

                if (order.statusCode == Order.OrderStatusCode.IN_PROGRESS)
                {
                    orderTemplate = pizzaShop.listOrders[orderIndex];

                    ResetOrderBindings();

                    strStatus = $"Current order changed";
                }
                lblStatus.Content = strStatus;
            }
            catch (Exception) 
            {
                lblStatus.Content = "Error: Cannot select order";
            }
        }

        // Method for removing item from Order model
        private void RemoveItemFromOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemIndex = listSelectedItems.SelectedIndex;
                pizzaShop.RemoveItemFromOrder(orderTemplate, itemIndex);

                lblStatus.Content = $"Removed item {listSelectedItems.SelectedItem}";

                ResetConfirmOrderInputs();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                lblStatus.Content = $"Error removing item";
            }
        }

        // Method for cancelling selected Order and creating new Order model
        private void ClearOrder(object sender, RoutedEventArgs e)
        {
            pizzaShop.CancelOrder(orderTemplate);
            ResetOrderTemplate();

            lblStatus.Content = "Order cancelled.";
        }

        // Method for moving to Customer information tab on button click
        private void CheckoutOrder(object sender, RoutedEventArgs e)
        {
            MoveToCustomerInformationTab();
        }

        // Button to add customer from customer information inputs
        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim(); 
            string address = txtAddress.Text.Trim();
            string province = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string postal = txtPostalCode.Text.Trim();
            string city = txtCity.Text.Trim();
            string contactNumber = txtContactNo.Text.Trim();

            if (firstName.Length == 0 || lastName.Length == 0 || address.Length == 0 || postal.Length == 0 || contactNumber.Length == 0)
            {
                lblStatus.Content = "Error: Customer must contain required fields.";
            }
            else
            {
                pizzaShop.CreateNewCustomer(firstName, lastName, address, province, email, postal, city, contactNumber);
                lblStatus.Content = "Customer sucessfully added";
                ResetCustomerInformationInputs();
            }
        }

        // Method for changing selected Customer model
        private void SelectCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                int customerIndex = listCustomers.SelectedIndex;
                Customer customer = pizzaShop.GetCustomer(customerIndex);
                if (customer == null) 
                { 
                    throw new NullReferenceException();
                }

                customerTemplate = customer;

                ResetCustomerBindings();

                lblStatus.Content = $"Customer changed, current customer: {customerTemplate.FullName}"; 
            }
            catch (Exception) 
            {
                lblStatus.Content = "Error: Must select a customer";
            }
        }

        // Method for signing out of current customer
        private void QuitCustomer(object sender, RoutedEventArgs e)
        {
            if (customerTemplate == Customer.PlaceholderCustomer)
            {
                lblStatus.Content = "Error: Already signed out.";
            }
            else
            {
                string strFullName = customerTemplate.FullName;
                customerTemplate = Customer.PlaceholderCustomer;
                lblStatus.Content = $"Signed out from {strFullName}";
                ResetCustomerBindings();
            }
        }

        // Method for paying for order on button click
        private void PayForOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                if (orderTemplate.Count <= 0)
                {
                    throw new Exception("Error: Cannot confirm an empty order");
                }
                else if (customerTemplate == PizzaShop.DefaultCustomer)
                {
                    throw new Exception("Error: Cannot confirm without signing in");
                } 
                else if (listPaymentType.SelectedIndex != 0 && txtCardNumber.Text.Trim().Length == 0)
                {
                    throw new Exception("Error: Card payments must provide a card number");
                }

                pizzaShop.ConfirmOrder(orderTemplate);
                
                MessageBox.Show($"Thanks {customerTemplate.FirstName}!\n Order #{orderTemplate.OrderID} will be delivered in twenty minutes!", "Order confirmed");
                lblStatus.Content = $"Order #{orderTemplate.OrderID} Confirmed";

                ResetOrderTemplate();
                TabConfirm.Focus();
            }
            catch (Exception ex) 
            {
                lblStatus.Content = ex.Message;
            }
        }

        // Method for moving to Place OrderTab
        private void MoveToPlaceOrderTab()
        {
            TabOrder.Focus();

            lblStatus.Content = "Changed to add to order tab";

            ResetAllInputs();
        }

        // Method for moving to Confirm Order tab
        private void MoveToConfirmOrderTab()
        {
            TabConfirm.Focus();

            lblStatus.Content = "Changed to confirm order tab";

            ResetAllInputs();
        }

        // Method for moving to Customer Information tab
        private void MoveToCustomerInformationTab()
        {
            TabCustomerInformation.Focus();
            lblStatus.Content = "Changed to customer information tab";
            
            ResetAllInputs();
        }

        // Method for moving to Place Order tab on button click
        private void MoveToPlaceOrderTab(object sender, RoutedEventArgs e)
        {
            MoveToPlaceOrderTab();
        }

        // Method for moving to Confirm Order tab on button click
        private void MoveToConfirmOrderTab(object sender, RoutedEventArgs e)
        {
            MoveToConfirmOrderTab();
        }

        // Method for moving to Customer Information tab on button click
        private void MoveToCustomerInformationTab(object sender, RoutedEventArgs e)
        {
            MoveToCustomerInformationTab();
        }
    }
}