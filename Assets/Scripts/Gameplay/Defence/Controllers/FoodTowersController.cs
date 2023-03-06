using System;
using Data.Foods;
using Gameplay.GridSystem;
using UnityEngine;

namespace Gameplay.Defence.Controllers
{
    public class FoodTowersController : MonoBehaviour
    {
        public FoodBase SelectedFood
        {
            get => _selectedFood;
            set
            {
                OnSelectedFoodChanged?.Invoke(value);
                _selectedFood = value;
            }
        }
        public event Action<FoodBase> OnSelectedFoodChanged;

        public Grid<FoodTower> Grid { get; private set; }

        [Header("Grid Settings")]
        [SerializeField]
        private int _gridWidth = 10;

        [SerializeField]
        private int _gridHeight = 10;

        [SerializeField]
        private float _cellSize = 1f;

        [SerializeField]
        private FoodCellView _foodCellViewPrefab;

        private Camera _camera;
        [SerializeField] private FoodBase _selectedFood;

        private void Start()
        {
            _camera = Camera.main;
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
                    FoodCellView view = Instantiate(_foodCellViewPrefab, transform);
                    view.transform.position = Grid.GetCell(x, y).Center;
                    view.transform.localScale = Vector3.one * _cellSize;
                    Grid.SetValue(x, y, new FoodTower(view));
                }
            }
        }

        private void Update()
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                SetFood(mousePosition);
            }
        }

        private void SetFood(Vector2 mousePos)
        {
            Cell<FoodTower> cell = Grid.GetCell(mousePos);
            if (cell == null) return;
            
            if (cell.Data.Food == null)
            {
                cell.Data.SetFood(SelectedFood);
                SelectedFood = null;
            }
        }

        private void OnDrawGizmos()
        {
            Grid<FoodTower> grid = new Grid<FoodTower>(_gridWidth, _gridHeight, _cellSize, transform.position);
            grid.DrawDebug();
        }
    }

    public class FoodTower
    {
        public FoodBase Food { get; private set; }

        public FoodCellView View { get; private set; }

        public FoodTower(FoodCellView view)
        {
            View = view;
        }

        public void SetFood(FoodBase food)
        {
            Food = food;
            View.UpdateView(food);
        }
    }
}