namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class Grid
    {
        //private int m_Size;
        private Cell[,] gridMatrix;

        public Grid(int i_Size)
        {
            //this.m_Size = i_Size;
            this.gridMatrix = new Cell[i_Size, i_Size];
            for(int x =0; x < i_Size; x++)
            {
                for (int y = 0; y < i_Size; y++)
                {
                    this.gridMatrix[x, y].Mark = eMark.Empty;
                }
            }
        }

        public int getGridSize()
        {
            return this.gridMatrix.GetLength(0);
        }

        public eMark getCellContent(int i_X, int i_Y)
        {
            return this.gridMatrix[i_X, i_Y].Mark;
        }
    }
}
