using System;
using _Code.LevelFolder;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class PlayButton : MonoBehaviour
    {
        private Button _button;
        private LevelFolderData _levelFolderData;
        
        private void Awake()
        {
            CacheComponents();
            AddListeners();
        }
        
        private void CacheComponents()
        {
            _button = GetComponent<Button>();
        }
        
        private void AddListeners()
        {
            _button.onClick.AddListener(OnPlayButtonClicked);
        }
        
        public void SetLevelFolderData(LevelFolderData levelFolderData)
        {
            _levelFolderData = levelFolderData;
        }
        
        public void SetInteractable(bool value)
        {
            _button.interactable = value;
        }
        
        private void OnPlayButtonClicked()
        {
            LevelFolderDataHolder.Instance.SetLevelFolderData(_levelFolderData);
            SceneManager.LoadScene("LevelScene 1");
        }
    }
}