using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal abstract class OrderItem
    {
        // All children must be able to calculate their price.
        public abstract decimal CalculatePrice();

        // All children must override ToString.
        public abstract override string ToString();
    }
}
