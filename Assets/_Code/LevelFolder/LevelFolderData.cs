using System.Collections.Generic;
using _Code.Game.Block;

namespace _Code.LevelFolder
{
    public struct LevelFolderData
    {
        public int LevelNumber;
        public int GridWidth;
        public int GridHeight;
        public int MoveCount;
        public List<BlockType> Grid;

        public LevelFolderData(int levelNumber, int gridWidth, int gridHeight, int moveCount, List<BlockType> grid)
        {
            LevelNumber = levelNumber;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            MoveCount = moveCount;
            Grid = grid;
        }
    }
}