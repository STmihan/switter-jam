using System;
using Data.Foods;
using Data.Foods.Shared;
using Gameplay.GridSystem;
using Gameplay.Views;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class TowersController : MonoBehaviour
    {
        [SerializeField] private FoodBase _selectedFood;
        [SerializeField] private GridView _gridView;
        
        public Grid<FoodTower> Grid => _gridView.Grid;
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
        public event Action<FoodBase> OnFoodCountChanged;

        private FoodController FoodController => GameplayController.Instance.FoodController;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
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
            
            if (cell.Data.Food == null && SelectedFood is FoodTowerBase foodTowerBase)
            {
                OnFoodCountChanged?.Invoke(SelectedFood);
                cell.Data.SetFood(foodTowerBase);
                FoodController.RemoveFood(SelectedFood);
                SelectedFood = null;
            }
        }
    }

    public class FoodTower
    {
        public FoodBase Food { get; private set; }

        public TowerCellView View { get; }
        public int Y { get; }

        public FoodTower(TowerCellView view, int y)
        {
            View = view;
            View.OnTowerDied += _ => Food = null;
            Y = y;
        }

        public void SetFood(FoodTowerBase food)
        {
            Food = food;
            View.UpdateView(food);
        }
    }
}