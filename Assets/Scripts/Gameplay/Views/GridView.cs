﻿using Gameplay.Controllers;
using Gameplay.GridSystem;
using UnityEngine;

namespace Gameplay.Views
{
    public class GridView : MonoBehaviour
    {
        [Header("Grid Settings")]
        [SerializeField]
        private int _gridWidth = 10;

        [SerializeField]
        private int _gridHeight = 10;

        [SerializeField]
        private float _cellSize = 1f;

        [SerializeField]
        private TowerCellView _towerCellViewPrefab;
        
        public Grid<FoodTower> Grid { get; private set; }

        private void Awake()
        {
            Grid = new Grid<FoodTower>(
                _gridWidth,
                _gridHeight,
                _cellSize,
                transform.position
            );

            for (int x = 0; x < Grid.Width; x++)
            {
                for (int y = 0; y < Grid.Height; y++)
                {
                    TowerCellView view = Instantiate(_towerCellViewPrefab, transform);
                    view.transform.position = Grid.GetCell(x, y).Center;
                    view.transform.localScale = Vector3.one * _cellSize;
                    Grid.SetValue(x, y, new FoodTower(view));
                }
            }
        }
        
        private void OnDrawGizmos()
        {
            Grid<FoodTower> grid = new Grid<FoodTower>(_gridWidth, _gridHeight, _cellSize, transform.position);
            grid.DrawDebug();
        }
    }
}