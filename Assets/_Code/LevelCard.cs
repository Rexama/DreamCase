using System.Collections;
using System.Collections.Generic;
using _Code.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        _playButton = GetComponent<Button>();
        _levelAndMovesText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _highestScoreText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    
    public void SetUpLevelCard(LevelCardData levelCardData)
    {
        _levelAndMovesText.text = $"Level {levelCardData.Level} - {levelCardData.Moves} Moves";
        //_highestScoreText.text = $"Highest Score: {levelCardData.HighestScore}";
    }
}
