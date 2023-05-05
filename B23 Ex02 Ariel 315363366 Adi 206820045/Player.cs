namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    public enum ePlayerType
    {
        Computer,
        Person
    }

    public enum eMark
    {
        X,
        O,
        Empty
    }

    class Player
    {
        private ePlayerType m_type;
        private eMark m_mark;
        private int m_score = 0;

        public Player(ePlayerType i_type, eMark i_mark)
        {
            this.m_type = i_type;
            this.m_mark = i_mark;
        }
    }
}
