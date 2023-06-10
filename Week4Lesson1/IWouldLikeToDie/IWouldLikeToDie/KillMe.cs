using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWouldLikeToDie
{
    internal class KillMe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public KillMe(int id, string name, string city, string phone)
        {
            Id = id;
            Name = name;
            City = city;
            Phone = phone;
        }
    }
}
