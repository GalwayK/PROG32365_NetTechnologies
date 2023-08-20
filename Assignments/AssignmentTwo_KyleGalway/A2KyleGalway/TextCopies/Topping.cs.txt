using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal abstract class Topping
    {
        // Abstract Topping class to differentiate between Meat and Vegetable Toppings
        public string strName;
        public int id;

        // Require all Toppings to have a field to calculate price
        public abstract decimal GetToppingPrice();

        // Parent constructor for Pizza Toppings
        public Topping(string strName, int id)
        {
            this.strName = strName;
            this.id = id;
        }

        // Overridden ToString()
        public override string ToString()
        {
            return $"#{this.id}: {this.strName}";
        }
    }
}
