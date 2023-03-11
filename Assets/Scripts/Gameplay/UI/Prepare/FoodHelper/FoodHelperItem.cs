using System;
using System.Collections.Generic;
using Data.Foods;
using Data.Ingredients;
using DG.Tweening;
using Gameplay.Controllers;
using Global;
using TMPro;
using UnityEngine;

namespace Gameplay.UI.Prepare.FoodHelper
{
    public class FoodHelperItem : MonoBehaviour
    {
        [SerializeField] private RectTransform _content;
        [SerializeField] private FoodHelperIngredientItem _ingredientItemPrefab;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TMP_Text _countText;

        private FoodBase _foodBase;
        private List<FoodHelperIngredientItem> _ingredientItems = new();

        private FoodController FoodController => GameplayController.Instance.FoodController;

        private void Start()
        {
            _countText.text = "";
            FoodController.OnFoodAdded += OnFoodAdded;
        }

        private void OnEnable()
        {
            if (_foodBase != null && FoodController.Foods.TryGetValue(_foodBase, out int count))
            {
                _countText.text = count.ToString();
            }
            else
            {
                _countText.text = "";
            }
        }

        private void OnFoodAdded(FoodBase obj)
        {
            if (obj != _foodBase) return;
            
            _countText.text = FoodController.Foods[obj].ToString();
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
            if (GameplayController.Instance != null)
            {
                FoodController.OnFoodAdded -= OnFoodAdded;
            }
        }
    }
}