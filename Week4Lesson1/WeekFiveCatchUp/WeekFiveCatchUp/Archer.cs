using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFiveCatchUp
{
    internal class Archer : Warrior
    {
        public string bow;

        public string Bow
        {
            get { return bow; }
            set { bow = value; }
        }

        public Archer(string title, string bow): base(title)
        {
            Bow = bow;
        }

        override public void Attack()
        {
            Console.WriteLine($"{Title} is shooting their {Bow}!");
        }
    }
}
