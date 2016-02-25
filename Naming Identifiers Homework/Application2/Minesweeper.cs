using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameProject
{
    public class Minesweeper
    {
        public static void sortWinners(List<Player> winners)
        {
            Console.WriteLine("\nTo4KI:");
            if (winners.Count > 0)
            {
                for (int i = 0; i < winners.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, winners[i].Name, winners[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        public static void Move(char[,] field, char[,] bombs, int row, int col)
        {
            char countOfBombs = GetCountOfBombs(bombs, row, col);
            bombs[row, col] = countOfBombs;
            field[row, col] = countOfBombs;
        }

        public static void drawBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        public static char[,] CreateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        public static char[,] PlaceBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> bombsList = new List<int>();
            while (bombsList.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!bombsList.Contains(randomNumber))
                {
                    bombsList.Add(randomNumber);
                }
            }

            foreach (int randomNumber in bombsList)
            {
                int col = randomNumber / cols;
                int row = randomNumber % cols;
                if (row == 0 && randomNumber != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        //Method that returns how many bombs are there around the cell player has entered
        public static char GetCountOfBombs(char[,] bombs, int row, int col)
        {
            int count = 0;
            int rows = bombs.GetLength(0);
            int cols = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (bombs[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (bombs[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (bombs[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bombs[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (bombs[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (bombs[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (bombs[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            char bombsNear = char.Parse(count.ToString());
            return bombsNear;
        }
    }
}