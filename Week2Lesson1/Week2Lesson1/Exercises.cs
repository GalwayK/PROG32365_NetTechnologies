using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
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
                decimal decDiscount = (decimal)(decSubtotal * intDiscount / 100);
                decimal decTotal = (decimal)(decSubtotal - decDiscount);
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
            var intDiscount = decSubtotal >= 250 ? 30 : 20;
            return 0;
        }
    }

    public class ExerciseBMI
    {
        public static void Exercise()
        {
            Console.Write("Welcome to the BMI Calculator!\nPlease enter your weight: ");
            double dblWeight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your height in meters: ");
            double dblHeight = Convert.ToDouble(Console.ReadLine());
            double dblBMI = CalculateBMI(dblHeight, dblWeight);
            string strCategory = DetermineBMICategory(dblBMI);
            Console.WriteLine("Your BMI index is {0, 2}, and your BMI Category is {1}", dblBMI, strCategory);
        }

        public static double CalculateBMI(double dblHeight, double dblWeight)
        {
            return dblWeight / (dblHeight * dblHeight);
        }

        public static string DetermineBMICategory(double dblBMI)
        {
            string strCategory = null;
            Console.WriteLine(dblBMI < 18.5);
            if (dblBMI < 18.5)
            {
                strCategory = "Underweight";
            }
            else if (dblBMI >= 18.5 && dblBMI < 24.9)
            {
                strCategory = "Normal Weight";
            }
            else if (dblBMI >= 25.0 && dblBMI < 29.9)
            {
                strCategory = "Overweight";
            }
            else if (dblBMI >= 30 && dblBMI < 34.9)
            {
                strCategory = "Obese Class I";
            }
            else if (dblBMI >= 35 && dblBMI < 39.9)
            {
                strCategory = "Obese Class II";
            }
            else
            {
                strCategory = "Obese Class III";
            }
            return strCategory;
        }
    }

    public class ExerciseLooping
    {
        public static void BeginDaLoop()
        {
            Console.WriteLine($"{"N", -10}{"10 * N", -10}{"100 * N", -10}{"1000 * N", -10}");
            LoopDeLoop(5);
        }

        private static void LoopDeLoop(int numLoops)
        {
            if (numLoops > 1) 
            { 
                LoopDeLoop(numLoops - 1);
            }
            Console.WriteLine($"{numLoops, -10}{numLoops * 10, -10}{numLoops * 100, -10}{numLoops * 1000, -10}");
        }
    }

}

