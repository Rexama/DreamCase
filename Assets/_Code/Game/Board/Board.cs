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
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject blockPrefab;

        private Transform _cellsParent;
        private Transform _blocksParent;

        private Border _border;
        //private Cell[,] _cells;
        private List<BlockItem> _blocks = new List<BlockItem>();
        public List<BlockItem> Blocks => _blocks;

        private LevelFolderData _levelData;
        public LevelFolderData LevelData => _levelData;
        

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
            _levelData = LevelFolderReader.ReadLevelData("Assets/Resources/Levels/RM_A3");
            _cellsParent = transform.Find("Cells");
            _blocksParent = transform.Find("Blocks");
        }

        private void PrepareBoard()
        {
            _border.SetBorderSize(_levelData.GridWidth, _levelData.GridHeight);
            
            var parentPos = new Vector3((_levelData.GridWidth - 1) * -0.5f, (_levelData.GridHeight - 1) * -0.5f, 0);
            _cellsParent.transform.position = parentPos;
            _blocksParent.transform.position = parentPos;

            //_cells = new Cell[_levelData.GridHeight, _levelData.GridWidth];

            for (int row = 0; row < _levelData.GridHeight; row++)
            {
                for (int col = 0; col < _levelData.GridWidth; col++)
                {
                    var pos = new Vector2(col, row);
                    // var cell = Instantiate(cellPrefab, _cellsParent).GetComponent<Cell>();
                    // cell.PrepareCell(pos);
                    // _cells[row, col] = cell;
                    
                    var block = Instantiate(blockPrefab, _blocksParent).GetComponent<BlockItem>();
                    block.PrepareBlock(_levelData.Grid[row * _levelData.GridWidth + col], pos);
                    
                    block.name = "Block " + row + "," + col;
                    _blocks.Add(block);
                }
            }

        }
    }
}