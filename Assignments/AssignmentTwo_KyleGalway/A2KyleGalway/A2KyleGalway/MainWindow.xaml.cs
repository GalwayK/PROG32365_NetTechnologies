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
        private PizzaShop pizzaShop;
        private PizzaItem pizzaItemTemplate;
        private Order orderTemplate;
        private Customer customerTemplate;

        public MainWindow()
        {
            pizzaShop = PizzaShop.SingletonPizzaShopFactory();
            pizzaItemTemplate = PizzaShop.MakeNewPizza();
            orderTemplate = pizzaShop.MakeTrackedOrder();
            customerTemplate = PizzaShop.DefaultCustomer;
            InitializeComponent();
        }

        private void InitializeWindowItems(object sender, RoutedEventArgs e)
        {
            void initializePlaceOrderTab()
            {
                listSideItems.ItemsSource = PizzaShop.PizzaShopListSideItems;
                listDrinkItems.ItemsSource = PizzaShop.PizzaShopListDrinkItems;

                listSize.ItemsSource = PizzaShop.ListPizzaSizes;
                listType.ItemsSource = PizzaShop.ListPizzaTypes;

                listRemoveTopping.ItemsSource = PizzaShop.ListPizzaToppings;
                listAddTopping.ItemsSource = PizzaShop.ListPizzaToppings;
            }

            void initializeConfirmOrderTabItems()
            {
                listOpenOrders.DataContext = pizzaShop.listOrders;
            }

            void initializeCustomerInformationTabItems()
            {

                listPaymentType.ItemsSource = PizzaShop.ListPaymentTypes;
                listCustomers.DataContext = pizzaShop.customerList;
            }

            initializePlaceOrderTab();
            initializeConfirmOrderTabItems();
            initializeCustomerInformationTabItems();

            ResetPizzaTemplate();
            ResetOrderTemplate();
            ResetCustomerTemplate();
        }

        void ResetPizzaBindings()
        {
            lblPizzaTemplate.DataContext = pizzaItemTemplate;
        }

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

        void ResetCustomerBindings()
        {
            lblCustomer.DataContext = customerTemplate;
        }
        void ResetPizzaTemplate()
        {
            pizzaItemTemplate = PizzaShop.MakeNewPizza();
            ResetPizzaBindings();
        }

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

        void ResetCustomerTemplate()
        {
            customerTemplate = PizzaShop.DefaultCustomer;
            ResetCustomerBindings();
            ResetCustomerInformationInputs();
        }

        void ResetDrinkInputs()
        {
            listDrinkItems.SelectedIndex = 0;
            txtDrinkQuantity.Text = "1";
        }

        void ResetSideInputs()
        {
            listSideItems.SelectedIndex = 0;
            txtSideQuantity.Text = "1";
        }

        void ResetPizzaInputs()
        {
            listSize.SelectedIndex = 0;
            listType.SelectedIndex = 0;
            listRemoveTopping.SelectedIndex = 0;
            listAddTopping.SelectedIndex = 0;
        }

        void ResetPlaceOrderInputs()
        {
            ResetPizzaInputs();
            ResetSideInputs();
            ResetDrinkInputs();
        }

        void ResetConfirmOrderInputs()
        {
            listOpenOrders.SelectedIndex = 0;
            listSelectedItems.SelectedIndex = 0;
        }

        void ResetAllOrderInputs()
        {
            ResetConfirmOrderInputs();
            ResetPlaceOrderInputs();
        }

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

        void ResetAllInputs()
        {
            ResetPlaceOrderInputs();
            ResetConfirmOrderInputs();
            ResetCustomerInformationInputs();
        }

        private void AddOrderToListOrders(Order order)
        {
            pizzaShop.AddOrderToListOrders(order);
        }

        private void AddToppingToTemplatePizza(object sender, RoutedEventArgs e)
        {
            int toppingIndex = listAddTopping.SelectedIndex;

            pizzaShop.AddToppingToPizza(pizzaItemTemplate, toppingIndex);
        }

        private void RemoveToppingFromTemplatePizza(object sender, RoutedEventArgs e)
        {
            int toppingIndex = listRemoveTopping.SelectedIndex;

            pizzaShop.RemoveToppingFromPizza(pizzaItemTemplate, toppingIndex);
        }

        private void UpdatePizzaTemplateType(object sender, SelectionChangedEventArgs e)
        {
            int typeIndex = listType.SelectedIndex;
            
            pizzaShop.UpdatePizzaType(pizzaItemTemplate, typeIndex);
        }

        private void UpdatePizzaTemplateSize(object sender, SelectionChangedEventArgs e)
        {
            int sizeIndex = listSize.SelectedIndex;

            pizzaShop.UpdatePizzaSize(pizzaItemTemplate, sizeIndex);
        }

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

        private void FinalizeOrder(object sender, RoutedEventArgs e)
        {
            MoveToConfirmOrderTab();
        }

        private void OrderAgain(object sender, RoutedEventArgs e)
        {
            PlaceNewOrder();
            MoveToPlaceOrderTab();
        }

        private void PlaceNewOrder()
        {
            pizzaShop.AddOrderToOrderList(orderTemplate);
            ResetOrderTemplate();
            ResetOrderBindings();
        }

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

        private void ClearOrder(object sender, RoutedEventArgs e)
        {
            pizzaShop.CancelOrder(orderTemplate);
            ResetOrderTemplate();

            lblStatus.Content = "Order cancelled.";
        }

        private void CheckoutOrder(object sender, RoutedEventArgs e)
        {
            MoveToCustomerInformationTab();
        }

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

        private void MoveToPlaceOrderTab()
        {
            TabOrder.Focus();

            lblStatus.Content = "Changed to add to order tab";

            ResetAllInputs();
        }

        private void MoveToConfirmOrderTab()
        {
            TabConfirm.Focus();

            lblStatus.Content = "Changed to confirm order tab";

            ResetAllInputs();
        }

        private void MoveToCustomerInformationTab()
        {
            TabCustomerInformation.Focus();
            lblStatus.Content = "Changed to customer information tab";
            
            ResetAllInputs();
        }

        private void MoveToPlaceOrderTab(object sender, RoutedEventArgs e)
        {
            MoveToPlaceOrderTab();
        }

        private void MoveToConfirmOrderTab(object sender, RoutedEventArgs e)
        {
            MoveToConfirmOrderTab();
        }

        private void MoveToCustomerInformationTab(object sender, RoutedEventArgs e)
        {
            MoveToCustomerInformationTab();
        }
    }
}