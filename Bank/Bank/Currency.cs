using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Currency
    {
        private FullName _ownerName;
        private string _strType = "";
        private decimal _decValue = 0.0M;
        private double _dblWeight = 0.0;

        public Currency(string strType, decimal decValue, double dblWeight, string firstName = "John", string lastName = "Doe")
        {
            _strType = strType;
            _decValue = decValue;
            _dblWeight = dblWeight;
            _ownerName = new FullName(firstName, lastName);
        }

        public double DblWeight
        { 
            get 
            { 
                return _dblWeight; 
            } 
        }

        public string OwnerName
        {
            get => _ownerName.CompleteName;
        }

        public string StrType
        { 
            get 
            { 
                return _strType; 
            } 
        }

        public Currency AddValueToAccount(params decimal[] arrDecValue)
        {
            foreach (decimal decValue in arrDecValue) 
            {
                DecValue += decValue;
            }
            return this;
        }

        public decimal DecValue
        {
            get => _decValue;

            set => _decValue = value;
        }

        public void SubtractValue(ref decimal decInput, out decimal decOutput)
        {
            decOutput = this.DecValue - decInput;
            decInput = 0.0M;
        }

        public static Currency operator + (Currency curOne, Currency curTwo)
        {
            decimal curThreeValue = (curOne.DecValue * Convert.ToDecimal(curOne.DblWeight)) +
                (curTwo.DecValue * Convert.ToDecimal(curTwo.DblWeight));

            Currency curThree = new Currency(curOne.StrType, curThreeValue, curOne.DblWeight);
            return curThree;
        }

        public static Currency operator - (Currency curOne, Currency curTwo)
        {
            decimal curThreeValue = (curOne.DecValue * Convert.ToDecimal(curOne.DblWeight)) - 
                (curTwo.DecValue * Convert.ToDecimal(curTwo.DblWeight));
            Currency curThree = new Currency(curOne.StrType, curThreeValue, curOne.DblWeight);

            return curThree;
        }
    }
}
