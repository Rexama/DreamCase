using System;
using System.Collections.Generic;
using _Code.Game.Block;
using _Code.LevelFolder;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace _Code.Game.Board
{
    public class Board : MonoBehaviour
    {
        [SerializeField] GameObject blockPrefab;

        public BlockItem[] Blocks { get; private set; }
        
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

            var parentPos = new Vector3((_levelData.GridWidth - 1) * -0.5f, (_levelData.GridHeight - 1) * -0.5f, 90);
            _blocksParent.transform.position = parentPos;
            
            for (int row = 0; row < _levelData.GridHeight; row++)
            {
                for (int col = 0; col < _levelData.GridWidth; col++)
                {
                    var pos = new Vector2(col, row);
                    var block = Instantiate(blockPrefab, _blocksParent).GetComponent<BlockItem>();
                    block.PrepareBlock(_levelData.Grid[row * _levelData.GridWidth + col], pos);

                    block.name = "Block " + row + "," + col;
                    Blocks[row * _levelData.GridWidth + col] = block;
                }
            }
        }
        
        public BlockItem GetBlockNeighbour(BlockItem block, Direction direction)
        {
            var index = Array.IndexOf(Blocks, block);
            
            switch (direction)
            {
                case Direction.Right when index != Blocks.Length && index % _levelData.GridWidth != _levelData.GridWidth - 1:
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
    }
}