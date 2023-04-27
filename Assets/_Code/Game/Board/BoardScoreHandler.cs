using System;
using _Code.Game.Block;
using UnityEngine;

namespace _Code.Game.Board
{
    public class BoardScoreHandler : MonoBehaviour
    {
        public int Score { get; private set; }

        private int _width;
        private Board _board;
        private BlockScores _blockScores;
        private BoardGameEndHandler _boardGameEndHandler;
        
        public static Action<int> OnRowCompleted;

        private void Start()
        {
            CacheComponents();
        }

        private void CacheComponents()
        {
            _board = GetComponent<Board>();
            _width = _board.LevelData.GridWidth;
            _boardGameEndHandler = GetComponent<BoardGameEndHandler>();
            _blockScores = Resources.Load<BlockScores>("BlockScores");
        }

        public void CheckSwappedBlockRows(int blockIndex1, int blockIndex2)
        {
            var rowFirstIndex1 = (blockIndex1 / _width) * _width;
            var rowFirstIndex2 = (blockIndex2 / _width) * _width;

            CheckSwappedBlockRow(rowFirstIndex1);

            if (rowFirstIndex1 != rowFirstIndex2)
            {
                CheckSwappedBlockRow(rowFirstIndex2);
            }
            _boardGameEndHandler.CheckGameEnd();
        }

        private void CheckSwappedBlockRow(int rowStartIndex)
        {
            var rowFirstBlockType = _board.Blocks[rowStartIndex].BlockType;
            for (int i = rowStartIndex + 1; i < rowStartIndex + _width; i++)
            {
                if (_board.Blocks[i].BlockType != rowFirstBlockType) return;
            }

            CompleteRow(rowStartIndex);
        }

        private void CompleteRow(int rowStartIndex)
        {
            var blockScore = _blockScores.GetBlockScore(_board.Blocks[rowStartIndex].BlockType);
            
            for (int i = rowStartIndex; i < rowStartIndex + _width; i++)
            {
                _board.Blocks[i].CompleteBlock();
            }
            
            OnRowCompleted?.Invoke(blockScore * _width);
            Score += blockScore * _width;
        }
    }
}