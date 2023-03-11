using System;
using System.Collections.Generic;
using Data.Foods;
using Data.Foods.Shared;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.UI.Fight
{
    public class AvailableFoodList : MonoBehaviour
    {
        [SerializeField] private AvailableFoodListItem _availableFoodListItemPrefab;
        
        private List<AvailableFoodListItem> _items = new();
        private FoodController FoodController => GameplayController.Instance.FoodController;

        private void OnEnable()
        {
            SetItems();
        }

        public void SetItems()
        {
            foreach (AvailableFoodListItem item in _items)
            {
                Destroy(item.gameObject);
            }
            _items.Clear();

            foreach (var pair in FoodController.Foods)
            {
                FoodBase food = pair.Key;
                int count = pair.Value;
                AvailableFoodListItem item = Instantiate(_availableFoodListItemPrefab, transform);
                _items.Add(item);
                item.SetFoodItem(food, count);
            }
        }
    }
}