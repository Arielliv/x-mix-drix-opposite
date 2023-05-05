namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class GameController
    {
        private Player[] m_Players = new Player[2];
        private Game m_ActiveGame;

        public void PlayGame()
        {
            int gridSize = UserInterface.GetGridSize();
            eGameMode gameMode = UserInterface.GetGameMode();
            this.m_ActiveGame = new Game(gridSize);
            ConsoleInterface.ShowGameGrid(this.m_ActiveGame.Grid);





            ConsoleInterface.WaitForUserInput();

        }


    }
}
