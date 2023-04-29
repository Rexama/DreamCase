using System;

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
