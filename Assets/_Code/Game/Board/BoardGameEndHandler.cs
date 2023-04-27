using System.Collections.Generic;
using _Code.Game.Block;
using _Code.Game.UI;
using _Code.LevelFolder;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Code.Game.Board
{
    public class BoardGameEndHandler : MonoBehaviour
    {
        [SerializeField] private GameObject tapToContinueText;
        
        private int _moveCount;
        private Board _board;
        private BoardScoreHandler _boardScoreHandler;
        private TapToContinueText _tapToContinueText;
        

        private void Awake()
        {
            _moveCount = LevelFolderDataHolder.Instance.LevelFolderData.MoveCount;
            _boardScoreHandler = GetComponent<BoardScoreHandler>();
            _board = GetComponent<Board>();
        }

        public void TryGameEnd()
        {
            _moveCount--;
            if(_moveCount == 0 || IsGameEnd())
            {
                EndGame();
            }
        }
        
        private void EndGame()
        {
            ManagePlayerPrefs();
            tapToContinueText.SetActive(true);
            
        }

        private void ManagePlayerPrefs()
        {
            var level = LevelFolderDataHolder.Instance.LevelFolderData.LevelNumber;

            if (level >= PlayerPrefs.GetInt("LatestUnlockedLevel"))
                PlayerPrefs.SetInt("LatestUnlockedLevel", level + 1);

            if (PlayerPrefs.HasKey("HS_" + level))
            {
                if (PlayerPrefs.GetInt("HS_" + level) < _boardScoreHandler.Score)
                {
                    PlayerPrefs.SetInt("HS_" + level, _boardScoreHandler.Score);
                    PlayerPrefs.SetInt("New_HS", _boardScoreHandler.Score);
                }
                else
                {
                    PlayerPrefs.SetInt("New_HS", 0);
                }
            }
            else
            {
                PlayerPrefs.SetInt("HS_" + level, _boardScoreHandler.Score);
                PlayerPrefs.SetInt("New_HS", _boardScoreHandler.Score);
            }
        }

        private bool IsGameEnd()
        {
            var width = _board.LevelData.GridWidth;
            var blocksMatrix = _board.Blocks;
            var islandBlockTypeCounts = new Dictionary<BlockType, int>();
            var rowBlockCounts = _board.RowBlockCounts;
            
            bool flag = false;
            for (int i = 0; i < blocksMatrix.Length; i+=width) //for each row
            {
                if (blocksMatrix[i].BlockType == BlockType.Complete) //row is Completed
                {
                    if (islandBlockTypeCounts.Count == 0)
                    {
                        continue;
                    }
                    bool isEnoughBlock = false;
                    foreach (var blockType in islandBlockTypeCounts.Keys)
                    {
                        if (islandBlockTypeCounts[blockType] >= width)
                        {
                            isEnoughBlock = true;
                            break;
                        }
                    }
                    flag |= isEnoughBlock;
                    islandBlockTypeCounts.Clear();
                    continue;
                }
                var rowIndex = i / width;
                foreach (var blockType in rowBlockCounts[rowIndex].Keys)//row is not Completed
                {
                    if (islandBlockTypeCounts.ContainsKey(blockType))
                    {
                        islandBlockTypeCounts[blockType] += rowBlockCounts[rowIndex][blockType];
                    }
                    else
                    {
                        islandBlockTypeCounts.Add(blockType, rowBlockCounts[rowIndex][blockType]);
                    }
                }
            }
            if (islandBlockTypeCounts.Count != 0) //after all rows has been iterated
            {
                bool isEnoughBlock = false;
                foreach (var blockType in islandBlockTypeCounts.Keys)
                {
                    if (islandBlockTypeCounts[blockType] > width)
                    {
                        isEnoughBlock = true;
                        break;
                    }
                }
                flag |= isEnoughBlock;
                islandBlockTypeCounts.Clear();
            }
            if (flag)
            {
                return false;
            }
            else
            {
                Debug.Log("Game ended, no more moves possible");
                return true;
            }
        }
    }
}