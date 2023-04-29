using _Code.LevelFolder;
using TMPro;
using UnityEngine;

namespace _Code.Game.UI
{
    public class HiScoreValuePanel : MonoBehaviour
    {
        private int _hiScore;
        private int _level;
        private TextMeshProUGUI _hiScoreText;

        private void Awake()
        {
            CacheComponents();
            SetPlayerPrefs();
            UpdateHiScoreText();
        }

        private void CacheComponents()
        {
            _level = LevelFolderDataHolder.Instance.LevelFolderData.LevelNumber;
            _hiScore = PlayerPrefs.GetInt("HS_" + _level);
            _hiScoreText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void SetPlayerPrefs()
        {
            if (!PlayerPrefs.HasKey("HS_" + _level))
            {
                PlayerPrefs.SetInt("HS_" + _level, 0);
            }
        }

        private void UpdateHiScoreText()
        {
            _hiScoreText.text = _hiScore.ToString();
        }
    }
}