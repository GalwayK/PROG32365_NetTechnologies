using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class MiscItem: OrderItem
    {
        private decimal _numPrice;

        public decimal NumPrice
        {
            get => _numPrice;
            set => _numPrice = value;
        }

        public override decimal CalculatePrice()
        {
            return NumPrice;
        }
    }
}
