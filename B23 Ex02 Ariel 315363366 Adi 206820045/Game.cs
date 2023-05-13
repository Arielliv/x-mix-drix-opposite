using System;

namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public enum eGameModes
    {
        TwoPlayers,
        AgainstComputer
    }

    public class Game
    {
        private readonly Grid r_Grid;
        private int m_LeftoverMovesCount;

        public int LeftoverMovesCount
        {
            get { return this.m_LeftoverMovesCount; }
        }

        public Grid Grid
        {
            get { return this.r_Grid; }
        }

        public Game(int i_GridSize)
        {
            this.r_Grid = new Grid(i_GridSize);
            this.m_LeftoverMovesCount = i_GridSize * i_GridSize;
        }

        public int GetAmountOfAvialibleCell()
        {
            return this.r_Grid.AmountOfAvialibleCell;
        }

        public int GetGridSize()
        {
            return this.r_Grid.GetGridSize();
        }

        public bool IsCellEmpty(int i_X, int i_Y)
        {
            return this.r_Grid.IsCellEmpty(i_X, i_Y);
        }

        public void SetNextMoveCell(int i_X, int i_Y, eMarks i_NewMark)
        {
            this.r_Grid.SetCellMark(i_X, i_Y, i_NewMark);
            this.m_LeftoverMovesCount--;
        }

        public bool IsNextMoveValid(int i_X, int i_Y)
        {
            return this.r_Grid.IsNextMoveValid(i_X, i_Y);
        }

        public bool IsVictory(eMarks i_PlayerMark)
        {
            return this.isSequenceInRow(i_PlayerMark) 
                || this.isSequenceInCol(i_PlayerMark) 
                || this.isSequenceInDiagonal(i_PlayerMark); 
        }

        private bool isSequenceInRow(eMarks i_PlayerMark)
        {
            bool isSequenceInRowFound = true;
            int gridSize = this.r_Grid.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                isSequenceInRowFound = true;
                for (int y = 0; y < gridSize; y++)
                {
                    eMarks currenctCellContent = this.r_Grid.GetCellContent(x, y);

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

        private bool isSequenceInCol(eMarks i_PlayerMark)
        {
            bool isSequenceInColFound = true;
            int gridSize = this.r_Grid.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                isSequenceInColFound = true;
                for (int y = 0; y < gridSize; y++)
                {
                    eMarks currenctCellContent = this.r_Grid.GetCellContent(y, x);

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

        private bool isSequenceInDiagonal(eMarks i_PlayerMark)
        {
            return this.isSequenceInLeftDiagonal(i_PlayerMark) 
                || this.isSequenceInRightDiagonal(i_PlayerMark);
        }

        private bool isSequenceInLeftDiagonal(eMarks i_PlayerMark) {
            bool isSequenceInDiagonalFound = true;
            int gridSize = this.r_Grid.GetGridSize();

            for (int x = 0; x < gridSize; x++)
            {
                eMarks currenctCellContent = this.r_Grid.GetCellContent(x, x);
                
                if (currenctCellContent != i_PlayerMark)
                {
                    isSequenceInDiagonalFound = false;
                    break;
                }
            }

            return isSequenceInDiagonalFound; 
        }

        private bool isSequenceInRightDiagonal(eMarks i_PlayerMark)
        {
            bool isSequenceInDiagonalFound = true;
            int gridSize = this.r_Grid.GetGridSize();

            for (int x = gridSize - 1; x >= 0; x--)
            {
                eMarks currenctCellContent = this.r_Grid.GetCellContent(gridSize - 1 - x, x);
               
                if (currenctCellContent != i_PlayerMark)
                {
                    isSequenceInDiagonalFound = false;
                    break;
                }
            }

            return isSequenceInDiagonalFound;
        }
    }
}
