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

        public static int[] GetPlayerNextMove(int i_GridSize)
        {
            int x = 0;
            int y = 0;
            int[] result = null;

            ConsoleInterface.GetLineNumber();
            x = getCellIndex(i_GridSize);
            if(x == -1)
            {
                result = new int[] { x };
            }
            else {
                ConsoleInterface.GetColumnNumber();
                y = getCellIndex(i_GridSize);
                if (y == -1)
                {
                    result = new int[] { y };
                } 
                else
                {
                    result = new int[] { x - 1, y - 1 };
                } 
            } 

            return result;
        }

        private static int getCellIndex (int i_GridSize) {
            bool isValidInputValue = false;
            string inputValue;
            int cellIndex = 0;

            inputValue = ConsoleInterface.GetCellIndex();
            while (!isValidInputValue)
            {
                if(inputValue.Equals(ConsoleInterface.k_QuitSign))
                {
                    isValidInputValue = true;
                    cellIndex = -1;
                }
                else if (int.TryParse(inputValue, out cellIndex))
                {
                    isValidInputValue = true;
                }
                else
                {
                    inputValue = ConsoleInterface.GetCellIndexWhenInvalid(i_GridSize);
                }
            }

            return cellIndex;
        }

        public static bool GetWhetherToPlayAnotherRound()
        {
            bool isValidAnotherRoundInput = false;
            string shouldPlayAnotherRoundInput;
            bool shouldPlayAnotherRound = false;

            shouldPlayAnotherRoundInput = ConsoleInterface.GetWhetherToPlayAnotherRound();
            while (!isValidAnotherRoundInput)
            {
                if (shouldPlayAnotherRoundInput.Equals(ConsoleInterface.k_YesSign))
                {
                    shouldPlayAnotherRound = true;
                    isValidAnotherRoundInput = true;
                }
                else if (shouldPlayAnotherRoundInput.Equals(ConsoleInterface.k_NoSign))
                {
                    shouldPlayAnotherRound = false;
                    isValidAnotherRoundInput = true;
                }
                else
                {
                    shouldPlayAnotherRoundInput = ConsoleInterface.GetWhetherToPlayAnotherRoundWhenInvalid();
                }
            }

            return shouldPlayAnotherRound;
        }
    }
}
