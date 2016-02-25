using GameProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class StartingPoint
    {
        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] board = Minesweeper.CreateBoard();
            char[,] bombs = Minesweeper.PlaceBombs();
            int pointsEarned = 0;
            bool isBombed = false;
            List<Player> winnersList = new List<Player>(6);
            int row = 0;
            int col = 0;

            const int max = 35;
            bool isWinner = false;

            bool gameStart = true;
            do
            {
                if (gameStart)
                {
                    string helloMessage = "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki.\nKomanda \'top\' pokazva klasiraneto, \'restart\' po4va nova igra, \'exit\' izliza i hajde 4ao!";
                    Console.WriteLine(helloMessage);
                    Minesweeper.drawBoard(board);
                    gameStart = false;
                }

                string commandRowCol = "Daj red i kolona : ";
                Console.Write(commandRowCol);


                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= board.GetLength(0) && col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Minesweeper.sortWinners(winnersList);
                        break;
                    case "restart":
                        board = Minesweeper.CreateBoard();
                        bombs = Minesweeper.PlaceBombs();
                        Minesweeper.drawBoard(board);
                        isBombed = false;
                        gameStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                Minesweeper.Move(board, bombs, row, col);
                                pointsEarned++;
                            }

                            if (max == pointsEarned)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                Minesweeper.drawBoard(board);
                            }
                        }
                        else
                        {
                            isBombed = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isBombed)
                {
                    Minesweeper.drawBoard(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", pointsEarned);
                    string name = Console.ReadLine();
                    Player player = new Player(name, pointsEarned);
                    if (winnersList.Count < 5)
                    {
                        winnersList.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < winnersList.Count; i++)
                        {
                            if (winnersList[i].Points < player.Points)
                            {
                                winnersList.Insert(i, player);
                                winnersList.RemoveAt(winnersList.Count - 1);
                                break;
                            }
                        }
                    }

                    winnersList.Sort((Player playerFirst, Player playerSecond) => playerSecond.Name.CompareTo(playerFirst.Name));
                    winnersList.Sort((Player playerFirst, Player playerSecond) => playerSecond.Points.CompareTo(playerFirst.Points));
                    Minesweeper.sortWinners(winnersList);

                    board = Minesweeper.CreateBoard();
                    bombs = Minesweeper.PlaceBombs();
                    pointsEarned = 0;
                    isBombed = false;
                    gameStart = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    Minesweeper.drawBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Player player = new Player(name, pointsEarned);
                    winnersList.Add(player);
                    Minesweeper.sortWinners(winnersList);
                    board = Minesweeper.CreateBoard();
                    bombs = Minesweeper.PlaceBombs();
                    pointsEarned = 0;
                    isWinner = false;
                    gameStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }
    }
}
