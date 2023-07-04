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
        public MainWindow()
        {
            InitializeComponent();

            foreach(Topping topping in PizzaItem.listAvailableToppings)
            {
                Console.WriteLine($"Topping #{topping.id}: {topping.strName} {topping.GetToppingPrice():C}");
            }

            foreach(PizzaItem.PizzaType pizzaType in PizzaItem.listAvailablePizzaTypes)
            {
                Console.WriteLine($"Pizza Type #{pizzaType.id}: {pizzaType.strType} {pizzaType.numTypePrice:C}");
            }

            foreach (PizzaItem.PizzaSize pizzaSize in PizzaItem.listAvailablePizzaSizes)
            {
                Console.WriteLine($"Pizza Type #{pizzaSize.id}: {pizzaSize.strSize} {pizzaSize.numSizePrice:C}");
            }

            ListPizzaToppings pizzaToppings = new ListPizzaToppings()
            { PizzaItem.listAvailableToppings[0] };

            PizzaItem[] listPizzas = { new PizzaItem(pizzaToppings, PizzaItem.listAvailablePizzaSizes[0], PizzaItem.listAvailablePizzaTypes[0])};

            Console.WriteLine(listPizzas[0]);
        }
    }
}
