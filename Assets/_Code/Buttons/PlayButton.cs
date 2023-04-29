using _Code.LevelFolder;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace _Code.Buttons
{
    public class PlayButton : ButtonObject
    {
        private LevelFolderData _levelFolderData;
        
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
        
        public void SetInteractable(bool value)
        {
            Button.interactable = value;
        }
    }
}