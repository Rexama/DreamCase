using System;
using UnityEngine;

namespace _Code.Game.Block
{
    [CreateAssetMenu(fileName = "BlockSprites", menuName = "Data/BlockSprites", order = 0)]
    public class BlockSprites : ScriptableObject
    {
        public Sprite redBlockSprite;
        public Sprite greenBlockSprite;
        public Sprite blueBlockSprite;
        public Sprite yellowBlockSprite;
        public Sprite tickBlockSprite;
        
        public Sprite GetSprite(BlockType type)
        {
            switch (type)
            {
                case BlockType.Red:
                    return redBlockSprite;
                case BlockType.Green:
                    return greenBlockSprite;
                case BlockType.Blue:
                    return blueBlockSprite;
                case BlockType.Yellow:
                    return yellowBlockSprite;
                case BlockType.Complete:
                    return tickBlockSprite;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
    
    
}