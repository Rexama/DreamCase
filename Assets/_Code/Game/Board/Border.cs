using UnityEngine;

namespace _Code.Game.Board
{
    public class Border : MonoBehaviour
    {
        SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void SetBorderSize(int width, int height)
        {
            _spriteRenderer.size = new Vector2(width + 0.20f, height + 0.35f);
        }
    }
}