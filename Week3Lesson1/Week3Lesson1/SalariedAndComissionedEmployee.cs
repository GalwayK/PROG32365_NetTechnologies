using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Lesson1
{
    internal class SalariedAndComissionedEmployee : ComissionedEmployee
    {
        private decimal _salary;
        public SalariedAndComissionedEmployee(int id, string name, decimal grossSale, decimal creditRate, decimal salary) : base(id, name, grossSale, creditRate)
        {
            _salary = salary;
        }

        public decimal Salary
        {
            get => _salary;
            
            set 
            { 
                _salary = value; 
            } 
        }

        public new string ToString()
        {
            return $"{base.ToString()} Salary: {Salary}";
        }

        public override decimal Earning() => Salary * base.Earning();
        
    }
}
