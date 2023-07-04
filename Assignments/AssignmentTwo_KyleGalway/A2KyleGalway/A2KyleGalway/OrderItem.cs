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

        public abstract decimal CalculatePrice();

        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }

    }
}
