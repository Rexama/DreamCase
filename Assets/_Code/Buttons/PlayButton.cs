using _Code.LevelFolder;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

namespace _Code.Buttons
{
    public class PlayButton : ButtonObject
    {
        private LevelFolderData _levelFolderData;
        private TextMeshProUGUI _text;

        protected override void CacheComponents()
        {
            base.CacheComponents();
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected override void OnButtonPressed()
        {
            LevelFolderDataHolder.Instance.SetLevelFolderData(_levelFolderData);
            SceneManager.LoadScene("LevelScene");
            DOTween.KillAll();
        }

        public void SetLevelFolderData(LevelFolderData levelFolderData)
        {
            _levelFolderData = levelFolderData;
        }

        public void SetLocked(bool value)
        {
            Button.interactable = value;
            _text.text = value ? "Play" : "Locked";
        }
    }
}