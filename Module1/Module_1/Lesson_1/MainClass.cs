using System;
using Lesson_1;

public class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //LessonOneProgram.FuncCalcRadius();
        //LessonOneProgram.FuncPrintSums(10);
        //LessonOneProgram.FuncGuessNumber(0, 100);
        ArithmeticGame game = new ArithmeticGame();
        game.FuncTestArithmetic();

    }
}
