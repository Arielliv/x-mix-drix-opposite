using System;
namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public class UserInterface
    {
        private GameController m_GameController;

        public void StartGamesSession()
        {
            bool shouldPlayAnotherRound = true;
            int gridSize = UserInputUtils.GetGridSize();
            eGameModes gameMode = UserInputUtils.GetGameMode();

            this.m_GameController = new GameController(gameMode);
            while (shouldPlayAnotherRound)
            {
                this.startGame(gridSize);
                shouldPlayAnotherRound = UserInputUtils.GetWhetherToPlayAnotherRound();
            }

            ConsoleUtils.WaitForUserInput();
        }

        private bool startGame(int i_GrideSize)
        {
            this.m_GameController.InitNewGame(i_GrideSize);

            return this.playGame(i_GrideSize);
        }

        private bool playGame(int i_GrideSize)
        {
            bool isVictory = false;
            int[] nextMove;
            bool isQuit = false;

            ConsoleUtils.ShowGameGrid(this.m_GameController.GetGrid());
            while (!isVictory && this.m_GameController.GetLeftoverMovesCount() > 0 && !isQuit)
            {
                nextMove = getNextPlayerMove(this.m_GameController.GetActivePlayer().Type, i_GrideSize);
                isQuit = this.shouldQuit(nextMove);
                if (!isQuit)
                {
                    this.m_GameController.ApplyNextMove(nextMove);
                    isVictory = this.m_GameController.IsVictory();
                    ConsoleUtils.ShowGameGrid(this.m_GameController.GetGrid());
                    if (!isVictory)
                    {
                        this.m_GameController.SetNextActivePlayer();
                    }
                }
            }

            if (!isQuit)
            {
                this.handleEndGame(isVictory);
            }

            return isQuit;
        }

        private bool shouldQuit(int[] i_PlayerNextMove)
        {
            return i_PlayerNextMove == null;
        }

        private int[] getNextPlayerMove(ePlayerTypes i_CurrenctPlayerType, int i_GrideSize)
        {
            bool isNextMoveValid = false;
            int[] nextMove = null;

            while (!isNextMoveValid)
            {
                if (i_CurrenctPlayerType == ePlayerTypes.Person)
                {
                    nextMove = UserInputUtils.GetPlayerNextMove(i_GrideSize);
                }
                else
                {
                    nextMove = this.m_GameController.GetComputerNextMove();
                }

                if (nextMove == null || this.m_GameController.IsNextMoveValid(nextMove))
                {
                    isNextMoveValid = true;
                }
                else
                {
                    ConsoleUtils.ShowMessageWhenInvalidCellIndex(i_GrideSize);
                }
            }

            return nextMove;
        }

        private void handleEndGame(bool i_IsVictory)
        {
            if (this.m_GameController.GetLeftoverMovesCount() == 0)
            {
                ConsoleUtils.ShowMessageWhenGameOverWithTie();
                ConsoleUtils.ShowMessageWithPlayersScore(this.m_GameController.Players);
            }

            if (i_IsVictory)
            {
                ConsoleUtils.ShowGameGrid(this.m_GameController.GetGrid());
                this.m_GameController.SetNextActivePlayer();
                this.m_GameController.GetActivePlayer().Score++;
                ConsoleUtils.ShowMessageWhenGameOverWithWin(this.m_GameController.GetActivePlayer().Mark);
                ConsoleUtils.ShowMessageWithPlayersScore(this.m_GameController.Players);
            }
        }
    }
}
