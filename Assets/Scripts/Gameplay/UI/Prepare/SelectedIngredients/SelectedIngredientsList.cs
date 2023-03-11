using System.Collections.Generic;
using Data.Ingredients;
using Gameplay.Controllers;
using Global;
using UnityEngine;

namespace Gameplay.UI.Prepare.SelectedIngredients
{
    public class SelectedIngredientsList : MonoBehaviour
    {
        [SerializeField] private SelectedIngredientsItem _selectedIngredientsItemPrefab;

        private List<SelectedIngredientsItem> _selectedIngredients = new();

        private FoodController FoodController => GameplayController.Instance.FoodController;

        private void Start()
        {
            FoodController.OnIngredientSelected += OnIngredientSelected;
            FoodController.OnIngredientDeselected += OnIngredientDeselected;
        }

        private void OnIngredientSelected(IngredientData obj)
        {
            SelectedIngredientsItem item = Instantiate(_selectedIngredientsItemPrefab, transform);
            item.SetIngredient(obj);
            _selectedIngredients.Add(item);
        }

        private void OnIngredientDeselected(IngredientData obj)
        {
            foreach (SelectedIngredientsItem selectedIngredientsItem in _selectedIngredients)
            {
                if (selectedIngredientsItem.IngredientData == obj)
                {
                    Destroy(selectedIngredientsItem.gameObject);
                    _selectedIngredients.Remove(selectedIngredientsItem);
                    break;
                }
            }
        }

        private void OnDestroy()
        {
            if (GameplayController.Instance != null && FoodController != null)
            {
                FoodController.OnIngredientSelected -= OnIngredientSelected;
                FoodController.OnIngredientDeselected -= OnIngredientDeselected;
            }
        }
    }
}