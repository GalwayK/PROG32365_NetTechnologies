using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Lesson1
{
    public class ComissionedEmployee
    {
        private int _id;
        private string _name;
        private decimal _grossSale;
        private decimal _creditRate;

        public ComissionedEmployee(int id, string name, decimal grossSale, decimal creditRate)
        {
            Id = id;
            Name = name;
            GrossSale = grossSale;
            CreditRate = creditRate;
        }

        public virtual decimal Earning() => GrossSale * CreditRate;
        

        public override string ToString()
        {
            return $"EmployeeID: {Id} Name: {Name} Gross Sale: {GrossSale} Credit Rate: {CreditRate}";
        }

        public int Id { get { return _id; } set { _id = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public decimal GrossSale 
        { 
            get
            {
                return _grossSale;
            } 
            set 
            { 
                if (value > 0)
                {
                    _grossSale = value;
                }
                else
                {
                    throw new Exception("Gross Sale cannot be negative.");
                }
            } 
        }
        
        public decimal CreditRate 
        {
            get
            { 
                return _creditRate; 
            } 
            set 
            {
                if (value > 0)
                {
                    _creditRate = value;
                }
                else
                {
                    throw new Exception("Credit Rate cannot be negative.");
                }
            } 
        }
    }

    
}
