using System;
using System.Collections.Generic;
using _Code.Game.Block;
using _Code.LevelFolder;
using UnityEngine;

namespace _Code.Game.Board
{
    public class Board : MonoBehaviour
    {
        [SerializeField] GameObject blockPrefab;

        public BlockItem[] Blocks { get; private set; }
        public readonly List<Dictionary<BlockType, int>> RowBlockCounts = new List<Dictionary<BlockType, int>>();

        private LevelFolderData _levelData;
        public LevelFolderData LevelData => _levelData;

        private Border _border;
        private Transform _blocksParent;

        private void Awake()
        {
            CacheComponents();
        }

        void Start()
        {
            PrepareBoard();
        }

        private void CacheComponents()
        {
            _border = GetComponentInChildren<Border>();
            _levelData = LevelFolderDataHolder.Instance.LevelFolderData;
            _blocksParent = transform.Find("Blocks");
            Blocks = new BlockItem[_levelData.GridWidth * _levelData.GridHeight];
        }

        private void PrepareBoard()
        {
            _border.SetBorderSize(_levelData.GridWidth, _levelData.GridHeight);

            var parentPos = new Vector3((_levelData.GridWidth - 1) * -0.5f, (_levelData.GridHeight - 1) * -0.5f, 0);
            _blocksParent.transform.localPosition = parentPos;

            for (int row = 0; row < _levelData.GridHeight; row++)
            {
                var newRowCounts = new Dictionary<BlockType, int>();
                for (int col = 0; col < _levelData.GridWidth; col++)
                {
                    var pos = new Vector2(col, row);
                    var block = Instantiate(blockPrefab, _blocksParent).GetComponent<BlockItem>();
                    block.PrepareBlock(_levelData.Grid[row * _levelData.GridWidth + col], pos);

                    block.name = "Block " + row + "," + col;
                    Blocks[row * _levelData.GridWidth + col] = block;

                    if (newRowCounts.ContainsKey(block.BlockType))
                    {
                        newRowCounts[block.BlockType]++;
                    }
                    else
                    {
                        newRowCounts.Add(block.BlockType, 1);
                    }
                }

                RowBlockCounts.Add(newRowCounts);
            }
        }

        public BlockItem GetBlockNeighbour(BlockItem block, Direction direction)
        {
            var index = Array.IndexOf(Blocks, block);

            switch (direction)
            {
                case Direction.Right
                    when index != Blocks.Length && index % _levelData.GridWidth != _levelData.GridWidth - 1:
                    return Blocks[index + 1];
                case Direction.Left when index != 0 && index % _levelData.GridWidth != 0:
                    return Blocks[index - 1];
                case Direction.Up when index < Blocks.Length - _levelData.GridWidth:
                    return Blocks[index + _levelData.GridWidth];
                case Direction.Down when index >= _levelData.GridWidth:
                    return Blocks[index - _levelData.GridWidth];
                default:
                    return null;
            }
        }

        public void UpdateBlocksArray(BlockItem block1, BlockItem block2)
        {
            var index1 = Array.IndexOf(Blocks, block1);
            var index2 = Array.IndexOf(Blocks, block2);

            var rowIndex1 = index1 / _levelData.GridWidth;
            var rowIndex2 = index2 / _levelData.GridWidth;

            RowBlockCounts[rowIndex1][block1.BlockType]--;
            RowBlockCounts[rowIndex2][block2.BlockType]--;

            AddToDictionary(block2.BlockType, rowIndex1);
            AddToDictionary(block1.BlockType, rowIndex2);
            
            Blocks[index1] = block2;
            Blocks[index2] = block1;
        }

        public void UpdateRowBlockCountsOnRowComplete(int rowStartIndex, BlockType blockType)
        {
            var rowIndex = rowStartIndex / _levelData.GridWidth;
            RowBlockCounts[rowIndex][blockType] -= _levelData.GridWidth;
        }

        private void AddToDictionary(BlockType blockType, int index)
        {
            if (RowBlockCounts[index].ContainsKey(blockType))
            {
                RowBlockCounts[index][blockType]++;
            }
            else
            {
                RowBlockCounts[index].Add(blockType, 1);
            }
        }
    }
}