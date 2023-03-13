using Data.Ingredients;
using Gameplay.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.UI.Prepare.FoodList
{
    public class IngListItem : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Image _image;

        private IngredientData _data;
        private FoodController FoodController => GameplayController.Instance.FoodController;
        
        public void SetIngredient(IngredientData ingredient)
        {
            _data = ingredient;
            _image.sprite = ingredient.Sprite;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            FoodController.SelectIngredient(_data);
        }
    }
}