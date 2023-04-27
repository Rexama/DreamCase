using _Code.LevelFolder;
using TMPro;
using UnityEngine;

namespace _Code.Game.UI
{
    public class LevelText : MonoBehaviour
    {
        TextMeshProUGUI _levelText;

        private void Awake()
        {
            _levelText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _levelText.text = "Level " + LevelFolderDataHolder.Instance.LevelFolderData.LevelNumber;
        }
    }
}