using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace A2KyleGalway
{
    internal class MiscItem: OrderItem
    {
        // Lists for Side and Drink Items
        public static List<MiscItem> listDrinkItems = CreateListDrinkItems();
        public static List<MiscItem> listOtherItems = CreateListOtherItems();

        // Constructor creating MiscItems
        public MiscItem(int itemId, string strName, decimal numPrice) 
        { 
            this.StrName = strName;
            this.NumPrice = numPrice;
            this.ItemId = itemId;
        }

        // Getters and Setters for MiscItem properties
        public int ItemId
        {
            get;
            set;
        }

        public decimal NumPrice
        {
            get;
            set;
        }

        public string StrName
        {
            get;
            set;
        }
        
        // Method to calculate price of item
        public override decimal CalculatePrice()
        {
            return NumPrice;
        }

        // Overridden ToString of item
        public override string ToString() 
        {
            return $"{this.StrName}: {this.NumPrice:C}";
        }

        // Method to create list of drink items in Pizza Shop
        private static List<MiscItem> CreateListDrinkItems()
        {
            List<MiscItem> listDrinks = new List<MiscItem>();

            decimal priceSoda = 2.99M;
            decimal priceWater = 1.99M;

            List<string> arrSoda = new List<string>() {"Coke", "Diet Coke", "Iced Tea", "Ginger Ale",
                "Sprite", "Root Beer"};

            listDrinks.Add(new MiscItem(listDrinks.Count + 1, "Water", priceWater));

            Action<string> AddDrinksToMenu = (strDrink) =>
            {
                listDrinks.Add(new MiscItem(listDrinks.Count + 1, strDrink, priceSoda));
            };

            arrSoda.ForEach(AddDrinksToMenu);

            return listDrinks;
        }

        // Method to create list of side items for Pizza Shop
        private static List<MiscItem> CreateListOtherItems()
        {
            List<MiscItem> listOthers = new List<MiscItem>();

            void AddItemToList(string strName, decimal numPrice)
            {
                listOthers.Add(new MiscItem(listOthers.Count + 1, strName, numPrice));
            }

            AddItemToList("Chicken Wings (5)", 6.99M);
            AddItemToList("Chicken Wings (10)", 11.99M);
            AddItemToList("Chicken Wings (20)", 22.99M);
            AddItemToList("Poutine", 5.29M);
            AddItemToList("Onion Rings (small)", 3.99M);
            AddItemToList("Onion Rings (medium)", 5.99M);
            AddItemToList("Cheesy Garlic Bread", 6.69M);
            AddItemToList("Garlic Dip", 0.50M);
            AddItemToList("BBQ Dip", 0.50M);
            AddItemToList("Sour Cream Dip", 0.50M);

            return listOthers;
        }
    }
}
