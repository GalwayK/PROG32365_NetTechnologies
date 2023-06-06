using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFiveCatchUp
{
    internal class Warrior
    {
        private string title;

        public String Title
        {
            get => title;
            set => title = value;
        }

        public Warrior(string title) 
        {
            Title = title;
        }

        virtual public void Attack()
        {
            Console.WriteLine($"{Title} is attacking!");
        }
    }
}
