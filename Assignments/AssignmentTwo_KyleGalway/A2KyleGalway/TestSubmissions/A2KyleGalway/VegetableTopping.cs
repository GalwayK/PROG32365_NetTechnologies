using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class VegetableTopping: Topping
    {
        // Price of Vegetable Topping Set to 1.10$
        public static decimal numPrice = 1.10M;

        // Constructor for Vegetable Topping
        public VegetableTopping(string strName, int id): base(strName, id)
        {  
        }

        // Calculate Price of Topping
        public override decimal GetToppingPrice()
        {
            return VegetableTopping.numPrice;
        }
    }
}
