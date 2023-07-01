using System;
using System.Runtime.Intrinsics.Arm;

public class ArithmeticGame
{
    private int[] arrNumbers = new int[2];

	private void FuncCreateNumbers()
	{
        Random random = new Random();
        this.FuncFillNumArray(0, random);
	}

    private void FuncFillNumArray(int intRepetitions, Random random)
    {
        if (intRepetitions < 2)
        {
            FuncFillNumArray(intRepetitions + 1, random);
            this.arrNumbers[intRepetitions] = random.Next(20) - 10;
        }
    }

    private void FuncPrintArray()
    {
        void FuncPrintIndex(int intIndex)
        {
            if (intIndex < arrNumbers.Length)
            {
                FuncPrintIndex(intIndex + 1);
                Console.WriteLine(arrNumbers[intIndex]);
            }
        }

        FuncPrintIndex(0);
    }

    private int FuncAddArrayValues()
    {
        return this.arrNumbers[0] + this.arrNumbers[1];
    }

    public void FuncTestArithmetic()
    {
        do
        {
            this.FuncCreateNumbers();
            this.FuncPrintArray();
            do
            {
                Console.WriteLine($"What is {this.arrNumbers[0]} + {this.arrNumbers[1]}?\nEnter the Answer: ");
                try
                {
                    int intAnswer = int.Parse(Console.ReadLine());
                    if (intAnswer == this.FuncAddArrayValues())
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect try again!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Your input was invalid, please enter a number.");
                }
            } while (true);
            Console.WriteLine("Correct!\nPlay again?: ");
            try
            {
                char chaPlayAgain = Console.ReadLine().ToLower().ToCharArray()[0];
                if (chaPlayAgain != 'y')
                {
                    break;
                }
            }
            catch (Exception ex)
            {

            }
        } while (true);
	}
}
