using System;

namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public enum eGameMode
    {
        TwoPlayers,
        AgainstComputer
    }

    class Game
    {
        private Grid m_Grid;
    
        public Grid Grid
        {
            get { return m_Grid; }
        }

        public Game(int gridSize)
        {
            this.m_Grid = new Grid(gridSize);
        }

        public void setNextMoveCell(int i_X, int i_Y, eMark i_NewMark)
        {
            this.m_Grid.setCellMark(i_X, i_Y, i_NewMark);
        }

        public bool isNextMoveValid(int i_X, int i_Y)
        {
            return i_X < this.m_Grid.getGridSize() && i_X >= 0 
                && i_Y < this.m_Grid.getGridSize() && i_Y >= 0 
                && this.m_Grid.isCellEmpty(i_X, i_Y);
        }

        public bool isVictory(eMark i_PlayerMark)
        {
            return this.isSequenceInRow(i_PlayerMark) || this.isSequenceInCol(i_PlayerMark) || this.isSequenceInDiagonal(i_PlayerMark); 
        }

        private bool isSequenceInRow(eMark i_PlayerMark)
        {
            bool isSequenceInRowFound = true;

            for (int x = 0; x < this.m_Grid.getGridSize(); x++)
            {
                isSequenceInRowFound = true;
                for (int y = 0; y < this.m_Grid.getGridSize(); y++)
                {
                    eMark currenctCellContent = this.m_Grid.getCellContent(x, y);
                    if (currenctCellContent != i_PlayerMark)
                    {
                        isSequenceInRowFound = false;
                        break;
                    }
                }

                if (isSequenceInRowFound)
                {
                    break;
                }

            }
            return isSequenceInRowFound;
        }

        private bool isSequenceInCol(eMark i_PlayerMark)
        {
            bool isSequenceInColFound = true;

            for (int x = 0; x < this.m_Grid.getGridSize(); x++)
            {
                isSequenceInColFound = true;
                for (int y = 0; y < this.m_Grid.getGridSize(); y++)
                {
                    eMark currenctCellContent = this.m_Grid.getCellContent(y, x);
                    if (currenctCellContent != i_PlayerMark)
                    {
                        isSequenceInColFound = false;
                        break;
                    }
                }

                if (isSequenceInColFound)
                {
                    break;
                } 

            }
            return isSequenceInColFound;
        }

        private bool isSequenceInDiagonal(eMark i_PlayerMark)
        {
            return this.isSequenceInLeftDiagonal(i_PlayerMark) || this.isSequenceInRightDiagonal(i_PlayerMark);
        }

        private bool isSequenceInLeftDiagonal(eMark i_PlayerMark) {
            bool isSequenceInDiagonalFound = true;

            for (int x = 0; x < this.m_Grid.getGridSize(); x++)
            {
                eMark currenctCellContent = this.m_Grid.getCellContent(x, x);
                
                if (currenctCellContent != i_PlayerMark)
                {
                    isSequenceInDiagonalFound = false;
                    break;
                }
            }

            return isSequenceInDiagonalFound; 
        }

        private bool isSequenceInRightDiagonal(eMark i_PlayerMark)
        {
            bool isSequenceInDiagonalFound = true;

            for (int x = this.m_Grid.getGridSize() - 1; x > 0; x--)
            {
                eMark currenctCellContent = this.m_Grid.getCellContent(x, this.m_Grid.getGridSize() - 1 - x);
               
                if (currenctCellContent != i_PlayerMark)
                {
                    isSequenceInDiagonalFound = false;
                    break;
                }
            }

            return isSequenceInDiagonalFound;
        }

        public bool play(Player[] i_Players)
        {
            int activePlayerIndexInPlayersArray = 0;
            bool isVictory = false;
            int gridSize = this.m_Grid.getGridSize();
            int leftoverMovesCount = gridSize * gridSize;
            bool isNextMoveValid = false;
            int[] nextMove = null;
            bool isQuit = false;

            ConsoleInterface.ShowGameGrid(this.m_Grid);
            while (!isVictory && leftoverMovesCount > 0 && !isQuit)
            {
                while (!isNextMoveValid)
                {

                    nextMove = UserInterface.GetPlayerNextMove(gridSize);
                    if(nextMove[0] == -1)
                    {
                        isQuit = true;
                        break;
                    }
                    else if (this.isNextMoveValid(nextMove[0], nextMove[1]))
                    {
                        isNextMoveValid = true;
                    }
                    else
                    {
                        ConsoleInterface.ShowMessageWhenInvalidCellIndex(gridSize);
                    }
                }
                if (!isQuit) {
                    eMark activePlayerMark = i_Players[activePlayerIndexInPlayersArray].Mark;
                    this.setNextMoveCell(nextMove[0], nextMove[1], activePlayerMark);
                    leftoverMovesCount--;
                    isVictory = this.isVictory(activePlayerMark);
                    ConsoleInterface.ShowGameGrid(this.Grid);
                    if (!isVictory)
                    {
                        activePlayerIndexInPlayersArray = getNextActivePlayerIndex(activePlayerIndexInPlayersArray);
                        isNextMoveValid = false;
                    }
                }
            }

            if (!isQuit)
            {
                if (leftoverMovesCount == 0)
                {
                    ConsoleInterface.ShowMessageWhenGameOverWithTie();
                    ConsoleInterface.ShowMessageWithPlayersScore(i_Players);
                }
                if (isVictory)
                {
                    int winnerIndex = getNextActivePlayerIndex(activePlayerIndexInPlayersArray);
                    i_Players[winnerIndex].Score++;
                    ConsoleInterface.ShowMessageWhenGameOverWithWin(i_Players[winnerIndex].Mark);
                    ConsoleInterface.ShowMessageWithPlayersScore(i_Players);
                }
            }
            return isQuit;
            
        }

        private int getNextActivePlayerIndex(int i_CurrenctPlayerIndex)
        {
            return Math.Abs(i_CurrenctPlayerIndex - 1);
        }
    }
}
