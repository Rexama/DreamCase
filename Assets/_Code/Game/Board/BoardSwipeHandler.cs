using System.Collections.Generic;
using _Code.Game.Block;
using UnityEngine;

namespace _Code.Game.Board
{
    public class BoardSwipeHandler : MonoBehaviour
    {
        [SerializeField] float minSwipeDistance = 25f;

        private Board _board;

        private Vector2 _swipeStartPos;
        private bool _isSwiping = false;
        private bool _canSwipe = true;
        private BlockItem _selectedBlockItem;


        private void Awake()
        {
            _board = GetComponent<Board>();
        }

        private void Update()
        {
            HandleMouseInput();
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

            var hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) as BoxCollider2D;

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
                TrySwapBlocks(_selectedBlockItem, swipeDirection.x > 0 ? Direction.Right : Direction.Left);
            }
            else
            {
                TrySwapBlocks(_selectedBlockItem, swipeDirection.y > 0 ? Direction.Up : Direction.Down);
            }
            _isSwiping = false;
        }

        public void TrySwapBlocks(BlockItem blockItem, Direction direction)
        {
            var blocks = _board.Blocks;
            var levelData = _board.LevelData;

            var index = blocks.IndexOf(blockItem);
            BlockItem otherBlock;

            switch (direction)
            {
                case Direction.Right when index != blocks.Count:
                    otherBlock = blocks[index + 1];
                    break;
                case Direction.Left when index != 0:
                    otherBlock = blocks[index - 1];
                    break;
                case Direction.Up when index < blocks.Count - levelData.GridWidth:
                    otherBlock = blocks[index + levelData.GridWidth];
                    break;
                case Direction.Down when index >= levelData.GridWidth:
                    otherBlock = blocks[index - levelData.GridWidth];
                    break;
                default:
                    return;
            }

            SwipeBlocks(blockItem, blocks, otherBlock, index);
        }

        private static void SwipeBlocks(BlockItem blockItem, List<BlockItem> blocks, BlockItem otherBlock, int index)
        {
            var tempPos = blockItem.transform.position;
            var otherIndex = blocks.IndexOf(otherBlock);

            blockItem.DoSwipeBlock(otherBlock.transform.position);
            otherBlock.DoSwipeBlock(tempPos);

            blocks[index] = otherBlock;
            blocks[otherIndex] = blockItem;
        }
    }
}