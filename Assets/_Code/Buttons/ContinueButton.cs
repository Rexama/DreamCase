using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class ContinueButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        private Button _button;
        public static Action OnContinueButtonPressed;

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
            _button.onClick.AddListener(OnContinueButtonClicked);
        }
        
        private void OnContinueButtonClicked()
        {
            OnContinueButtonPressed?.Invoke();
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
