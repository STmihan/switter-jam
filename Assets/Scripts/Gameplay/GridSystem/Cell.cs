using UnityEngine;

namespace Gameplay.GridSystem
{
    public class Cell<T>
    {
        public int X { get; }
        public int Y { get; }
        public float Size { get; }
        public Vector2 Center { get; }

        public T Data { get; set; }

        public Cell(int x, int y, float size, Vector2 center)
        {
            X = x;
            Y = y;
            Size = size;
            Center = center;
        }

        public bool Contains(Vector2 point)
        {
            return point.x >= Center.x - Size / 2 && point.x <= Center.x + Size / 2 &&
                   point.y >= Center.y - Size / 2 && point.y <= Center.y + Size / 2;
        }
    }
}