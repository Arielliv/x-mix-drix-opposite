namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class GameController
    {
        private Player[] m_Players = new Player[2];
        private Game m_ActiveGame;
        private UserInterface m_UserInterface;

        public void PlayGame()
        {
            UserInterface.WaitForUserInput();
        }

    }
}
