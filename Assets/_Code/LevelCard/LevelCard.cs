using _Code.Buttons;
using _Code.LevelFolder;
using TMPro;
using UnityEngine;

namespace _Code.LevelCard
{
    public class LevelCard : MonoBehaviour
    {
        private PlayButton _playButton;
        private TextMeshProUGUI _levelAndMovesText;
        private TextMeshProUGUI _highestScoreText;

        private void Awake()
        {
            CacheComponents();
        }

        private void CacheComponents()
        {
            _playButton = GetComponentInChildren<PlayButton>();
            _levelAndMovesText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _highestScoreText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        }

        public void SetUpLevelCard(LevelCardData levelCardData, LevelFolderData levelFolderData)
        {
            _levelAndMovesText.text = $"Level {levelCardData.Level} - {levelCardData.Moves} Moves";
            _playButton.SetLevelFolderData(levelFolderData);

            if (levelCardData.IsLocked)
            {
                _playButton.SetLocked(false);
                _highestScoreText.text = "Locked Level";
                return;
            }

            _highestScoreText.text = levelCardData.HighScore != -1 ? $"Highest Score: {levelCardData.HighScore}" : "No Score";
        }
    }
}