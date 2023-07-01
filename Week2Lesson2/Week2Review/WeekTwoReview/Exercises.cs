using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoReview
{
    public class Exercises
    {
        private Exercises() { }

        public static void ExerciseTicTacToe()
        {
            TicTacToe game = new TicTacToe();
            // game.PrintBoard();
            game.PlayGame();
        }

        public static void ExerciseIntegerSets()
        {
            IntegerSet integerSetOne = new IntegerSet();
            Console.WriteLine("Set One");
            integerSetOne.PrintSet();

            Console.WriteLine("Set Two");
            IntegerSet integerSetTwo = new IntegerSet();
            integerSetTwo.PrintSet();

            Console.WriteLine("Union Set");
            IntegerSet unionSet = integerSetOne.Union(integerSetTwo);
            Console.WriteLine(unionSet.PrintSet());

            Console.WriteLine("Intersect Set");
            IntegerSet intersectSet = integerSetOne.Intersection(integerSetTwo);
            Console.WriteLine(intersectSet.PrintSet());
        }

        public static void ExerciseInvoice()
        {
            string part = "Wrench";
            string type = "Ratchet";
            int quantity = 3;
            decimal price = 20.50M;
            Invoice invoice = Invoice.CreateInvoice(part, type, quantity, price);
            Console.WriteLine(invoice);
        }

        public static void ExerciseBankAccounts()
        {
            BankAccount accountOne = new BankAccount();
            BankAccount accountTwo = new BankAccount(100);
            accountOne.Deposit(10.0M);
            accountOne.PrintMovements();
            accountOne.Withdraw(5.0M);
            accountOne.PrintMovements();

            BankAccount subtractAccount = accountTwo - accountOne;
            Console.WriteLine("Subtract: " + subtractAccount.ToString());

            BankAccount addAccount = accountOne + accountTwo;
            Console.WriteLine("Add: " + addAccount.ToString());

            BankAccount divideAccount = accountTwo / accountOne;
            Console.WriteLine("Divide: " + divideAccount.ToString());

            BankAccount multiplyAccount = accountOne * accountTwo;
            Console.WriteLine("Multiply: " + multiplyAccount.ToString());

            accountOne.Deposit(95.0M);

            Console.WriteLine($"Account One == Account Two: {accountOne == accountTwo}");

            Console.WriteLine($"Account One > Account Two: {accountOne > accountTwo}");

            Console.WriteLine($"Account One < Account Two: {accountOne < accountTwo}");

            Console.WriteLine($"Account One >= Account Two: {accountOne >= accountTwo}");

            Console.WriteLine($"Account One <= Account Two: {accountOne <= accountTwo}");

            BankAccount copyAccount = accountOne;

            Console.WriteLine($"Account One Copy Of Account Two: {accountOne .Equals(accountTwo)}");

            Console.WriteLine($"Account One Copy Of Copy Account: {accountOne.Equals(copyAccount)}");

            Console.WriteLine($"Account {accountOne.Id} is {accountOne.AccountAge.Days} days old.");

            accountOne = accountTwo + 500.00M - 200M;
            accountOne.PrintMovements();
        }

    }
}
