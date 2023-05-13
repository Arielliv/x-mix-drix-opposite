namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public enum eMarks
    {
        X = 'X',
        O = 'O',
        Empty = ' '
    }

    public struct Cell
    {
        private eMarks m_Mark;

        public eMarks Mark
        {
            get { return m_Mark; }
            set { m_Mark = value; }
        }

        public Cell(eMarks i_Mark) 
        {
            this.m_Mark = i_Mark;
        }

        public bool IsEmpty()
        {
            return this.m_Mark == eMarks.Empty;
        }
    }
}
