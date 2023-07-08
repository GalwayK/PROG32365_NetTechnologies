using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class CustomerList: List<Customer>
    {
        public new void Add(Customer customer)
        {
            base.Add(customer);
        }
    }
}
