using System;

namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public class GameController
    {
        private readonly Player[] r_Players = new Player[2];
        private Game m_ActiveGame;
        private int m_ActivePlayerIndex = 0;

        public GameController(eGameModes i_GameMode)
        {
            this.setPlayers(i_GameMode);
        }

        public Grid GetGrid()
        {
            return this.m_ActiveGame.Grid;
        }

        public Player[] Players
        {
            get { return this.r_Players; }
        }

        public void InitNewGame(int i_GridSize)
        {
            this.m_ActiveGame = new Game(i_GridSize);
            this.m_ActivePlayerIndex = 0;
        }

        public void SetNextActivePlayer()
        {
            this.m_ActivePlayerIndex = Math.Abs(this.m_ActivePlayerIndex - 1);
        }

        private void setPlayers(eGameModes i_GameMode) {
            this.r_Players[0] = new Player(ePlayerTypes.Person, eMarks.X);
            if (i_GameMode == eGameModes.TwoPlayers)
            {
                this.r_Players[1] = new Player(ePlayerTypes.Person, eMarks.O);
            } 
            else
            {
                this.r_Players[1] = new Player(ePlayerTypes.Computer, eMarks.O);
            }
        }

        public Player GetActivePlayer()
        {
            return this.r_Players[this.m_ActivePlayerIndex];
        }

        public bool IsVictory()
        {
            return this.m_ActiveGame.IsVictory(this.GetActivePlayer().Mark);
        }

        public int[] GetComputerNextMove()
        {
            int[] result = null;
            Random random = new Random();
            int range = this.m_ActiveGame.GetAmountOfAvialibleCell();
            int randomCellIndex = random.Next(1, range);
            int emptyCellCounter = 0;
            int gridSize = this.m_ActiveGame.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (this.m_ActiveGame.IsCellEmpty(x, y))
                    {
                        emptyCellCounter++;
                        if (emptyCellCounter == randomCellIndex)
                        {
                            result = new int[] { x, y };
                            break;
                        }
                    }
                }

                if (emptyCellCounter == randomCellIndex)
                {
                    break;
                }
            }

            return result;
        }

        public void ApplyNextMove(int[] i_NextMove)
        {
            eMarks activePlayerMark = this.GetActivePlayer().Mark;

            this.m_ActiveGame.SetNextMoveCell(i_NextMove[0], i_NextMove[1], activePlayerMark);
        }

        public int GetLeftoverMovesCount()
        {
            return this.m_ActiveGame.LeftoverMovesCount;
        }
        
        public bool IsNextMoveValid (int[] i_NextMove)
        {
            return this.m_ActiveGame.IsNextMoveValid(i_NextMove[0], i_NextMove[1]);
        }
    }
}
