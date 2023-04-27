using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class LevelsButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        private Button _button;
        public static Action OnLevelsButtonClickedEvent;

        private void Awake()
        {
            ContinueButton.OnContinueButtonPressed += ActivateButton;
            
            CacheComponents();
            AddListeners();
        }

        private void OnDisable()
        {
            ContinueButton.OnContinueButtonPressed -= ActivateButton;
        }

        private void Start()
        {
            if(PlayerPrefs.HasKey("New_HS") && PlayerPrefs.GetInt("New_HS") > 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void CacheComponents()
        {
            _button = GetComponent<Button>();
        }
        
        private void AddListeners()
        {
            _button.onClick.AddListener(OnLevelsButtonClicked);
        }
        
        
        private void OnLevelsButtonClicked()
        {
            OnLevelsButtonClickedEvent?.Invoke();
        }
        
        private void ActivateButton()
        { 
            gameObject.SetActive(true);
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