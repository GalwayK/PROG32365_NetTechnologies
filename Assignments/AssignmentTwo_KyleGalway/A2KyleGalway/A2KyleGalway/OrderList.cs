using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2KyleGalway
{
    internal class OrderList: List<Order>
    {
        public new void Add(Order order)
        {
            base.Add(order);
        }

        public new void Remove(Order order)
        {
            base.Remove(order);
        }

        public new void RemoveAt(int orderIndex)
        {
            base.RemoveAt(orderIndex);
        }
    }
}
