using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Code.Game.UI
{
    public class TapToContinueText : MonoBehaviour
    {
        private void OnEnable()
        {
            DoScaleAnimation();
        }

        private void DoScaleAnimation()
        {
            transform.DOScale(1.1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                FinishGame();
            }
        }

        private void FinishGame()
        {
            DOTween.KillAll();
            SceneManager.LoadScene("MainScene");
        }
    }
}