using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal abstract class Topping
    {
        public string strName;
        public int id;

        public abstract decimal GetToppingPrice();

        public Topping(string strName, int id)
        {
            this.strName = strName;
            this.id = id;
        }
    }
}
