using System;
using System.Collections.Generic;
using Minesweeper.Models;

namespace Minesweeper.Engine
{
    internal static class MinesweeperEngine
    {
        internal static readonly int Rows = 5;

        internal static readonly int Columns = 10;

        internal static readonly int MaxMines = 15;

        internal static readonly int MaxCellsToBeOpened = 35;

        internal static readonly string IntroMessage = "Let's play Minesweeper! Try to uncover all cells without stepping on a mine.";

        internal static readonly string CommandsExplanation = "Commands:\n'top' shows ranking\n'restart' starts a new game\n'exit'";

        internal static readonly string AskPlayerForCoordinates = "Please enter a row and a column seperated by a blank space: ";

        internal static readonly string InvalidUserInputCoordinatesMessage = "Coordinates row: {0}, column: {1} are outside the play field!";

        internal static readonly string InvalidCommandMessage = "\nError! Command not valid.\n";

        internal static readonly string PlayerWonMessage = "\nCongratulations! You have successfully uncovered all cells!";

        internal static readonly string PlayerLostMessage = "\nYou have died heroically! Your points: {0}";

        internal static readonly string AskPlayerForName = "\nPlease enter your name: ";

        internal static readonly string ExitMessage = "Goodbye!";

        internal static void Play()
        {
            string command = string.Empty;
            int currentRow = 0;
            int currentColumn = 0;
            int openedCellsCount = 0;

            char[,] gameBoard = CreateGameBoard('?');
            char[,] gameBoardWithMines = PlaceMines();

            bool gameStarts = true;
            bool playerWon = false;
            bool steppedOnMine = false;

            List<Player> champions = new List<Player>(6);

            do
            {
                if (gameStarts)
                {
                    Console.WriteLine(IntroMessage);
                    Console.WriteLine(CommandsExplanation);
                    PrintBoard(gameBoard);
                    gameStarts = false;
                }

                Console.Write(AskPlayerForCoordinates);
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out currentRow) &&
                        int.TryParse(command[2].ToString(), out currentColumn) &&
                        currentRow < Rows && currentColumn < Columns)
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRanking(champions);
                        break;

                    case "restart":
                        gameBoard = CreateGameBoard('?');
                        gameBoardWithMines = PlaceMines();
                        PrintBoard(gameBoard);
                        steppedOnMine = false;
                        gameStarts = false;
                        break;

                    case "exit":
                        Console.WriteLine(ExitMessage);
                        break;

                    case "turn":
                        if (gameBoardWithMines[currentRow, currentColumn] != '*')
                        {
                            if (gameBoardWithMines[currentRow, currentColumn] == '-')
                            {
                                UpdateBoards(gameBoard, gameBoardWithMines, currentRow, currentColumn);
                                openedCellsCount++;
                            }

                            if (MaxCellsToBeOpened == openedCellsCount)
                            {
                                playerWon = true;
                            }
                            else
                            {
                                PrintBoard(gameBoard);
                            }
                        }
                        else
                        {
                            steppedOnMine = true;
                        }

                        break;

                    default:
                        if (currentRow >= Rows || currentColumn >= Columns)
                        {
                            Console.WriteLine("\n" + string.Format(InvalidUserInputCoordinatesMessage, currentRow, currentColumn) + "\n");
                            currentRow = 0;
                            currentColumn = 0;
                        }
                        else
                        {
                            Console.WriteLine(InvalidCommandMessage);
                        }

                        break;
                }

                if (steppedOnMine)
                {
                    PrintBoard(gameBoardWithMines);

                    Console.Write(PlayerLostMessage + AskPlayerForName, openedCellsCount);
                    string name = Console.ReadLine();
                    Player looser = new Player(name, openedCellsCount);

                    if (champions.Count < 5)
                    {
                        champions.Add(looser);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].UserPoints < looser.UserPoints)
                            {
                                champions.Insert(i, looser);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player playerOne, Player playerTwo) => playerTwo.UserName.CompareTo(playerOne.UserName));
                    champions.Sort((Player playerOne, Player playerTwo) => playerTwo.UserPoints.CompareTo(playerOne.UserPoints));
                    PrintRanking(champions);

                    gameBoard = CreateGameBoard('?');
                    gameBoardWithMines = PlaceMines();
                    openedCellsCount = 0;
                    steppedOnMine = false;
                    gameStarts = true;
                }

                if (playerWon)
                {
                    Console.WriteLine(PlayerWonMessage);
                    PrintBoard(gameBoardWithMines);

                    Console.WriteLine(AskPlayerForName);
                    string name = Console.ReadLine();
                    Player winner = new Player(name, openedCellsCount);
                    champions.Add(winner);
                    PrintRanking(champions);

                    gameBoard = CreateGameBoard('?');
                    gameBoardWithMines = PlaceMines();
                    openedCellsCount = 0;
                    playerWon = false;
                    gameStarts = true;
                }
            }
            while (command != "exit");
        }

        private static char[,] CreateGameBoard(char symbol)
        {
            char[,] board = new char[Rows, Columns];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    board[row, col] = symbol;
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            char[,] gameBoard = CreateGameBoard('-');

            List<int> minesPositions = new List<int>();
            Random random = new Random();

            while (minesPositions.Count < MaxMines)
            {
                int minePosition = random.Next(50);

                if (!minesPositions.Contains(minePosition))
                {
                    minesPositions.Add(minePosition);
                }
            }

            foreach (int position in minesPositions)
            {
                int column = position / Columns;
                int row = position % Columns;

                if (row == 0 && position != 0)
                {
                    column--;
                    row = Columns;
                }
                else
                {
                    row++;
                }

                gameBoard[column, row - 1] = '*';
            }

            return gameBoard;
        }

        private static void PrintBoard(char[,] board)
        {
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < Rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static void UpdateBoards(char[,] gameBoard, char[,] gameBoardWithMines, int currentRow, int currentColumn)
        {
            char countOfMinesAround = GetCountOfMinesAround(gameBoardWithMines, currentRow, currentColumn);
            gameBoardWithMines[currentRow, currentColumn] = countOfMinesAround;
            gameBoard[currentRow, currentColumn] = countOfMinesAround;
        }

        private static char GetCountOfMinesAround(char[,] gameBoardWithMines, int currentRow, int currentColumn)
        {
            int minesCount = 0;

            if (currentRow - 1 >= 0)
            {
                if (gameBoardWithMines[currentRow - 1, currentColumn] == '*')
                {
                    minesCount++;
                }
            }

            if (currentRow + 1 < Rows)
            {
                if (gameBoardWithMines[currentRow + 1, currentColumn] == '*')
                {
                    minesCount++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (gameBoardWithMines[currentRow, currentColumn - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (currentColumn + 1 < Columns)
            {
                if (gameBoardWithMines[currentRow, currentColumn + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (gameBoardWithMines[currentRow - 1, currentColumn - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < Columns))
            {
                if (gameBoardWithMines[currentRow - 1, currentColumn + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < Rows) && (currentColumn - 1 >= 0))
            {
                if (gameBoardWithMines[currentRow + 1, currentColumn - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < Rows) && (currentColumn + 1 < Columns))
            {
                if (gameBoardWithMines[currentRow + 1, currentColumn + 1] == '*')
                {
                    minesCount++;
                }
            }

            char minesCountAsChar = char.Parse(minesCount.ToString());

            return minesCountAsChar;
        }

        private static void UpdateGameBoardWithMines(char[,] gameBoardWithMines)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (gameBoardWithMines[i, j] != '*')
                    {
                        char countOfMinesAround = GetCountOfMinesAround(gameBoardWithMines, i, j);
                        gameBoardWithMines[i, j] = countOfMinesAround;
                    }
                }
            }
        }

        private static void PrintRanking(List<Player> players)
        {
            Console.WriteLine("\nRanking: ");

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, players[i].UserName, players[i].UserPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!\n");
            }
        }
    }
}
