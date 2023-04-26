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
            ContinueButton.OnContinueButtonPressed += ActivateButton;
            CacheComponents();
            AddListeners();
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
    }
}