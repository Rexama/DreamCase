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

        private BlockItem[] _blocks;
        public BlockItem[] Blocks => _blocks;

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
            _levelData = LevelFolderReader.ReadLevelData("Assets/Resources/Levels/RM_A2");
            _blocksParent = transform.Find("Blocks");
            _blocks = new BlockItem[_levelData.GridWidth * _levelData.GridHeight];
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
                    _blocks[row * _levelData.GridWidth + col] = block;
                }
            }
        }
        
        public BlockItem GetBlockNeighbour(BlockItem block, Direction direction)
        {
            var index = Array.IndexOf(_blocks, block);
            
            switch (direction)
            {
                case Direction.Right when index != _blocks.Length:
                    return _blocks[index + 1];
                case Direction.Left when index != 0:
                    return _blocks[index - 1];
                case Direction.Up when index < _blocks.Length - _levelData.GridWidth:
                    return _blocks[index + _levelData.GridWidth];
                case Direction.Down when index >= _levelData.GridWidth:
                    return _blocks[index - _levelData.GridWidth];
                default:
                    return null;
            }
        }
    }
}