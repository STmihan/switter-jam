using Data.Foods;
using GameLoop;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.UI.Defence
{
    public class AvailableFoodList : MonoBehaviour
    {
        [SerializeField] private AvailableFoodListItem _availableFoodListItemPrefab;
        
        private FoodController FoodController => GameManager.Instance.GlobalStateMachine.Data.FoodController;
        private void Start()
        {
            foreach (var pair in FoodController.Foods)
            {
                FoodBase food = pair.Key;
                int count = pair.Value;
                AvailableFoodListItem item = Instantiate(_availableFoodListItemPrefab, transform);
                item.SetFoodItem(food, count);
            }
        }
    }
}