using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class PizzaItem : OrderItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ListPizzaToppings listToppings;
        private PizzaSize pizzaSize;
        private PizzaType pizzaType;

        public PizzaItem()
        {
            this.listToppings = new ListPizzaToppings();
            this.pizzaSize = PizzaItem.listAvailablePizzaSizes[0];
            this.pizzaType = PizzaItem.listAvailablePizzaTypes[0];
        }

        public PizzaItem(PizzaSize pizzaSize, PizzaType pizzaType, ListPizzaToppings listToppings = null)
        {
            if (listToppings == null)
            {
                listToppings = new ListPizzaToppings();
            }
            this.listToppings = listToppings;
            this.pizzaSize = pizzaSize;
            this.pizzaType = pizzaType;
        }

        public PizzaItem AddTopping(Topping topping)
        {
            if (!this.listToppings.Contains(topping))
            {
                this.listToppings.Add(topping);
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToString)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaString)));

            }
            Console.WriteLine($"Updated: {this}");
            return this;
        }

        public PizzaItem RemoveTopping(Topping topping)
        {
            if (this.listToppings.Contains(topping))
            {
                this.listToppings.Remove(topping);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToString)));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaString)));
            }
            return this;
        }

        public PizzaItem ChangeSize(PizzaSize size)
        {
            this.pizzaSize = size;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaString)));
            return this;
        }

        public PizzaItem ChangeType(PizzaType type)
        {
            this.pizzaType = type;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaString)));
            return this;
        }

        public string PizzaString
        {
            get => this.ToString();
        }

        public override string ToString()
        {
            return $"{pizzaSize.strSize} {pizzaType.strType} with {listToppings}: {CalculatePrice():C}";
        }

        public override decimal CalculatePrice()
        {
            decimal calcToppingPrice()
            {
                decimal priceToppings = 0.0M;

                foreach(Topping topping in listToppings)
                {
                    priceToppings += topping.GetToppingPrice();
                }
                return priceToppings;
            }

            decimal totalPrice = calcToppingPrice() + pizzaSize.numSizePrice + pizzaType.numTypePrice;

            return totalPrice;
        }

        static List<string> listStrVegetableToppings = new List<string>() { "Pineapple", "Extra Cheese",
                    "Dried Shrimp (why)", "Mushrooms", "Sun Dried Tomatoes", "Daikon", "Spinach",
                    "Roasted Garlic", "Jalapeno" };

        static List<string> listStrMeatToppings = new List<string>() {"Ground Beef", "Shredded Chicken",
                    "Grilled Chicken", "Pepperoni", "Ham", "Bacon", "Steak", "Anchovies"};

        static List<string> listStrPizzaSizes = new List<string>() { "Small", "Medium", "Large", "Extra-large" };

        static List<string> listStrPizzaTypes = new List<string>() { "Thin Crust", "Normal Crust", "Deep Dish" };

        public static List<Topping> listAvailableToppings = CreateListAvailableToppings();
        public static List<PizzaType> listAvailablePizzaTypes = CreateListAvailablePizzaTypes();
        public static List<PizzaSize> listAvailablePizzaSizes = CreateListAvailablePizzaSizes();

        private static List<Topping> CreateListAvailableToppings()
        {
            List<Topping> listAvailableToppings = new List<Topping>();

            Action<string, bool> addToppingToList = (strTopping, isMeat) =>
            {
                int toppingId = listAvailableToppings.Count + 1;
                if (isMeat)
                {
                    listAvailableToppings.Add(new MeatTopping(strTopping, toppingId));
                }
                else
                {
                    listAvailableToppings.Add(new VegetableTopping(strTopping, toppingId));
                }
            };

            void addVegetableToppings()
            {
                Action<string> addVegToppingToList = (strTopping) =>
                {
                    addToppingToList(strTopping, false);
                };

                PizzaItem.listStrVegetableToppings.ForEach(addVegToppingToList);
            }

            void addMeatToppings()
            { 
                Action<string> addMeatToppingToList = (strTopping) =>
                {
                    addToppingToList(strTopping, true);
                };

                listStrMeatToppings.ForEach(addMeatToppingToList);
            }

            addVegetableToppings();
            addMeatToppings();

            return listAvailableToppings;
        }

        private static List<PizzaSize> CreateListAvailablePizzaSizes()
        {
            List<PizzaSize> listAvailablePizzaSizes = new List<PizzaSize>();

            listAvailablePizzaSizes.Add(new PizzaSize(listStrPizzaSizes[0], 7.00M));
            listAvailablePizzaSizes.Add(new PizzaSize(listStrPizzaSizes[1], 10.00M));
            listAvailablePizzaSizes.Add(new PizzaSize(listStrPizzaSizes[2], 13.00M));
            listAvailablePizzaSizes.Add(new PizzaSize(listStrPizzaSizes[3], 15.00M));

            return listAvailablePizzaSizes;
        }

        private static List<PizzaType> CreateListAvailablePizzaTypes()
        {
            List<PizzaType> listAvailablePizzaTypes = new List<PizzaType>();

            foreach(string strPizzaType in PizzaItem.listStrPizzaTypes)
            {
                listAvailablePizzaTypes.Add(new PizzaType(strPizzaType, 0.0M));
            }

            return listAvailablePizzaTypes;
        }

        public struct PizzaSize
        { 
            public string strSize;
            public decimal numSizePrice;
            public int id;

            private static int numPizzaSizes = 0;

            public PizzaSize(string strSize, decimal numPrice)
            {
                this.strSize = strSize;
                this.numSizePrice = numPrice;
                this.id = ++numPizzaSizes;
            }

            public override string ToString()
            {
                return $"#{this.id}: {this.strSize} {this.numSizePrice:C}";
            }
        }

        public struct PizzaType
        {
            /* 
            * In this implementation I have included a numTypePrice field, to account for any difference of price 
            * between pizza types. Despite this, in the assignment description there is no difference in price between
            * pizza types. As a result, this field goes unused and is not required in the current version of the app.
            * 
            * In the event that the business owner who has contracted my services to create this app eventually 
            * decides to add a price difference, this field could be used to implement it without reworking the
            * application majorly. 
            */

            public string strType;
            public decimal numTypePrice;
            public int id;

            private static int numPizzaTypes = 0;

            public PizzaType(string strType, decimal numTypePrice)
            {
                this.strType = strType;
                this.numTypePrice = numTypePrice;
                this.id = ++numPizzaTypes;
            }

            public override string ToString()
            {
                return $"#{this.id}: {this.strType}";
            }
        }


    }
}