using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lesson1
{
    internal class InvestmentCalculator
    {
        private decimal monthlyInvestment;
        private decimal monthlyInterestRate;
        private int numYears;

        public InvestmentCalculator(decimal monthlyInvestment, decimal monthlyInterestRate)
        {
            this.MonthlyInvestment = monthlyInvestment;
            this.MonthlyInterestRate = monthlyInterestRate;
        }

        public decimal CalculateInvestment(int numberMonths) 
        {
            decimal CalcInvestment(int numberMonths)
            {
                decimal futureValue = 0.0M;
                if (numberMonths > 0)
                {
                    futureValue = (CalcInvestment(numberMonths - 1) + this.MonthlyInvestment) * (1 + this.MonthlyInterestRate);
                }
                return futureValue;
            }

            decimal returnedValue = CalcInvestment((int)numberMonths);
            return returnedValue;
        }

        public decimal MonthlyInvestment 
        { 
            get 
            {  
                return monthlyInvestment; 
            } 
            set 
            {  
                monthlyInvestment = value; 
            } 
        }

        public decimal MonthlyInterestRate
        {
            get 
            {
                return this.monthlyInterestRate;
            }
            set
            {
                this.monthlyInterestRate = value;
            }
        }
    }
}
