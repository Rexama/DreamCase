using System;
using UnityEngine;

namespace _Code.Game.UI
{
    public class ScreenOrientationManager : MonoBehaviour
    {
        [SerializeField] private UIParentHandler board;
        [SerializeField] private UIParentHandler movesPanel;
        [SerializeField] private UIParentHandler scorePanel;
        [SerializeField] private UIParentHandler hiScorePanel;
        [SerializeField] private UIParentHandler levelText;

        [SerializeField] private CanvasOrientationManager portraitCanvas;
        [SerializeField] private CanvasOrientationManager landscapeCanvas;

        private float _prevScreenWidth = Screen.width;
        private float _prevHeight = Screen.height;

        private void Start()
        {
            HandleScreenOrientation();
        }

        private void Update()
        {
            float curScreenWidth = Screen.width;
            float curScreenHeight = Screen.height;

            if (curScreenWidth != _prevScreenWidth || curScreenHeight != _prevHeight)
            {
                _prevScreenWidth = curScreenWidth;
                _prevHeight = curScreenHeight;
                HandleScreenOrientation();
            }
        }

        private void HandleScreenOrientation()
        {
            if (Screen.width > Screen.height) //Landscape
            {
                landscapeCanvas.SetUIObjectParents(board, movesPanel, scorePanel, hiScorePanel, levelText);
            }
            else //Portrait
            {
                portraitCanvas.SetUIObjectParents(board, movesPanel, scorePanel, hiScorePanel, levelText);
            }
        }
    }
}