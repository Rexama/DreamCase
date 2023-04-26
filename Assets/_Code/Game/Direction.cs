using UnityEngine;

namespace _Code.Game
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
            switch (direction)
            {
                case Direction.Right:
                    return Vector2.right;
                case Direction.Left:
                    return Vector2.left;
                case Direction.Up:
                    return Vector2.up;
                case Direction.Down:
                    return Vector2.down;
                default:
                    return Vector2.zero;
            }
        }
    }
}