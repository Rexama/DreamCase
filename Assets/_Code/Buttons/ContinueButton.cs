using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class ContinueButton : ButtonObject
    {
        public static Action OnContinueButtonPressed;

        protected override void OnButtonPressed()
        {
            OnContinueButtonPressed?.Invoke();
        }

    }
}
