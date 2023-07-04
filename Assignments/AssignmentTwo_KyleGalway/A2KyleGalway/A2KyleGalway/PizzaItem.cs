using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class PizzaItem : OrderItem
    {
        private ListPizzaToppings listToppings;
        private PizzaSize pizzaSize;
        private PizzaType pizzaType;

        public PizzaItem(ListPizzaToppings listToppings, PizzaSize pizzaSize, PizzaType pizzaType)
        {
            this.listToppings = listToppings;
            this.pizzaSize = pizzaSize;
            this.pizzaType = pizzaType;
        }

        public override string ToString()
        {
            return $"{pizzaSize.strSize} {pizzaType.strType} with {listToppings}: {CalculatePrice():C}.";
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

        public static List<Topping> listAvailableToppings = CreateListAvailableToppings();
        public static List<PizzaSize> listAvailablePizzaSizes = CreateListAvailablePizzaSizes();
        public static List<PizzaType> listAvailablePizzaTypes = CreateListAvailablePizzaTypes();

        static string[] arrStrToppings = {};
        static string[] arrStrPizzaSizes = { "Small", "Medium", "Large", "Extra-large" };
        static string[] arrStrPizzaTypes = { };

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
                List<string> listVegetableToppings = new List<string>(){ "Pineapple", "Extra Cheese", 
                    "Dried Shrimp (why)", "Mushrooms", "Anchovies", "Sun Dried Tomatoes", "Daikon", "Spinach", 
                    "Roasted Garlic", "Jalapeno"};

                Action<string> addVegToppingToList = (strTopping) =>
                {
                    addToppingToList(strTopping, false);
                };

                listVegetableToppings.ForEach(addVegToppingToList);
            }

            void addMeatToppings()
            {
                List<string> listMeatToppings = new List<string>() {"Ground Beef", "Shredded Chicken", 
                    "Grilled Chicken", "Pepperoni", "Ham", "Bacon", "Steak"};

                Action<string> addMeatToppingToList = (strTopping) =>
                {
                    addToppingToList(strTopping, true);
                };

                listMeatToppings.ForEach(addMeatToppingToList);
            }

            addVegetableToppings();
            addMeatToppings();

            return listAvailableToppings;
        }

        private static List<PizzaSize> CreateListAvailablePizzaSizes()
        {
            List<PizzaSize> listAvailablePizzaSizes = new List<PizzaSize>();

            listAvailablePizzaSizes.Add(new PizzaSize(arrStrPizzaSizes[0], 7.00M));
            listAvailablePizzaSizes.Add(new PizzaSize(arrStrPizzaSizes[1], 10.00M));
            listAvailablePizzaSizes.Add(new PizzaSize(arrStrPizzaSizes[2], 13.00M));
            listAvailablePizzaSizes.Add(new PizzaSize(arrStrPizzaSizes[3], 15.00M));

            return listAvailablePizzaSizes;
        }

        private static List<PizzaType> CreateListAvailablePizzaTypes()
        {
            List<PizzaType> listAvailablePizzaTypes = new List<PizzaType>();

            listAvailablePizzaTypes.Add(new PizzaType("Thin Crust", 0.0M));
            listAvailablePizzaTypes.Add(new PizzaType("Normal Crust", 0.0M));
            listAvailablePizzaTypes.Add(new PizzaType("Deep Dish", 0.0M));

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
        }

        public struct PizzaType
        {
            /* 
             * In this implementation I have included a numTypePrice field, to account for any difference of price 
             * between pizza types. Despite this, in the assignment description there is no difference in price between
             * pizza types. As a result, this field goes unused and is not required in the current version of the app.
             * 
             * Having worked as the head cook in a pizzeria which specialized for deep dish pizzasand there is usually 
             * a difference in price between thin crust and deep dish pies. In the event that the business 
             * owner who has contracted my services to create this app eventually decides to implement price 
             * difference, this field could be used to implement it without reworking the application majorly. 
             * */

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
        }


    }
}

/*
 * To do: Create enums for sizes, types, and toppings. 
 * 
 * 
*/ 