using UnityEngine;

namespace Gameplay.GridSystem
{
    public class Grid<T>
    {
        public int Width { get; }
        public int Height { get; }
        public float CellSize { get; }
        public Vector2 Origin { get; }

        private readonly Cell<T>[,] _cells;

        public Grid(int width, int height, float cellSize, Vector2 origin)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
            Origin = origin;

            _cells = new Cell<T>[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 cellCenter = new Vector2(x, y) * cellSize + origin;
                    _cells[x, y] = new Cell<T>(x, y, cellSize, cellCenter);
                }
            }
        }

        public Cell<T> GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return null;
            }

            return _cells[x, y];
        }

        public Cell<T> GetCell(Vector2 position)
        {
            int x = Mathf.FloorToInt(((position.x - Origin.x) / CellSize) + CellSize / 2);
            int y = Mathf.FloorToInt(((position.y - Origin.y) / CellSize) + CellSize / 2);
            return GetCell(x, y);
        }

        public void SetValue(int x, int y, T value)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }

            _cells[x, y].Data = value;
        }

        public void SetValue(Vector2 position, T value)
        {
            int x = Mathf.FloorToInt((position.x - Origin.x) / CellSize);
            int y = Mathf.FloorToInt((position.y - Origin.y) / CellSize);
            SetValue(x, y, value);
        }

        public void SetValue(Cell<T> cell, T value)
        {
            cell.Data = value;
        }
        
        public void SetValueAll(T value)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _cells[x, y].Data = value;
                }
            }
        }

        public void DrawDebug()
        {
#if UNITY_EDITOR
            foreach (Cell<T> cell in _cells)
            {
                Gizmos.DrawWireCube(cell.Center, Vector2.one * cell.Size);
            }
#endif
        }
    }
}