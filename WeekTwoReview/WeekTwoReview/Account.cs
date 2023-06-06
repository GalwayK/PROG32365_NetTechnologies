using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoReview
{
    public class BankAccount
    {
        private static int numAccounts = 0;
        private decimal _balance;
        private List<Decimal> _movements = new List<decimal>();
        private DateTime _creationDate = DateTime.UtcNow;

        public BankAccount()
        {
            Balance = 0;
            AssignId();
        }

        public BankAccount(decimal balance)
        {
            Balance = balance;
            AssignId();
        }

        private void AssignId() => this.Id = ++BankAccount.numAccounts;

        public int Id
        {
            get;
            private set;
        }

        public decimal Balance 
        {
            get { return this._balance; }
            private set { this._balance = value; }
        }

        public TimeSpan AccountAge
        {
            get  => _creationDate.Subtract(DateTime.UtcNow);
        }

        public List<Decimal> Movements
        {
            get => this._movements;
            set => this._movements = value;
        }

        public BankAccount PrintMovements()
        {
            void PrintMovement(int numMovements)
            {
                if (numMovements > 0)
                {
                    PrintMovement(numMovements - 1);
                }
                Console.WriteLine($"Movement {numMovements + 1}. {Movements[numMovements].ToString("C")}");
            }
            Console.WriteLine($"Printing Movements for Account: {this.Id}");
            PrintMovement(Movements.Count - 1);

            return this;
        }

        public BankAccount Deposit(decimal deposit)
        {
            if (deposit > 0)
            {
                Balance += deposit;
                this.Movements.Add(deposit);
            }
            return this;
        }

        public BankAccount Withdraw(decimal withdrawal)
        {
            if (withdrawal > 0 && withdrawal <= this.Balance)
            {
                this.Balance -= withdrawal;
                this.Movements.Add(0.0M - withdrawal);
            }
            return this;
        }

        public string ToString()
        {
            return $"Account {this.Id} Balance: {this.Balance}";
        }

        public static BankAccount operator + (BankAccount accountOne, BankAccount accountTwo)
        {
            decimal amount = accountOne.Balance + accountTwo.Balance;
            BankAccount bankAccount = new BankAccount(amount);
            return bankAccount;
        }

        public static BankAccount operator + (BankAccount account, decimal deposit)
        {
            return account.Deposit(deposit);
        }

        public static BankAccount operator - (BankAccount accountOne, BankAccount accountTwo) 
        {
            decimal amount = accountOne.Balance - accountTwo.Balance;
            BankAccount bankAccount = new BankAccount(amount);
            return bankAccount;
        }

        public static BankAccount operator - (BankAccount account, decimal withdrawal)
        {
            return account.Withdraw(withdrawal);
        }

        public static BankAccount operator * (BankAccount accountOne, BankAccount accountTwo)
        {
            decimal amount = accountOne.Balance * accountTwo.Balance;
            BankAccount bankAccount = new BankAccount(amount);
            return bankAccount;
        }

        public override bool Equals(Object account)
        {
            return account == this;
        }

        public static BankAccount operator / (BankAccount accountOne, BankAccount accountTwo)
        {
            decimal amount = accountOne.Balance / accountTwo.Balance;
            BankAccount bankAccount = new BankAccount(amount);
            return bankAccount;
        }

        public static bool operator == (BankAccount accountOne, BankAccount accountTwo)
        {
            return accountOne.Balance == accountTwo.Balance;
        }

        public static bool operator != (BankAccount accountOne, BankAccount accountTwo) 
        { 
            return accountOne.Balance != accountTwo.Balance;
        }

        public static bool operator > (BankAccount accountOne, BankAccount accountTwo)
        {
            return accountOne.Balance > accountTwo.Balance; 
        }

        public static bool operator < (BankAccount accountOne, BankAccount accountTwo)
        {
            return accountOne.Balance < accountTwo.Balance;
        }

        public static bool operator >= (BankAccount accountOne, BankAccount accountTwo)
        {
            return accountOne.Balance >= accountTwo.Balance;
        }

        public static bool operator <= (BankAccount accountOne, BankAccount accountTwo)
        {
            return accountOne.Balance <= accountTwo.Balance;
        }

    }
}
