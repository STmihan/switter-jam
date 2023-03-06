using Data.Foods;
using GameLoop;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.UI.Prepare.FoodHelper
{
    public class FoodHelperList : MonoBehaviour
    {
        [SerializeField] private FoodHelperItem _foodHelperItemPrefab;
        
        private FoodController FoodController => GameManager.Instance.GlobalStateMachine.Data.FoodController;

        private void Start()
        {
            foreach (FoodBase availableFood in FoodController.AvailableFoods)
            {
                FoodHelperItem item = Instantiate(_foodHelperItemPrefab, transform);
                item.SetFoodItem(availableFood);
            }
        }
    }
}