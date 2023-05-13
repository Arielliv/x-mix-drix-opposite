using System;

namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public class UserInputUtils
    {
        public static int GetGridSize()
        {
            int gridSize = 0;
            string gridSizeInput;
            bool isValidGridSizeInput = false;

            gridSizeInput = ConsoleUtils.GetGridSize();
            while (!isValidGridSizeInput)
            {
                if (int.TryParse(gridSizeInput, out gridSize) && GameSettingsValidators.IsValidGridSize(gridSize))
                {
                    isValidGridSizeInput = true;
                }
                else
                {
                    gridSizeInput = ConsoleUtils.GetGridSizeWhenInvalid();
                }
            }

            return gridSize;
        }

        public static eGameModes GetGameMode()
        {
            string gameModeInput;
            eGameModes gameMode = eGameModes.AgainstComputer;
            bool isValidGameModeInput = false;

            gameModeInput = ConsoleUtils.GetGameMode();
            while (!isValidGameModeInput)
            {
                if (Enum.TryParse(gameModeInput, out gameMode) && Enum.IsDefined(typeof(eGameModes), gameMode))
                {
                    isValidGameModeInput = true;
                }
                else
                {
                    gameModeInput = ConsoleUtils.GetGameModeWhenInvalid();
                }
            }

            return gameMode;
        }

        public static int[] GetPlayerNextMove(int i_GridSize)
        {
            int x;
            int y;
            int[] result = null;

            ConsoleUtils.GetLineNumber();
            x = GetCellIndex(i_GridSize);
            if (x != -1)
            {
                ConsoleUtils.GetColumnNumber();
                y = GetCellIndex(i_GridSize);
                if (y != -1)
                {
                    result = new int[] { x - 1, y - 1 };
                }
            }

            return result;
        }

        public static int GetCellIndex(int i_GridSize)
        {
            bool isValidInputValue = false;
            string inputValue;
            int cellIndex = 0;

            inputValue = ConsoleUtils.GetCellIndex();
            while (!isValidInputValue)
            {
                if (inputValue.Equals(ConsoleUtils.k_QuitSign))
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
                    inputValue = ConsoleUtils.GetCellIndexWhenInvalid(i_GridSize);
                }
            }

            return cellIndex;
        }

        public static bool GetWhetherToPlayAnotherRound()
        {
            bool isValidAnotherRoundInput = false;
            string shouldPlayAnotherRoundInput;
            bool shouldPlayAnotherRound = false;

            shouldPlayAnotherRoundInput = ConsoleUtils.GetWhetherToPlayAnotherRound();
            while (!isValidAnotherRoundInput)
            {
                if (shouldPlayAnotherRoundInput.Equals(ConsoleUtils.k_YesSign))
                {
                    shouldPlayAnotherRound = true;
                    isValidAnotherRoundInput = true;
                }
                else if (shouldPlayAnotherRoundInput.Equals(ConsoleUtils.k_NoSign))
                {
                    shouldPlayAnotherRound = false;
                    isValidAnotherRoundInput = true;
                }
                else
                {
                    shouldPlayAnotherRoundInput = ConsoleUtils.GetWhetherToPlayAnotherRoundWhenInvalid();
                }
            }

            return shouldPlayAnotherRound;
        }
    }
}
