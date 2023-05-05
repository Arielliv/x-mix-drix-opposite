namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    struct Cell
    {
        private eMark m_Mark;

        public Cell(eMark mark = eMark.Empty)
        {
           this.m_Mark = mark;
        }

        public eMark Mark
        {
            get { return m_Mark; }
            set { m_Mark = value; }
        }

        public bool IsEmpty()
        {
            return this.m_Mark == eMark.Empty;
        }
    }
}
