using System;
using DG.Tweening;
using UnityEngine;

namespace _Code.Game.Block
{
    public class BlockItem : MonoBehaviour
    {
        private BlockType _blockType;
        private BlockSprites _blockSprites;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            CacheComponents();
        }

        private void CacheComponents()
        {
            _blockSprites = Resources.Load<BlockSprites>("BlockSprites");
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void PrepareBlock(BlockType blockType, Vector2 pos)
        {
            transform.localPosition = pos;
            _spriteRenderer.sortingOrder = (int) (transform.localPosition.y + 5);
            _spriteRenderer.sprite = _blockSprites.GetSprite(blockType);
        }
        
        public void DoSwipeBlock(Vector2 position)
        {
            transform.DOMove(position, 0.5f);
            _spriteRenderer.sortingOrder = (int) (transform.localPosition.y + 5);
            Debug.Log(position.y);
        }
    }
}
