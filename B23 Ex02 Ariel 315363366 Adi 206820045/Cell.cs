namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public enum eMark
    {
        X = 'X',
        O = 'O',
        Empty = ' '
    }

    public struct Cell
    {
        private eMark m_Mark;

        public eMark Mark
        {
            get { return m_Mark; }
            set { m_Mark = value; }
        }

        public Cell(eMark i_Mark) 
        {
            this.m_Mark = i_Mark;
        }

        public bool IsEmpty()
        {
            return this.m_Mark == eMark.Empty;
        }
    }
}
