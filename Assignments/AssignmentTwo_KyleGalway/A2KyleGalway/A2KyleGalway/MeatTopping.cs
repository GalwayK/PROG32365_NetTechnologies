using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class MeatTopping : Topping
    {
        private static decimal numPrice = 2.15M;

        public MeatTopping(string strName, int id): base(strName, id)
        { 
        }

        public override decimal GetToppingPrice()
        {
            return numPrice;
        }
    }
}
