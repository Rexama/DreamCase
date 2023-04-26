﻿using System;
using System.Collections.Generic;
using _Code.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Panels
{
    public class LevelsPanel : MonoBehaviour
    {
        private GameObject _levelsPanel;

        private void Awake()
        {
            LevelsButton.OnLevelsButtonClickedEvent += ShowLevelsPanel;
            ContinueButton.OnContinueButtonPressed += ShowLevelsPanel;
            
            CacheComponents();
        }

        private void OnDestroy()
        {
            LevelsButton.OnLevelsButtonClickedEvent -= ShowLevelsPanel;
        }

        private void CacheComponents()
        {
            _levelsPanel = transform.GetChild(0).gameObject;
        }
        
        public void ShowLevelsPanel()
        {
            _levelsPanel.SetActive(true);
        }
        
        public void HideLevelsPanel()
        {
            _levelsPanel.SetActive(false);
        }
    }
}