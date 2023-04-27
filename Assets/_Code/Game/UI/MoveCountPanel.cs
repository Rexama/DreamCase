using _Code.Game.Board;
using _Code.LevelFolder;
using TMPro;
using UnityEngine;

namespace _Code.Game.UI
{
    public class MoveCountPanel : MonoBehaviour
    {
        private int _moveCount;
        private TextMeshProUGUI _moveCountText;

        private void Awake()
        {
            BoardSwipeHandler.OnSwipe += DecreaseMoveCount;
            
            CacheComponents();
            UpdateMoveCountText();
        }

        private void OnDisable()
        {
            BoardSwipeHandler.OnSwipe -= DecreaseMoveCount;
        }

        private void CacheComponents()
        {
            _moveCountText = GetComponentInChildren<TextMeshProUGUI>();
            _moveCount = LevelFolderDataHolder.Instance.LevelFolderData.MoveCount;
        }

        private void UpdateMoveCountText()
        {
            _moveCountText.text = _moveCount.ToString();
        }
        
        private void DecreaseMoveCount()
        {
            _moveCount--;
            UpdateMoveCountText();
        }
    }
}