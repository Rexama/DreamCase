using System;
using UnityEngine;

namespace _Code.Buttons
{
    public class LevelsButton : ButtonObject
    {
        public static Action OnLevelsButtonClickedEvent;

        protected override void Awake()
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
            if (PlayerPrefs.HasKey("New_HS") && PlayerPrefs.GetInt("New_HS") > 0)
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