using _Code.LevelFolder;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class PlayButton : ButtonObject
    {
        private LevelFolderData _levelFolderData;
        
        protected override void OnButtonPressed()
        {
            LevelFolderDataHolder.Instance.SetLevelFolderData(_levelFolderData);
            DOTween.KillAll();
            SceneManager.LoadScene("LevelScene");
        }

        public void SetLevelFolderData(LevelFolderData levelFolderData)
        {
            _levelFolderData = levelFolderData;
        }
        
        public void SetInteractable(bool value)
        {
            Button.interactable = value;
        }
    }
}