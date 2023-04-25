using System;
using _Code.LevelFolder;
using TMPro;
using UnityEngine;

namespace _Code.Game.UI
{
    public class HiScoreValuePanel : MonoBehaviour
    {
        private int _hiScore;
        private TextMeshProUGUI _hiScoreText;

        private void Awake()
        {
            CacheComponents();
            UpdateHiScoreText();
        }

        private void CacheComponents()
        {
            var level = LevelFolderDataHolder.Instance.LevelFolderData.LevelNumber;

            if (!PlayerPrefs.HasKey("HS_" + level))
            {
                PlayerPrefs.SetInt("HS_" + level, 0);
            }

            _hiScore = PlayerPrefs.GetInt("HS_" + level);

            _hiScoreText = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        private void UpdateHiScoreText()
        {
            _hiScoreText.text = _hiScore.ToString();
        }
    }
}