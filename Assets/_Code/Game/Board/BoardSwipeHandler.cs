using System;
using _Code.Game.Block;
using _Code.Tools;
using DG.Tweening;
using UnityEngine;

namespace _Code.Game.Board
{
    public class BoardSwipeHandler : MonoBehaviour
    {
        [SerializeField] float minSwipeDistance = 25f;
        [SerializeField] float swipeDuration = 0.5f;

        private Board _board;
        private Camera _camera;
        private BoardScoreHandler _boardScoreHandler;

        private bool _canSwipe = true;
        private Vector2 _swipeStartPos;
        private bool _isSwiping = false;
        private BlockItem _selectedBlockItem;

        public static Action OnSwipe;

        private void Awake()
        {
            CacheComponents();
        }

        private void CacheComponents()
        {
            _board = GetComponent<Board>();
            _camera = Camera.main;
            _boardScoreHandler = GetComponent<BoardScoreHandler>();
        }

        private void Update()
        {
            if (_canSwipe) HandleMouseInput();
        }

        void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastMousePosition();
            }

            if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
            {
                HandleSwipe();
            }
        }

        private void RaycastMousePosition()
        {
            _swipeStartPos = Input.mousePosition;

            var hit = Physics2D.OverlapPoint(_camera.ScreenToWorldPoint(Input.mousePosition)) as BoxCollider2D;

            if (hit != null)
            {
                _selectedBlockItem = hit.gameObject.GetComponent<BlockItem>();
                _isSwiping = true;
            }
        }

        private void HandleSwipe()
        {
            Vector2 swipeEndPos = Input.mousePosition;
            var swipeDistance = Vector2.Distance(_swipeStartPos, swipeEndPos);

            if (!_isSwiping || !(swipeDistance > minSwipeDistance)) return;

            var swipeDirection = swipeEndPos - _swipeStartPos;

            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                TrySwipeBlocks(_selectedBlockItem, swipeDirection.x > 0 ? Direction.Right : Direction.Left);
            }
            else
            {
                TrySwipeBlocks(_selectedBlockItem, swipeDirection.y > 0 ? Direction.Up : Direction.Down);
            }

            _isSwiping = false;
        }


        private void TrySwipeBlocks(BlockItem blockItem, Direction direction)
        {
            var otherBlock = _board.GetBlockNeighbour(blockItem, direction);

            if (otherBlock != null && otherBlock.BlockType != BlockType.Complete)
            {
                SwipeBlocks(blockItem, otherBlock);
            }
            else
            {
                blockItem.DoPunchBlock(direction);
            }
        }

        private void SwipeBlocks(BlockItem blockItem, BlockItem otherBlock)
        {
            OnSwipe?.Invoke();

            var tempPos = blockItem.transform.position;

            blockItem.DoSwipeBlock(otherBlock.transform.position, swipeDuration);
            otherBlock.DoSwipeBlock(tempPos, swipeDuration);

            _board.UpdateBlocksArray(blockItem, otherBlock);

            _canSwipe = false;
            DOTween.Sequence().AppendInterval(swipeDuration).OnComplete(() =>
            {
                _boardScoreHandler.CheckSwappedBlockRows(blockItem, otherBlock);
                _canSwipe = true;
            });
        }
    }
}