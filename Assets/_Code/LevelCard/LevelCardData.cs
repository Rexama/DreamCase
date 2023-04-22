namespace _Code.LevelCard
{
    public struct LevelCardData
    {
        public int Level;
        public int Moves;
        public int HighScore;
        public bool IsLocked;
        
        public LevelCardData(int level, int moves, int highScore, bool isLocked)
        {
            Level = level;
            Moves = moves;
            HighScore = highScore;
            IsLocked = isLocked;
        }
    }
}