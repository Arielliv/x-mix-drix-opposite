namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public enum eGameMode
    {
        TwoPlayers,
        AgainstComputer
    }
    class Game
    {
        //private Player m_CurrentPlayer;
        private Grid m_Grid;
    
        public Grid Grid
        {
            get { return m_Grid; }
        }

        public Game(int gridSize)
        {
            this.m_Grid = new Grid(gridSize);
        }
    }
}
