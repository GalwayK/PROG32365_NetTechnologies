using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lesson1
{
    internal class Exercises
    {

        public static void PrintDiscount()
        {
            Console.Write("Hello! Please enter the subtotal: ");
 
            decimal? decSubtotal = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Please enter your discount percent: ");
            int? intDiscount = Convert.ToInt32(Console.ReadLine());

            if (decSubtotal != null || intDiscount != null)
            {
                decimal decDiscount = (decimal) (decSubtotal * intDiscount / 100);
                decimal decTotal = (decimal) (decSubtotal - decDiscount);
                Console.WriteLine($"Discounted Amount: {decDiscount.ToString("C")}\nTotal: {decTotal.ToString("C")}");
            }
            else
            {
                Console.WriteLine("There is an error with your entry, please try again!");
            } 
        }

        public static void RunStore()
        {
            Console.Write("Greetings, please enter your customer type, R or C: ");
            string? strType = $"{Console.ReadLine().ElementAt(0)}";
            Console.Write("Enter subtotal: ");
            decimal? decSubtotal = Convert.ToDecimal(Console.ReadLine());

            if (decSubtotal == null || decSubtotal < 0)
            {
                decimal deciSubtotal = (decimal)decSubtotal;

                Customer customer = new Customer(strType);
                if (customer != null)
                {
                    Discountable discounter = DiscountGenerator.GenerateDiscounter(customer.Type);

                    if (discounter != null)
                    {
                        int intDiscount = discounter.CalcDiscount(deciSubtotal);

                        decimal decDiscount = deciSubtotal / intDiscount;
                        Console.WriteLine($"Subtotal: {deciSubtotal.ToString("C")}");
                        Console.WriteLine($"Discount Percent: {intDiscount.ToString("P")}");
                        Console.WriteLine($"Discount: {decDiscount.ToString("C")}");
                        Console.WriteLine($"Total: {(deciSubtotal - decDiscount).ToString("C")}");
                    }
                }
            }
        }
    }

    internal class Customer
    {
        private string strType;

        public Customer(string strType)
        {
            this.strType = strType;
        }

        public string Type
        {
            get { return strType; }
            set { strType = value; }
        }
    }

    internal class DiscountGenerator 
    {
        private DiscountGenerator() { }

        public static Discountable GenerateDiscounter(string strType)
        {
            Discountable discount = null;

            if (strType.Equals("R"))
            {
                discount = new TypeRDiscount();
            }
            else if (strType.Equals("C")) 
            { 
                discount = new TypeCDiscount();
            }
            return discount;
        }
    }

    interface Discountable
    {
        abstract public int CalcDiscount(decimal decSubtotal);
    }


    internal class TypeRDiscount : Discountable 
    {
        public int CalcDiscount(decimal decSubtotal)
        {
            var intDiscount = 0;

            if (decSubtotal <= 250)
            {
                intDiscount = 25;
            }
            else if (decSubtotal <= 100)
            {
                intDiscount = 10;
            }
            else
            {
                intDiscount = 0;
            }
            return intDiscount;
        }
    }

    internal class TypeCDiscount : Discountable 
    {
        public int CalcDiscount(decimal decSubtotal)
        {
            var intDiscount  = decSubtotal >= 250 ? 30 : 20;
            return 0;
        }
    }
}

