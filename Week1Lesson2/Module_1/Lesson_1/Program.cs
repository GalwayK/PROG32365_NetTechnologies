// We use namespaces to organize classes and program structures separately.
namespace Lesson_1
{
    public class LessonOneProgram
    {
        public static void FuncCalcRadius()
        {
            Console.Write("Please enter the radius of a circle: ");
            try
            {
                double numRadius = Double.Parse(Console.ReadLine());
                double numDiameter = numRadius * 2;
                double numCircumference = 2 * Math.PI * numRadius;
                double numArea = Math.PI * (Math.Pow(numRadius, 2));

                Console.WriteLine($"Thank you for your entry!" +
                    $"\nDiameter: {numDiameter}" +
                    $"\nCircumference: {numCircumference}" +
                    $"\nArea: {numArea}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error in your data entry, " +
                    "please try again.");
            }
        }

        public static void FuncPrintSums(int intNumber)
        {
            Console.WriteLine($"{"Number",7}{"Square",7}{"Cube",7}");
            for (int i = 0; i < intNumber; i++)
            {
                Console.WriteLine($"{i,7}{Math.Pow(i, 2),7}{Math.Pow(i, 3),7}");
            }
        }

        public static void FuncGuessNumber(int intMinimum, int intMaximum)
        {
            while (true)
            {
                Random random = new Random();
                int intRandom = random.Next(intMinimum, intMaximum);
                Boolean isCorrect = false;

                while (true)
                {
                    Console.Write($"Guess a number between {intMinimum} and {intMaximum}: ");
                    int? intGuess = int.Parse(Console.ReadLine().Trim());
                    if (intGuess == intRandom)
                    {
                        break;
                    }
                    else if (intGuess > intRandom)
                    {
                        Console.WriteLine("Too high!");
                    }
                    else
                    {
                        Console.WriteLine("Too low!");
                    }
                    Console.WriteLine("Guess again!");
                }
                Console.Write("You guessed correct!\nPlay again (y): ");
                char? chaAgain = char.Parse(Console.ReadLine().Substring(0, 1).ToLower());
                if (chaAgain != 'y')
                {
                    break;
                }
            }
        }
            
        
    }
}

// C# Access Modifiers 
/* 
public: Accessible anywhere, even outside the class.
private: Access only within the class.
protected: Accessible only to the class and its descendants.  
default: Accessible only within the same assembly.
internal: Accessible by any class within the same assembly or namespace.
*/