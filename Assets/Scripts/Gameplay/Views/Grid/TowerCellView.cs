using System;
using Data.Foods.Shared;
using Gameplay.Views.Towers;
using UnityEngine;

namespace Gameplay.Views.Grid
{
    public class TowerCellView : MonoBehaviour
    {
        private TowerView _view;
        public event Action<TowerView> OnTowerDied;
        
        public void UpdateView(FoodTowerBase food)
        {
            if (food == null)
            {
                _view.OnDead -= OnDead;
                Destroy(_view.gameObject);
                _view = null;
                return;
            }
            _view = Instantiate(food.Prefab, transform);
            _view.Setup(food);
            _view.OnDead += OnDead;
        }

        private void OnDead(TowerView obj)
        {
            UpdateView(null);
            OnTowerDied?.Invoke(obj);
        }
    }
}