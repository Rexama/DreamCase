using _Code.Game.Board;
using TMPro;
using UnityEngine;

namespace _Code.Game.UI
{
    public class ScoreValuePanel : MonoBehaviour
    {
        private int _score;
        private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            BoardScoreHandler.OnScoreGain += IncreaseScore;

            CacheComponents();
            SetScoreText(_score);
        }

        private void CacheComponents()
        {
            _scoreText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnDisable()
        {
            BoardScoreHandler.OnScoreGain -= IncreaseScore;
        }

        private void SetScoreText(int score)
        {
            _scoreText.text = score.ToString();
        }

        private void IncreaseScore(int value)
        {
            _score += value;
            SetScoreText(_score);
        }
    }
}