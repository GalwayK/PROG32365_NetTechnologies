using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal abstract class OrderItem
    {
        private string _strName;
        private decimal _numPrice;

        public abstract decimal CalculatePrice();

        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public decimal NumPrice
        {
            get => _numPrice;
            set => _numPrice = value;   
        }


    }
}
