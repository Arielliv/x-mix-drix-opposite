using System;
namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class UserInterface
    {
        
        public static int GetGridSize()
        {
            int gridSize = 0;
            string gridSizeInput;
            bool isValidGridSizeInput = false;

            gridSizeInput = ConsoleInterface.GetGridSize();
            while (!isValidGridSizeInput)
            {
                if (int.TryParse(gridSizeInput, out gridSize) && gridSize >= 3 && gridSize <= 9)
                {
                    isValidGridSizeInput = true;
                }
                else
                {
                    gridSizeInput = ConsoleInterface.GetGridSizeWhenInvalid();
                }
            }

            return gridSize;
        }

        public static eGameMode GetGameMode()
        {
            string gameModeInput;
            eGameMode gameMode = eGameMode.AgainstComputer;
            bool isValidGameModeInput = false;

            gameModeInput = ConsoleInterface.GetGameMode();
            while (!isValidGameModeInput)
            {
                if (Enum.TryParse(gameModeInput, out gameMode))
                {
                    isValidGameModeInput = true;
                }
                else
                {
                    gameModeInput = ConsoleInterface.GetGameModeWhenInvalid();
                }
            }

            return gameMode;
        }


        public static int[] GetPlayerNextMove(int gridSize)
        {
            int x = 0;
            int y = 0;

            ConsoleInterface.GetLineNumber();
            x = getCellIndex(gridSize);
            ConsoleInterface.GetColumnNumber();
            y = getCellIndex(gridSize);

            return new int[] {x,y};
        }

        private static int getCellIndex (int gridSize) {
            bool isValidInputValue = false;
            string inputValue;
            int cellIndex = 0;

            inputValue = Console.ReadLine();

            while (!isValidInputValue)
            {
                if (int.TryParse(inputValue, out cellIndex) && cellIndex >= 1 && cellIndex <= gridSize)
                {
                    isValidInputValue = true;
                }
                else
                {
                    inputValue = ConsoleInterface.GetCellIndexWhenInvalid(gridSize);
                }
            }
            return cellIndex;
        }

    }


}
