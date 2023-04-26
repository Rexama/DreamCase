using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class ContinueButton : MonoBehaviour
    {
        private Button _button;
        private CelebrationHandler _celebrationHandler;
        public static Action OnContinueButtonPressed;

        private void Awake()
        {
            CacheComponents();
            AddListeners();
        }
        
        private void CacheComponents()
        {
            _button = GetComponent<Button>();
            _celebrationHandler = GetComponentInParent<CelebrationHandler>();
        }
        
        private void AddListeners()
        {
            _button.onClick.AddListener(OnContinueButtonClicked);
        }
        
        private void OnContinueButtonClicked()
        {
            OnContinueButtonPressed?.Invoke();
        }
    }
}
