using System;

namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class GameController
    {
        private Player[] m_Players = new Player[2];
        private Game m_ActiveGame;

        private void setPlayers(eGameMode i_GameMode) {
            this.m_Players[0] = new Player(ePlayerType.Person, eMark.X);
            if (i_GameMode == eGameMode.TwoPlayers)
            {
                this.m_Players[1] = new Player(ePlayerType.Person, eMark.O);
            } 
            else
            {
                this.m_Players[1] = new Player(ePlayerType.Computer, eMark.O);
            }
        }

        public void PlayGame()
        {
            bool shouldPlayAnotherRound = true;
            int gridSize = UserInterface.GetGridSize();
            eGameMode gameMode = UserInterface.GetGameMode();
            
            this.setPlayers(gameMode);
            while (shouldPlayAnotherRound)
            {
                this.m_ActiveGame = new Game(gridSize, this.m_Players);
                this.m_ActiveGame.Play();
                shouldPlayAnotherRound = UserInterface.GetWhetherToPlayAnotherRound();
            }
            
            ConsoleInterface.WaitForUserInput();
        }
    }
}
