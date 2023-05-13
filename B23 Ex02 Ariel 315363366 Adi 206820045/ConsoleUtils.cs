using System;
using Ex02.ConsoleUtils;

namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class ConsoleUtils
    {
        public const string k_QuitSign = "Q";
        public const string k_YesSign = "y";
        public const string k_NoSign = "n";

        public static void WaitForUserInput()
        {
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        public static string GetGridSize() 
        {
            Console.Write("Please enter the grid size: ");
            return Console.ReadLine();
        }

        public static string GetGridSizeWhenInvalid()
        {
            Console.Write("You've entered invalid input, please enter a number between 3 and 9: ");
            return Console.ReadLine();
        }

        public static string GetGameMode()
        {
            Console.Write("Please enter game mode, press 0 for PvP or 1 for PvC: ");
            return Console.ReadLine();
        }

        public static string GetGameModeWhenInvalid()
        {
            Console.Write("You've entered invalid input, please enter 0 for PvP or 1 for PvC: ");
            return Console.ReadLine();
        }

        public static void ShowGameGrid(Grid i_GameGrid)
        {
            int gridSize = i_GameGrid.GetGridSize();

            Screen.Clear();
            showGameGridHeader(gridSize);
            for (int x = 0; x < gridSize; x++)
            {
                Console.Write($"{x + 1}");
                for (int y = 0; y < gridSize; y++)
                {
                    showCellContent(i_GameGrid.GetCellContent(x, y));
                }

                Console.WriteLine("|");
                Console.Write(" ");
                for (int y = 0; y < gridSize; y++)
                {
                    Console.Write("====");
                }

                Console.WriteLine("=");
            }
        }

        private static void showGameGridHeader(int i_GridSize)
        {
            Console.Write("  ");
            for (int i = 0; i < i_GridSize; i++)
            {
                Console.Write($"{i + 1}   ");
            }

            Console.WriteLine();
        }

        private static void showCellContent(eMarks i_CellContent)
        {
            Console.Write($"| {(char)i_CellContent} ");
        }

        public static void GetLineNumber()
        {
            Console.Write("Please enter the line number: ");
        }

        public static void GetColumnNumber()
        {
            Console.Write("Please enter the column number: ");
        }

        public static void ShowMessageWhenInvalidCellIndex(int i_GridSize)
        {
            Console.WriteLine($"You've entered invalid input, please enter a number between 1 and {i_GridSize}."); 
        }

        public static string GetCellIndexWhenInvalid(int i_GridSize)
        {
            ShowMessageWhenInvalidCellIndex(i_GridSize);
            return Console.ReadLine();
        }

        public static void ShowMessageWhenGameOverWithTie()
        {
            Console.WriteLine("The game is over with tie!");
        }

        public static void ShowMessageWhenGameOverWithWin(eMarks i_Mark)
        {
            Console.WriteLine($"The game is over with victory of {i_Mark} player!");
        }

        public static void ShowMessageWithPlayersScore(Player[] i_Players)
        {
            foreach(Player player in i_Players)
            {
                Console.WriteLine($"{player.Mark} player's score: {player.Score}");
            }
        }

        public static string GetWhetherToPlayAnotherRound()
        {
            Console.WriteLine("Would you like to play another round? \npress n for No \npress y for Yes: ");
            return Console.ReadLine();
        }

        public static void ShowMessageWhenInvalidInputForWhetherToPlayAnotherRound()
        {
            Console.Write("You've entered invalid input, \npress n for No \npress y for Yes:");
        }

        public static string GetWhetherToPlayAnotherRoundWhenInvalid()
        {
            ShowMessageWhenInvalidInputForWhetherToPlayAnotherRound();
            return Console.ReadLine();
        }

        public static string GetCellIndex()
        {
            return Console.ReadLine();
        }
    }
}
