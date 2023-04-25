using UnityEngine;

namespace _Code.Game.Block
{
    [CreateAssetMenu(fileName = "BlockScores", menuName = "Data/BlockScores", order = 0)]
    public class BlockScores : ScriptableObject
    {
        public int redBlockScore;
        public int greenBlockScore;
        public int blueBlockScore;
        public int yellowBlockScore;

        public int GetBlockScore(BlockType blockType)
        {
            switch (blockType)
            {
                case BlockType.Red:
                    return redBlockScore;
                case BlockType.Green:
                    return greenBlockScore;
                case BlockType.Blue:
                    return blueBlockScore;
                case BlockType.Yellow:
                    return yellowBlockScore;
                default:
                    return 0;
            }
        }
    }
}