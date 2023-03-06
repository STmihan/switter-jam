using Data.Ingredients;
using GameLoop;
using Gameplay.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Prepare.FoodHelper
{
    public class FoodHelperIngredientItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public bool HandlingEvents { get; set; }

        private IngredientData _ingredientData;

        private FoodController FoodController => GameManager.Instance.GlobalStateMachine.Data.FoodController;

        private void Start()
        {
            FoodController.OnIngredientSelected += OnIngredientSelected;
            FoodController.OnIngredientDeselected += OnIngredientDeselected;
        }

        public void SetIngredient(IngredientData ingredientData)
        {
            _image.sprite = ingredientData.Sprite;
            _ingredientData = ingredientData;
        }

        private void OnIngredientSelected(IngredientData ingredientData)
        {
            if (ingredientData == _ingredientData)
            {
                _image.color = Color.green;
            }
        }

        private void OnIngredientDeselected(IngredientData ingredientData)
        {
            if (ingredientData == _ingredientData)
            {
                _image.color = Color.white;
            }
        }

        private void OnDestroy()
        {
            FoodController.OnIngredientSelected -= OnIngredientSelected;
            FoodController.OnIngredientDeselected -= OnIngredientDeselected;
        }
    }
}