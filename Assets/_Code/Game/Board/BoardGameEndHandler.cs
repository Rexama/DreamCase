using System;
using _Code.LevelFolder;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Code.Game.Board
{
    public class BoardGameEndHandler : MonoBehaviour
    {
        private int _moveCount;
        private BoardScoreHandler _boardScoreHandler;

        private void Awake()
        {
            _moveCount = LevelFolderDataHolder.Instance.LevelFolderData.MoveCount;
            _boardScoreHandler = GetComponent<BoardScoreHandler>();
        }

        public void CheckGameEnd()
        {
            _moveCount--;
            
            if(_moveCount == 0)
                EndGame();
        }
        
        private void EndGame()
        {
            var level = LevelFolderDataHolder.Instance.LevelFolderData.LevelNumber;
            
            
            

            if (PlayerPrefs.HasKey("HS_" + level))
            {
                if(PlayerPrefs.GetInt("HS_" + level) < _boardScoreHandler.Score)
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

            SceneManager.LoadScene("MainScene");
        }
    }
}