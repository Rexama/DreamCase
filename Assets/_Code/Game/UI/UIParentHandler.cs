using UnityEngine;

namespace _Code.Game.UI
{
    public class UIParentHandler : MonoBehaviour
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition= Vector3.zero;
            transform.localScale = Vector3.one;
        }
    }
}