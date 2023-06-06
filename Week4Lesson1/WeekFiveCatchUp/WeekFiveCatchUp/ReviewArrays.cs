using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFiveCatchUp
{
    public class ReviewArrays
    {
        public static void ReviewMultiDimensionArrays()
        {
            int[] arrNumbersOne = new int[4];
            arrNumbersOne = new int[] { 1, 2 };
            int[] arrNumbersTwo = new int[4] { 3, 4, 5, 6 };
            int[] arrNumbersThree = { 7, 8, 9, 10 };
            Console.WriteLine($"The first element is: {arrNumbersOne[0]}");

            // Jagged array - array of arrays of different lengths
            int[][] arrArrayNumbers = new int[][] { arrNumbersOne, arrNumbersTwo, arrNumbersThree };

            Console.WriteLine("The length of the array is: " + arrArrayNumbers.Length);
            foreach(var arrNumbers in arrArrayNumbers )
            {
                foreach (var number in arrNumbers )
                {
                    Console.WriteLine($"The current number is: {number}");
                }
            }
            Console.WriteLine("\nFitting array\n");
            // Converting Jagged array into Multidimensional array by resizing until all elements fit into the container 

            int numElements = 0;
            for (int i = 0; i < arrArrayNumbers.Length; i++)
            {
                for (int j = 0; j < arrArrayNumbers[i].Length; j++)
                {
                    numElements++;   
                }
            }

            int numRank = 0;
            int numLength = 0;
            int div;
            for (div = 2; div <= numElements; div++)
            {
                if (numElements % div == 0)
                {
                    numRank = numElements / div;
                    break;
                }
            }
            numLength = div;

            int[,] convertedArray = new int[numRank, numLength];
            Console.WriteLine($"Rank: {numRank}");
            Console.WriteLine($"Length: {numLength}");
            int numElement = 0;
            for (int i = 0; i  < arrArrayNumbers.Length; i++)
            {
                for (int j = 0; j < arrArrayNumbers[i].Length; j++)
                {
                    int currentRank = numElement / (numLength);
                    int currentLength = numElement % (numLength);
                    Console.Write($"Inserting into index ({currentLength},{currentRank}) from array index ({i}, {j}): "); 

                   Console.WriteLine($"{arrArrayNumbers[i][j]}");

                    convertedArray[currentRank, currentLength] = arrArrayNumbers[i][j];
                    Console.WriteLine("Element filled!");

                    numElement++;
                    /*for (int k = 0; k < numRank; k++)
                    {
                        for (int  l = 0; l < numLength; l++)
                        {
                            convertedArray[k, l] = arrArrayNumbers[i][j];
                        }
                    }*/

                }
            }
            
            foreach(var number in convertedArray )
            {
                Console.WriteLine($"The number in the fitted array is: {number}");
            }

            // Converting Jagged array to multidimensional array by truncating elements which do not fit. 

            int numArrDepth = arrArrayNumbers.Length;
            int numMinLength = arrArrayNumbers[0].Length;
            for (int i = 1; i < arrArrayNumbers.Length; i++)
            {
                numMinLength = arrArrayNumbers[i].Length < numMinLength 
                    ? arrArrayNumbers[i].Length 
                    : numMinLength;
            }

            Console.WriteLine($"\nThe minimum length is: {numMinLength}\n");

            int[,] arrRectNumbers = new int[numArrDepth, numMinLength];

            for (int rank = 0; rank < numArrDepth; rank++)
            {
                for (int length  = 0; length < numMinLength; length++)
                {
                    arrRectNumbers[rank, length] = arrArrayNumbers[rank][length];
                }
            }

            foreach(var number in arrRectNumbers)
            {
                Console.WriteLine($"The current number of the converted rectangular array is: {number}");
            }


            // Rectangular array - array of equilength arrays
            int[,] arrCubes = { { 1, 2, 3, 4 }, { 1, 4, 9, 16 }, { 1, 16, 91, 256 } };

            // Printing all numbers in a row with one iteration
            foreach(var number in arrCubes)
            {
                Console.WriteLine($"\nThe current number is {number}");
            }

            // Manually printing each number
            Console.WriteLine("\nPrinting manually\n");

            for (int i = 0; i < arrCubes.GetLength(0); i++)
            {
                arrCubes[0, 1] = 246;
                for (int j = 0; j < arrCubes.GetLength(1); j++)
                {
                    Console.WriteLine($"The current number is: {arrCubes[i, j]}");
                }
            }

            int[,] testArr = new int[3, 2];
            testArr[0, 0] = 1;
            testArr[1, 0] = 2;
            testArr[2, 0] = 3;
            testArr[0, 1] = 4;
            testArr[1, 1] = 5;
            testArr[2, 1] = 6;
            Console.WriteLine("\n\n\n\n");
            int[,] arrNum = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            Console.WriteLine($"Length at rank 0: {arrNum.GetLength(0)}");
            Console.WriteLine($"Length at rank 1: {arrNum.GetLength(1)}");

            Console.WriteLine($"Length at rank 0: {testArr.GetLength(0)}");
            Console.WriteLine($"Length at rank 1: {testArr.GetLength(1)}");
            Console.WriteLine(arrNum[2, 1]);

            for (int rank = 0; rank < arrNum.GetLength(0); rank++)
            {
                for (int length = 0; length < arrNum.GetLength(1); length++)
                {
                    Console.Write("Length: " + length);
                    Console.Write(" Rank: " + rank + " ");
                    Console.Write($"Printing ({rank},{length}): ");
                    Console.WriteLine(arrNum[rank, length]);
                }
            }

            Console.WriteLine("\n\n\n\n\nShould be 5: " + arrNum[2, 0]);
            Console.WriteLine($"arrNum rank: {arrNum.Rank}");
            Console.WriteLine($"testArr rank: {testArr.Rank}");

            Console.WriteLine($"arrNum length: {arrNum.GetLength(0)}");
            Console.WriteLine($"testArr length: {testArr.GetLength(0)}");

            for (int rank = 0; rank < arrNum.GetLength(1); rank++)
            {
                for (int length = 0; length < arrNum.GetLength(0); length++)
                {
                    Console.Write($"Compare index ({length}, {rank}): ");
                    Console.Write($" {testArr[length, rank]} == {arrNum[length, rank]}");
                }
            }
            Console.WriteLine(testArr[0, 0]);
            Console.WriteLine(testArr[1, 0]);
        }
    }
}
