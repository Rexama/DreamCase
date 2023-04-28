using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public abstract class ButtonObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        protected Button Button;

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
            transform.DOScale(0.9f, 0.1f).SetEase(Ease.InOutSine);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine);
        }
    }
}