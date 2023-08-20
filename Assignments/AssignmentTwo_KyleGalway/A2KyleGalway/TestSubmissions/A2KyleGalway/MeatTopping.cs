using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class MeatTopping : Topping
    {
        // Set price of Meat Toppings to 2.15
        private static decimal numPrice = 2.15M;

        // Default constructor for Meat Topping
        public MeatTopping(string strName, int id): base(strName, id)
        { 
        }

        // Calculate Price of Meat Toppings
        public override decimal GetToppingPrice()
        {
            return numPrice;
        }
    }
}
