using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class ListPizzaToppings: List<Topping>
    {
        // Overriden ToString to display string of Pizza Toppings
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

        // These aren't necessary because I didn't end up needing to implement INotifyCollectionChanged 
        public new void Add(Topping topping)
        {
            base.Add(topping);
        }

        // Please pretend they do something interesting and impressive
        public new void Remove(Topping topping)
        {
            base.Remove(topping);
        }
    }
}
