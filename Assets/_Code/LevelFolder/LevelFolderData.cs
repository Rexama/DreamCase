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
    }
}