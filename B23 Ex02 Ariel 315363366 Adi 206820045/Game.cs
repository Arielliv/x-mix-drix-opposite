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
        private int m_LeftoverMovesCount;
        private Player[] m_Players;
        private int m_ActivePlayerIndex = 0;

        public Game(int i_GridSize, Player[] i_Players)
        {
            this.m_Grid = new Grid(i_GridSize);
            this.m_LeftoverMovesCount = i_GridSize * i_GridSize;
            this.m_Players = i_Players;
        }

        private void setNextMoveCell(int i_X, int i_Y, eMark i_NewMark)
        {
            this.m_Grid.SetCellMark(i_X, i_Y, i_NewMark);
            this.m_LeftoverMovesCount--;
        }

        private bool isNextMoveValid(int i_X, int i_Y)
        {
            return i_X < this.m_Grid.GetGridSize() && i_X >= 0 
                && i_Y < this.m_Grid.GetGridSize() && i_Y >= 0 
                && this.m_Grid.IsCellEmpty(i_X, i_Y);
        }

        private bool isVictory(eMark i_PlayerMark)
        {
            return this.isSequenceInRow(i_PlayerMark) 
                || this.isSequenceInCol(i_PlayerMark) 
                || this.isSequenceInDiagonal(i_PlayerMark); 
        }

        private bool isSequenceInRow(eMark i_PlayerMark)
        {
            bool isSequenceInRowFound = true;
            int gridSize = this.m_Grid.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                isSequenceInRowFound = true;
                for (int y = 0; y < gridSize; y++)
                {
                    eMark currenctCellContent = this.m_Grid.GetCellContent(x, y);

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
            int gridSize = this.m_Grid.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                isSequenceInColFound = true;
                for (int y = 0; y < gridSize; y++)
                {
                    eMark currenctCellContent = this.m_Grid.GetCellContent(y, x);

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
            return this.isSequenceInLeftDiagonal(i_PlayerMark) 
                || this.isSequenceInRightDiagonal(i_PlayerMark);
        }

        private bool isSequenceInLeftDiagonal(eMark i_PlayerMark) {
            bool isSequenceInDiagonalFound = true;
            int gridSize = this.m_Grid.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                eMark currenctCellContent = this.m_Grid.GetCellContent(x, x);
                
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
            int gridSize = this.m_Grid.GetGridSize();

            for (int x = gridSize - 1; x >= 0; x--)
            {
                eMark currenctCellContent = this.m_Grid.GetCellContent(gridSize - 1 - x, x);
               
                if (currenctCellContent != i_PlayerMark)
                {
                    isSequenceInDiagonalFound = false;
                    break;
                }
            }

            return isSequenceInDiagonalFound;
        }

        private int[] getComputerNextMove()
        {
            int[] result = null;
            Random random = new Random();
            int range = this.m_Grid.AmountOfAvialibleCell;
            int randomCellIndex = random.Next(1, range);
            int emptyCellCounter = 0;
            int gridSize = this.m_Grid.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                for(int y = 0; y < gridSize; y++)
                {
                    if (this.m_Grid.IsCellEmpty(x, y))
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

        private int[] getNextPlayerMove(ePlayerType i_CurrenctPlayerType)
        {
            int gridSize = this.m_Grid.GetGridSize();
            bool isNextMoveValid = false;
            int[] nextMove = null;

            while (!isNextMoveValid)
            {
                if (i_CurrenctPlayerType == ePlayerType.Person)
                {
                    nextMove = UserInterface.GetPlayerNextMove(gridSize);
                }
                else
                {
                    nextMove = this.getComputerNextMove();
                }
                
                if (nextMove[0] == -1 || this.isNextMoveValid(nextMove[0], nextMove[1]))
                {
                    isNextMoveValid = true;
                }
                else
                {
                    ConsoleInterface.ShowMessageWhenInvalidCellIndex(gridSize);
                }
            }

            return nextMove;
        }

        private bool shouldQuit(int[] i_PlayerNextMove)
        {
            return  i_PlayerNextMove != null && i_PlayerNextMove[0] == -1;
        }

        private bool applyNextMove(int[] i_NextMove)
        {
            bool isVictory;
            eMark activePlayerMark = this.getActivePlayer().Mark;

            this.setNextMoveCell(i_NextMove[0], i_NextMove[1], activePlayerMark);
            isVictory = this.isVictory(activePlayerMark);
            ConsoleInterface.ShowGameGrid(this.m_Grid);
            if (!isVictory)
            {
                this.setNextActivePlayer();
            }

            return isVictory;
        }

        private void handleEndGame(bool i_IsVictory)
        {
            if (this.m_LeftoverMovesCount == 0)
            {
                ConsoleInterface.ShowMessageWhenGameOverWithTie();
                ConsoleInterface.ShowMessageWithPlayersScore(this.m_Players);
            }

            if (i_IsVictory)
            {
                ConsoleInterface.ShowGameGrid(this.m_Grid);
                this.setNextActivePlayer();
                this.getActivePlayer().Score++;
                ConsoleInterface.ShowMessageWhenGameOverWithWin(this.getActivePlayer().Mark);
                ConsoleInterface.ShowMessageWithPlayersScore(this.m_Players);
            }
        }

        private Player getActivePlayer()
        {
            return this.m_Players[this.m_ActivePlayerIndex];
        }

        private void setNextActivePlayer()
        {
            this.m_ActivePlayerIndex = Math.Abs(this.m_ActivePlayerIndex - 1);
        }

        public bool Play()
        {
            bool isVictory = false;
            int[] nextMove = null;
            bool isQuit = false;

            ConsoleInterface.ShowGameGrid(this.m_Grid);
            while (!isVictory && this.m_LeftoverMovesCount > 0 && !this.shouldQuit(nextMove))
            {
                nextMove = getNextPlayerMove(this.getActivePlayer().Type);
                isQuit = this.shouldQuit(nextMove);
                if (!isQuit) {
                    isVictory = this.applyNextMove(nextMove);
                }
            }

            if (!isQuit)
            {
                this.handleEndGame(isVictory);
            }

            return isQuit; 
        }
    }
}
