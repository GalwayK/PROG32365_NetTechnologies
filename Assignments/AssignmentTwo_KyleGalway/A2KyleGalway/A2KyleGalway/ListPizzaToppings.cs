using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class ListPizzaToppings: List<Topping>
    {
        public override string ToString()
        {
            string strToppings = "";

            for (int i = 0; i < this.Count - 2; i++)
            {
                strToppings += $"{this[i].strName}, ";
            }
            strToppings += $"{this.Last<Topping>().strName}";

            return strToppings;;
        }
    }
}
