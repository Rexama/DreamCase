using System;
using _Code.Tools;
using DG.Tweening;
using UnityEngine;

namespace _Code.Game.Block
{
    public class BlockItem : MonoBehaviour
    {
        public BlockType BlockType { get; private set; }

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
            _spriteRenderer.sortingOrder = (int) (pos.y + 5);
            _spriteRenderer.sprite = _blockSprites.GetSprite(blockType);
            BlockType = blockType;
        }

        public void DoSwipeBlock(Vector2 position, float duration)
        {
            transform.DOMove(position, duration).OnComplete(() =>
            {
                var localPosition = transform.localPosition;
                _spriteRenderer.sortingOrder = (int) Math.Round(localPosition.y + 5);
            });
        }

        public void DoPunchBlock(Direction direction)
        {
            var punch = direction.GetDirectionVector() * 0.25f;
            transform.DOPunchPosition(punch, 0.3f, 10, 0.1f);
        }

        public void CompleteBlock()
        {
            _spriteRenderer.sprite = _blockSprites.GetSprite(BlockType.Complete);
            _spriteRenderer.transform.localScale = Vector3.one * 4f;
            BlockType = BlockType.Complete;
            _collider2D.enabled = false;
        }
    }
}