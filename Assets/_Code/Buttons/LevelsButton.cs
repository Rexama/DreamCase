using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class LevelsButton : MonoBehaviour
    {
        private Button _button;
        public static Action OnLevelsButtonClickedEvent;

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
            _button.onClick.AddListener(OnLevelsButtonClicked);
        }
        
        private void OnLevelsButtonClicked()
        {
            OnLevelsButtonClickedEvent?.Invoke();
        }
    }
}