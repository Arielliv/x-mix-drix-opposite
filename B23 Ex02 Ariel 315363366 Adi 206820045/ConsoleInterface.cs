using System;
namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class ConsoleInterface
    {
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
            int gridSize = i_GameGrid.getGridSize();

            showGameGridHeader(gridSize);
            for (int x = 0; x < gridSize; x++)
            {
                Console.Write($"{x + 1}");
                for (int y = 0; y < gridSize; y++)
                {
                    showCellContent(i_GameGrid.getCellContent(x, y));
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

        private static void showGameGridHeader(int gridSize)
        {
            Console.Write("  ");
            for (int i = 0; i < gridSize; i++)
            {
                Console.Write($"{i + 1}   ");
            }

            Console.WriteLine();
        }

        private static void showCellContent(eMark cellContent)
        {
            Console.Write($"| {(char)cellContent} ");
        }

        public static void GetLineNumber()
        {
            Console.Write("Please enter the line number: ");
        }

        public static void GetColumnNumber()
        {
            Console.Write("Please enter the column number: ");
        }

        public static string GetCellIndexWhenInvalid(int gridSize)
        {
            Console.Write($"You've entered invalid input, please enter a number between 0 and {gridSize}: ");
            return Console.ReadLine();
        }
    }
}
