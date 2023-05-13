namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class Grid
    {
        private Cell[,] m_GridMatrix;
        private int m_AmountOfAvailableCells;
        public const int k_MinGridSize = 3;
        public const int k_MaxGridSize = 9;

        public int AmountOfAvialibleCell
        {
            get { return this.m_AmountOfAvailableCells; }
        }

        public Grid(int i_Size)
        {
            this.m_GridMatrix = new Cell[i_Size, i_Size];
            this.m_AmountOfAvailableCells = i_Size * i_Size;
            for (int x = 0; x < i_Size; x++)
            {
                for (int y = 0; y < i_Size; y++)
                {
                    this.m_GridMatrix[x, y].Mark = eMarks.Empty;
                }
            }
        }

        public int GetGridSize()
        {
            return this.m_GridMatrix.GetLength(0);
        }

        public eMarks GetCellContent(int i_X, int i_Y)
        {
            return this.m_GridMatrix[i_X, i_Y].Mark;
        }

        public bool IsCellEmpty(int i_X, int i_Y)
        {
            return this.m_GridMatrix[i_X, i_Y].IsEmpty();
        }

        public void SetCellMark(int i_X, int i_Y, eMarks i_NewMark) 
        {
            this.m_GridMatrix[i_X, i_Y].Mark = i_NewMark;
            this.m_AmountOfAvailableCells--;
        }

        public bool IsNextMoveValid(int i_X, int i_Y)
        {
            int gridSize = this.GetGridSize();

            return i_X < gridSize && i_X >= 0
                && i_Y < gridSize && i_Y >= 0
                && this.IsCellEmpty(i_X, i_Y);
        }
    }
}
