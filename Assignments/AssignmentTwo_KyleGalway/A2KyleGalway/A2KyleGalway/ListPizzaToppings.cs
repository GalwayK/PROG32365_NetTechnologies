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
            string strToppings = "no toppings";

            if (this.Count > 0) 
            {
                strToppings = "";
                for (int i = 0; i < this.Count - 1; i++)
                {
                    strToppings += $"{this[i].strName}, ";
                }
                strToppings += $"{this.Last<Topping>().strName}";

            }
            return strToppings;
        }

        public new void Add(Topping topping)
        {
            base.Add(topping);
        }

        public new void Remove(Topping topping)
        {
            base.Remove(topping);
        }
    }
}
