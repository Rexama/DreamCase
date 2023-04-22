using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.LevelCard
{
    public class LevelCard : MonoBehaviour
    {
        private Button _playButton;
        private TextMeshProUGUI _levelAndMovesText;
        private TextMeshProUGUI _highestScoreText;

        private void Awake()
        {
            CacheComponents();
        }

        private void CacheComponents()
        {
            _playButton = GetComponentInChildren<Button>();
            _levelAndMovesText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _highestScoreText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        }

        public void SetUpLevelCard(LevelCardData levelCardData)
        {
            _levelAndMovesText.text = $"Level {levelCardData.Level} - {levelCardData.Moves} Moves";

            if (levelCardData.IsLocked)
            {
                _playButton.interactable = false;
                _highestScoreText.text = "Locked Level";
                return;
            }
            
            if (levelCardData.HighScore != -1)
            {
                _highestScoreText.text = $"Highest Score: {levelCardData.HighScore}";
            }
            else
            {
                _highestScoreText.text = "No Score";
            }
        }
    }
}