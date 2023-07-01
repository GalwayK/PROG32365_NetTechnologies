using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoReview
{
    public class TicTacToe
    {
        public TicTacToe()
        {
            Board = new int[3, 3]
                {
                    {0, 0, 0 },
                    {0, 0, 0 },
                    {0, 0, 0 }
                };
            HasVictor = false;
        }

        public bool HasVictor
        {
            get;
            set;
        }


        public int[,] Board
        { 
            get; set; 
        }

        public TicTacToe PrintBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(Board[row, col] + " ");
                }
                Console.WriteLine();
            }

            return this;
        }

        public TicTacToe PlayGame()
        {
            bool IsValid(int intRow, int intCol)
            {
                return intRow > 0 && intRow < 4 && intCol > 0 && intCol < 4;
            }

            bool CheckSurrounding(int row, int col, int currentPlayer)
            {
                int count = 0;

                for (int r = row - 1; r <= row + 1; r++)
                {
                    
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        try
                        {
                            if (r == row && c == col)
                            {
                                continue;
                            }
                            Console.WriteLine($"({r},{c}) = {Board[r, c]}");
                            if (Board[r, c] == currentPlayer && !IsCenter(row, col))
                            {
                                Console.WriteLine("Found First Adjacency: " + Board[r, c]);
                                Console.WriteLine("Found Second Adjacency?: " + Board[2 * r - row, 2 * c - col]);
                                if (Board[2 * r - row, 2 * c - col] == currentPlayer)
                                {
                                    return true;
                                }
                            }
                        }
                        catch (Exception ex) 
                        {
                            continue;
                        }
                    }
                }

                bool IsCenter(int row, int col) => row == 1 && col == 1;

                return false;
            }

            bool IsWinner(int currentPlayer)
            {
                bool isWinner = false;
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (Board[row, col] == currentPlayer)
                        {
                            Console.WriteLine($"({row},{col}) = {currentPlayer}: Checking Surroundings!");

                            isWinner = CheckSurrounding(row, col, currentPlayer);
                        }
                    }
                }
                return isWinner;
            }

            Console.WriteLine("Board Status");
            this.PrintBoard();
            while (!HasVictor)
            {
                    for (int i = 1; i <= 1; i++)
                    {
                        Console.Write($"Player {i}: Enter Your Row (1-3): ");
                        int intRow = int.Parse(Console.ReadLine());
                        Console.Write($"Player {i}: Enter Your Column (1-3): ");
                        int intCol = int.Parse(Console.ReadLine());
                        if (Board[intRow - 1, intCol - 1] == 0 && IsValid(intRow, intCol))
                        {
                            Board[intRow - 1, intCol - 1] = i;
                            this.PrintBoard();
                        HasVictor = IsWinner(i);
                            if (HasVictor) 
                            {
                                Console.WriteLine($"Player {i} is the winner!");
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Please select a valid spot on the grid.");
                        }
                    }
            }

            return this;
        }
    }
}
