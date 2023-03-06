using System.Collections.Generic;
using Data.Foods;
using Data.Ingredients;
using DG.Tweening;
using GameLoop;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.UI.Prepare.FoodHelper
{
    public class FoodHelperItem : MonoBehaviour
    {
        [SerializeField] private RectTransform _content;
        [SerializeField] private FoodHelperIngredientItem _ingredientItemPrefab;
        [SerializeField] private CanvasGroup _canvasGroup;
        [Header("Animation")]
        [SerializeField] private float _animationDuration = .5f;
        
        private FoodBase _foodBase;
        private List<FoodHelperIngredientItem> _ingredientItems = new();

        private FoodController FoodController => GameManager.Instance.GlobalStateMachine.Data.FoodController;

        private void Start()
        {
            FoodController.OnFoodAdded += OnFoodAdded;
        }

        private void OnFoodAdded(FoodBase obj)
        {
            _canvasGroup.DOFade(.3f, _animationDuration);
            foreach (FoodHelperIngredientItem item in _ingredientItems)
            {
                item.HandlingEvents = false;
            }
        }

        public void SetFoodItem(FoodBase foodBase)
        {
            _foodBase = foodBase;
            foreach (IngredientData ingredient in _foodBase.Ingredients)
            {
                FoodHelperIngredientItem item = Instantiate(_ingredientItemPrefab, _content);
                item.SetIngredient(ingredient);
                _ingredientItems.Add(item);
            }
        }

        private void OnDestroy()
        {
            FoodController.OnFoodAdded -= OnFoodAdded;
        }
    }
}