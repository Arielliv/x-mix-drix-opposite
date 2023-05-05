namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class Grid
    {
        private int m_Size;
        private Cell[,] gridMatrix;

        public Grid(int i_Size)
        {
            this.m_Size = i_Size;
            this.gridMatrix = new Cell[m_Size, m_Size];
        }
    }
}
