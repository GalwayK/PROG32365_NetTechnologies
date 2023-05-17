namespace Week2Lesson1
{
    internal class Program
    {
        const int intCon = 12;
        static void Main(string[] args)
        {
            // Exercises.PrintDiscount();
            CalculateInterestRate();
        }

        private static void CalculateInterestRate()
        {
            Console.Write("Enter monthly investment: ");
            decimal monthlyInvestment = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter monthly interest rate: ");
            decimal monthlyInterestRate = (Convert.ToDecimal(Console.ReadLine()) / 12) / 100;
            InvestmentCalculator investmentCalculator = new InvestmentCalculator(monthlyInvestment, monthlyInterestRate);

            Console.Write("Enter number of years: ");
            int numMonths = Convert.ToInt32(Console.ReadLine()) * 12;

            Console.WriteLine($"Monthly Interest Rate: {monthlyInterestRate}\n" +
                $"Monthly Investment: {monthlyInvestment}\n" +
                $"Number of Months: {numMonths}");

            decimal returnedInvestment = investmentCalculator.CalculateInvestment(numMonths);
            Console.WriteLine($"The returned value is after {numMonths} months is {returnedInvestment.ToString("C")}");
        }

        private static void WeekTwoLessonOne()
        {
            int intNumber = 0;
            long lngNumber = 12L;
            decimal decMoney = 1.23M;
            float floNumber = 1.2F;
            double douNumber = 1.2;
            bool isTrue = true;
            string strSentence = "String is not uppercase in C#.";
            string strNull = null;
            string strTemplate = $"My sentence: {strSentence}";

            Console.WriteLine("{0} {1}", strSentence, "I overall prefer template strings");

            Console.Write("Please enter the radius of a circle: ");
            double? douRadius = double.Parse(Console.ReadLine());
            Console.WriteLine(douRadius);

            Circle circle = new Circle(douRadius);

            Console.WriteLine($"Radius: {circle.getRadius()}");
            Console.WriteLine($"Area: {circle.getArea()}");

            Complex comA = new Complex(1, 2);
            Complex comB = new Complex(3, 4);

            Console.WriteLine(comA.Real + " " + comA.Imaginary);
            Console.WriteLine(comB.Real + " " + comB.Imaginary);

            Complex comC = comA + comB;
            Console.WriteLine(comC.Real + " " + comC.Imaginary);

            int intA1 = 21;
            Console.WriteLine($"The value of A1 before the call is {intA1}");
            changeVariable(ref intA1);
            Console.WriteLine($"The value of A1 after the call is {intA1}");

            int intOne = 10;
            int intTwo = 2;

            double douOne, douTwo;

            if (addNumbers(intOne, intTwo, out douOne, out douTwo))
            {
                Console.WriteLine($"Num One: {douOne} Num Two: {douTwo}");
            }
        }

        private static void changeVariable(ref int intNum)
        {
            intNum = 12;
        }

        private static bool addNumbers(int intOne, int intTwo, out double douOne, out double douTwo)
        {
            douOne = 0.0;
            douTwo = 0.0;
            Console.WriteLine(intOne);

            if (intOne > 100 && intOne < 0)
            {
                Console.WriteLine("False");
                return false;
            }

            if (intOne > intTwo)
            {
                Console.WriteLine("True");
                douOne = (intOne + 0.0) / intTwo;
                douTwo = intOne * intTwo;
            }
            return true;
        }

        public double doIt() => 23 + 32;
        
    }
}