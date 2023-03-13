using System.Collections.Generic;
using System.Linq;
using Data.Ingredients;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.UI.Prepare.FoodList
{
    public class IngList : MonoBehaviour
    {
        [SerializeField] private IngListItem _ingListItemPrefab;
        [SerializeField] private RectTransform _content;
        
        private FoodController FoodController => GameplayController.Instance.FoodController;

        private void Start()
        {
            foreach (IngredientData data in GetAllAvailableIngredients())
            {
                IngListItem item = Instantiate(_ingListItemPrefab, _content);
                item.SetIngredient(data);
            }
        }

        private IngredientData[] GetAllAvailableIngredients()
        {
            HashSet<IngredientData> ingredients = new HashSet<IngredientData>();
            foreach (var food in FoodController.AvailableFoods)
            {
                foreach (var ingredient in food.Ingredients)
                {
                    ingredients.Add(ingredient);
                }
            }

            return ingredients.ToArray();
        }
    }
}