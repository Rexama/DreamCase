using _Code.Buttons;
using UnityEngine;

namespace _Code.Panels
{
    public class LevelsPanel : MonoBehaviour
    {
        private GameObject _levelsPanel;
        private static bool _firstLoad = true;

        private void Awake()
        {
            LevelsButton.OnLevelsButtonClickedEvent += ShowLevelsPanel;
            ContinueButton.OnContinueButtonPressed += ShowLevelsPanel;

            CacheComponents();
            OpenPanelIfNotFirstLoad();
        }

        private void OnDestroy()
        {
            LevelsButton.OnLevelsButtonClickedEvent -= ShowLevelsPanel;
            ContinueButton.OnContinueButtonPressed -= ShowLevelsPanel;
        }

        private void CacheComponents()
        {
            _levelsPanel = transform.GetChild(0).gameObject;
        }

        private void OpenPanelIfNotFirstLoad()
        {
            if (!_firstLoad && PlayerPrefs.GetInt("New_HS", 0) <= 0)
            {
                ShowLevelsPanel();
            }

            _firstLoad = false;
        }

        private void ShowLevelsPanel()
        {
            _levelsPanel.SetActive(true);
        }

        public void HideLevelsPanel()
        {
            _levelsPanel.SetActive(false);
        }
    }
}