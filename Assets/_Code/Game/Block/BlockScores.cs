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
            return blockType switch
            {
                BlockType.Red => redBlockScore,
                BlockType.Green => greenBlockScore,
                BlockType.Blue => blueBlockScore,
                BlockType.Yellow => yellowBlockScore,
                _ => 0
            };
        }
    }
}