namespace B23_Ex02_Ariel_315363366_Adi_206820045
{
    class GameSettingsValidators
    {
        public static bool IsValidGridSize(int i_GridSize)
        {
            return i_GridSize >= Grid.k_MinGridSize && i_GridSize <= Grid.k_MaxGridSize;
        }
    }
}
