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
            return type switch
            {
                BlockType.Red => redBlockSprite,
                BlockType.Green => greenBlockSprite,
                BlockType.Blue => blueBlockSprite,
                BlockType.Yellow => yellowBlockSprite,
                BlockType.Complete => tickBlockSprite,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}