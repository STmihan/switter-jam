using Data.Ingredients;
using GameLoop;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.UI.Interactable
{
    public class SelectIngredient : MonoBehaviour, IInteractable
    {
        [SerializeField] private IngredientData _ingredientData;

        private static FoodController FoodController => GameManager.Instance.GlobalStateMachine.Data.FoodController;

        public void Interact()
        {
            FoodController.SelectIngredient(_ingredientData);
        }
    }
}