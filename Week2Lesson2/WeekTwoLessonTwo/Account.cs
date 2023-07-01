using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoLessonTwo
{
    internal class Account
    {
        private int _intAccountId;
        private string _strAccountName;
        private decimal _balance;

        public Account()
        {
            Balance = 0;
        }

        public Account(decimal balance)
        {
            Balance = balance;
        }

        public decimal Balance { get; set; }

        public string StrAccountName
        {
            get => _strAccountName; 
            set => _strAccountName = value;
        }

        public int IntAccountId
        { 
            get { return _intAccountId; }
            
        }

        public override string ToString() 
        {
            return $"Balance: {Balance}";
        }
    }
}
