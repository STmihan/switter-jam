using Data.Ingredients;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Prepare.SelectedIngredients
{
    public class SelectedIngredientsItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public IngredientData IngredientData { get; private set; }
        
        public void SetIngredient(IngredientData ingredientData)
        {
            IngredientData = ingredientData;
            _image.sprite = ingredientData.Sprite;
        }
    }
}