using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Buttons;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CelebrationHandler : MonoBehaviour
{
    [Header("Components")]
    
    [SerializeField] private GameObject starImage;
    [SerializeField] private GameObject backgroundSunlight;
    [SerializeField] private GameObject starAnimation;
    [SerializeField] private GameObject backGroundStarLight;
    [SerializeField] private GameObject congratulationsText;
    [SerializeField] private GameObject confetti;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private Transform parent;
    [SerializeField] private TextMeshProUGUI hiScoreText;
    
    private void Awake()
    {
        ContinueButton.OnContinueButtonPressed += CloseCelebration;
        
        CacheComponents();
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("New_HS") && PlayerPrefs.GetInt("New_HS") > 0)
        {
            hiScoreText.text = "New Hi-Score: "+PlayerPrefs.GetInt("New_HS").ToString();
            PlayCelebration();
        }
    }

    private void CacheComponents()
    {
        parent = transform.GetChild(0).transform;
        starImage = parent.GetChild(0).gameObject;
        backgroundSunlight = parent.GetChild(1).gameObject;
        starAnimation = parent.GetChild(2).gameObject;
        backGroundStarLight = parent.GetChild(3).gameObject;
        congratulationsText = parent.GetChild(4).gameObject;
        hiScoreText = parent.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
        confetti = parent.GetChild(6).gameObject;
        continueButton = parent.GetChild(7).gameObject;
    }
    
    private void PlayCelebration()
    {
        parent.gameObject.SetActive(true);
        backgroundSunlight.SetActive(true);
        backgroundSunlight.transform.DOMove(Vector3.zero, 1.5f).SetEase(Ease.InOutSine);
        confetti.SetActive(true);
        
        DOTween.Sequence().AppendInterval(1.5f).OnComplete(() =>
        {
            starAnimation.SetActive(true);
            hiScoreText.transform.DOMoveX(0, 0.5f).SetEase(Ease.InOutSine);
            congratulationsText.transform.DOMoveX(0, 0.5f).SetEase(Ease.InOutSine);
        });
        
        DOTween.Sequence().AppendInterval(3f).OnComplete(() =>
        {
            starImage.SetActive(true);
            starImage.transform.DOScale(6.5f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            backGroundStarLight.SetActive(true);
            backGroundStarLight.transform.DOScale(50f, 1f).SetEase(Ease.InOutSine).OnComplete(() =>
            {
                backGroundStarLight.transform.DOScale(60f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            });
        });
        
        DOTween.Sequence().AppendInterval(5f).OnComplete(() =>
        {
            continueButton.transform.DOMoveX(0, 0.5f).SetEase(Ease.InOutSine);
        });
    }
    
    private void CloseCelebration()
    {
        parent.gameObject.SetActive(false);
    }
}
