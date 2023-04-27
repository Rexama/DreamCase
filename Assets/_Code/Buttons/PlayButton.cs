using _Code.LevelFolder;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class PlayButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
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
            DOTween.KillAll();
            SceneManager.LoadScene("LevelScene3-Good");
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOScale(0.9f, 0.1f).SetEase(Ease.InOutSine);
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine);
        }
    }
}