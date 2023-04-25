using System;
using DG.Tweening;
using UnityEngine;

namespace _Code.Game.Block
{
    public class BlockItem : MonoBehaviour
    {
        private BlockType _blockType;
        public BlockType BlockType => _blockType;
        
        private BlockSprites _blockSprites;
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider2D;

        private void Awake()
        {
            CacheComponents();
        }

        private void CacheComponents()
        {
            _blockSprites = Resources.Load<BlockSprites>("BlockSprites");
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _collider2D = GetComponent<Collider2D>();
        }

        public void PrepareBlock(BlockType blockType, Vector2 pos)
        {
            transform.localPosition = pos;
            _spriteRenderer.sortingOrder = (int) (transform.localPosition.y + 5);
            _spriteRenderer.sprite = _blockSprites.GetSprite(blockType);
            _blockType = blockType;
        }
        
        public void DoSwipeBlock(Vector2 position, float duration)
        {
            transform.DOMove(position, duration).OnComplete(() =>
            {
                _spriteRenderer.sortingOrder = (int) (transform.localPosition.y + 5);
            });
        }
        
        public void CompleteBlock()
        {
            _spriteRenderer.sprite = _blockSprites.GetSprite(BlockType.Complete);
            _spriteRenderer.transform.localScale = Vector3.one * 4f;
            _blockType = BlockType.Complete;
            _collider2D.enabled = false;
        }
    }
}
