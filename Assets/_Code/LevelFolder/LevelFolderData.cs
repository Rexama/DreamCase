namespace _Code.LevelFolder
{
    public struct LevelFolderData
    {
        public int LevelNumber;
        public int GridWidth;
        public int GridHeight;
        public int MoveCount;
        public string[] Grid;

        public LevelFolderData(int levelNumber, int gridWidth, int gridHeight, int moveCount, string[] grid)
        {
            LevelNumber = levelNumber;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            MoveCount = moveCount;
            Grid = grid;
        }
    }
}