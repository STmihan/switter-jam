using Data.Foods;
using Gameplay.Controllers;
using Global;
using UnityEngine;

namespace Gameplay.UI.Prepare.FoodHelper
{
    public class FoodHelperList : MonoBehaviour
    {
        [SerializeField] private FoodHelperItem _foodHelperItemPrefab;
        
        private FoodController FoodController => GameplayController.Instance.FoodController;

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