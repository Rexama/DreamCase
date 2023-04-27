using UnityEngine;

namespace _Code.Game.UI
{
    public class CanvasOrientationManager : MonoBehaviour
    {
        [SerializeField] private Transform landscapeBoardParent;
        [SerializeField] private Transform landscapePanelsGroup;
        [SerializeField] private Transform landscapeLevelTextParent;
        
        public void SetUIObjectParents(UIParentHandler board, UIParentHandler movesPanel, UIParentHandler scorePanel, UIParentHandler hiScorePanel, UIParentHandler levelText)
        {
            board.SetParent(landscapeBoardParent);
            movesPanel.SetParent(landscapePanelsGroup);
            scorePanel.SetParent(landscapePanelsGroup);
            hiScorePanel.SetParent(landscapePanelsGroup);
            levelText.SetParent(landscapeLevelTextParent);
        }
        
        
    }
}