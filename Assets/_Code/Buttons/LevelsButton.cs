using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class LevelsButton : ButtonObject
    {
        public static Action OnLevelsButtonClickedEvent;

        
        protected virtual void Awake()
        {
            base.Awake();
            
            ContinueButton.OnContinueButtonPressed += ActivateButton;
            
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
        
        protected override void OnButtonPressed()
        {
            OnLevelsButtonClickedEvent?.Invoke();
        }

        private void ActivateButton()
        { 
            gameObject.SetActive(true);
        }
    }
}