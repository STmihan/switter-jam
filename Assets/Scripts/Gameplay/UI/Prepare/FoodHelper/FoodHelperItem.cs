using System.Collections.Generic;
using Data.Foods.Shared;
using Data.Ingredients;
using Gameplay.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Prepare.FoodHelper
{
    public class FoodHelperItem : MonoBehaviour
    {
        [SerializeField] private RectTransform _content;
        
        [SerializeField] private FoodHelperIngredientItem _ingredientItemPrefab;
        [SerializeField] private Image _foodImage;
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
                _foodImage.sprite = _foodBase.Sprite;
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