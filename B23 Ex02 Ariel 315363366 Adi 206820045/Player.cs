namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public enum ePlayerType
    {
        Computer,
        Person
    }

    class Player
    {
        private ePlayerType m_Type;
        private eMark m_Mark;
        private int m_Score = 0;

        public eMark Mark
        {
            get { return this.m_Mark; }
            set { this.m_Mark = value; }
        }

        public int Score
        {
            get { return this.m_Score; }
            set { this.m_Score = value; }
        }

        public ePlayerType Type
        {
            get { return this.m_Type; }
            set { this.m_Type = value; }
        }

        public Player(ePlayerType i_Type, eMark i_Mark)
        {
            this.m_Type = i_Type;
            this.m_Mark = i_Mark;
        }
    }
}
