using Data.Ingredients;
using Gameplay.Controllers;
using Global;
using UnityEngine;

namespace Gameplay.UI.Interactable
{
    public class SelectIngredient : MonoBehaviour, IInteractable
    {
        [SerializeField] private IngredientData _ingredientData;

        private static FoodController FoodController => GameplayController.Instance.FoodController;

        public void Interact()
        {
            FoodController.SelectIngredient(_ingredientData);
        }
    }
}