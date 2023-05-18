using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Week2Lesson1
{
    internal class Lesson1Part2
    {
        public static void ReferenceParameters()
        {
            void swap(ref int numOne, ref int numTwo)
            {
                int temp = numOne;
                numOne = numTwo;
                numTwo = temp;
            }
            int numOne = 10;
            int numTwo = 20;

            Console.WriteLine($"NumOne: {numOne}\nNumTwo: {numTwo}");

            swap(ref numOne, ref numTwo);

            Console.WriteLine($"NumOne: {numOne}\nNumTwo: {numTwo}");
        }

        public static void OutputParameters()
        {
            int numOne = 10;
            int numTwo = 100;
            int numSum;
            int numProduct;

            void Calculate(int numOne, int numTwo, out int numSum, out int numProduct)
            {
                numSum = numOne + numTwo;
                numProduct = numOne * numTwo;
            }
            Calculate(numOne: numOne, numTwo: numTwo, out numSum, out numProduct);
            Console.WriteLine($"Product: {numProduct}\nSum: {numSum}");
        }

        public static void ExerciseTestString()
        {
            bool containsPeriod;
            bool containsComma;
            string strVar = "Hello!";
            TestString(out containsPeriod, out containsComma, strVar: strVar);
            Console.WriteLine($"{strVar}\nContains Period: {containsPeriod}\nContains Comma: {containsComma}\n");

            string strComma = "Hello,";
            TestString(out containsPeriod, out containsComma, strVar: strComma);
            Console.WriteLine($"{strComma}\nContains Period: {containsPeriod}\nContains Comma: {containsComma}\n");

            string strPeriod = "Hello.";
            TestString(out containsPeriod, out containsComma, strVar: strPeriod);
            Console.WriteLine($"{strPeriod}\nContains Period: {containsPeriod}\nContains Comma: {containsComma}\n");

        }

        public static void TestString(out bool containsComma, out bool containsPeriod, string strVar = "Why not though?")
        {
            containsPeriod = strVar.Contains('.');
            containsComma = strVar.Contains(',');
        }
    }

    public class TemperatureConverter
    { 

        private static string[] arrTemperatureUnits = {"Celsius", "Fahrenheit"};
        public static void Fahrenheit(double dblCelsius, out double dblFahrenheit)
        {
            dblFahrenheit = 9.0 / 5 * dblCelsius + 32;
        }

        public static void Celsius(double dblFahrenheit, out double dblCelsius)
        {
            dblCelsius = 5.0 / 9 * (dblFahrenheit - 32);
        }

        public static void TempConvert()
        {
            Console.Write("Convert to Celsius (1) or convert to Fahrenheit (2): ");
            int intSelection = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter temperature: ");
            double dblInputTemp = Convert.ToDouble(Console.ReadLine());
            double dblOutputTemp;
            switch (intSelection)
            {
                case 1:
                    Celsius(dblFahrenheit: dblInputTemp, out dblOutputTemp);
                        break;
                case 2:
                    Fahrenheit(dblCelsius: dblInputTemp, out dblOutputTemp);
                    break;
                default:
                    Console.WriteLine("Please enter a 1 or a 2.");
                    return;
            }
            string strTempUnit = arrTemperatureUnits[intSelection - 1];
            Console.WriteLine($"{strTempUnit}: {dblOutputTemp}");

/*
            double dblCelsius = 32;
            double dblFahrenheit;

            Fahrenheit(dblCelsius: dblCelsius, out dblFahrenheit);
            Console.WriteLine($"Celsius: {dblCelsius}");
            Console.WriteLine($"Fahrenheit: {dblFahrenheit}");

            dblFahrenheit = 120.0;
            Celsius(dblFahrenheit: dblFahrenheit, out dblCelsius);

            Console.WriteLine($"Celsius: {dblCelsius}");
            Console.WriteLine($"Fahrenheit: {dblFahrenheit}");
        
*/
        }
    }

    public class ExerciseExponation
    {
        public static void ExerciseExponents()
        {
            double dblNumber = 3;
            double dblPower = dblNumber;
            int intPower = 3;
            ExponentsWithRecursion(ref dblPower, intPower, dblNumber);
            Console.WriteLine($"{dblNumber} ^ {intPower} equals {dblPower}.");
        }
        private static void ExponentsWithRecursion(ref double dblNum, int numPower, double dblPower)
        {
            if (numPower > 2)
            {
                ExponentsWithRecursion(ref dblNum, numPower - 1, dblPower);
            }
            dblNum *= dblPower;
            Console.WriteLine(dblNum);
        }
    }

    public class Printer
    {
        public static void PrintLine(params string[] parameters)
        {
            void createOutputString(ref string strOutput, int arrLength, string[] arrStrings)
            {
               /* foreach (string str in parameters)
                {
                    Console.WriteLine(str);
                }*/
                if (arrLength > 0)
                {
                    createOutputString(ref strOutput, arrLength: arrLength - 1, arrStrings: arrStrings);
                }
                strOutput += arrStrings[arrLength];
            }
           
            // Console.WriteLine(parameters.Length);
            // Console.WriteLine(parameters[0]);
            string strOutput = "";
            createOutputString(strOutput: ref strOutput, parameters.Length - 1, parameters);
            Console.WriteLine(strOutput);
        }
    }

}
