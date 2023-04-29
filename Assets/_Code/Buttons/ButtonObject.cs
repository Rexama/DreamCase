using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public abstract class ButtonObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        protected Button Button;

        private const float ButtonAnimationScaleDownValue = 0.9f;
        private const float ButtonAnimationDurationValue = 0.1f;

        protected virtual void Awake()
        {
            CacheComponents();
            AddListeners();
        }

        private void CacheComponents()
        {
            Button = GetComponent<Button>();
        }

        private void AddListeners()
        {
            Button.onClick.AddListener(OnButtonPressed);
        }

        protected abstract void OnButtonPressed();

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOScale(ButtonAnimationScaleDownValue, ButtonAnimationDurationValue).SetEase(Ease.InOutSine);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine);
        }
    }
}