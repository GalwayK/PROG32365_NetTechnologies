using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class VegetableTopping: Topping
    {
        public static decimal numPrice = 1.10M;

        public VegetableTopping(string strName, int id): base(strName, id)
        {  
        }

        public override decimal GetToppingPrice()
        {
            return VegetableTopping.numPrice;
        }
    }
}
