using UnityEngine;

namespace _Code.Tools
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }

    public static class DirectionExtensionMethods
    {
        public static Vector2 GetDirectionVector(this Direction direction)
        {
            return direction switch
            {
                Direction.Right => Vector2.right,
                Direction.Left => Vector2.left,
                Direction.Up => Vector2.up,
                Direction.Down => Vector2.down,
                _ => Vector2.zero
            };
        }
    }
}