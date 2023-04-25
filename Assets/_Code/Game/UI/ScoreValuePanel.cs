using System;
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
            BoardScoreHandler.OnRowCompleted += IncreaseScore;
            
            _scoreText = GetComponentInChildren<TextMeshProUGUI>();
            SetScoreText(_score);
        }

        private void OnDisable()
        {
            BoardScoreHandler.OnRowCompleted -= IncreaseScore;
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