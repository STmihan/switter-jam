using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Data.Foods;
using Data.Ingredients;

namespace Gameplay.Controllers
{
    public class FoodController
    {
        public readonly FoodBase[] AvailableFoods;

        public event Action<IngredientData> OnIngredientSelected;
        public event Action<IngredientData> OnIngredientDeselected;
        public event Action<FoodBase> OnFoodAdded;

        public Dictionary<FoodBase, int> Foods => _foods.ToDictionary(x => x.Key, x => x.Value);
        
        private readonly Dictionary<FoodBase, int> _foods = new();
        private readonly List<IngredientData> _selectedIngredients = new();

        public FoodController(FoodBase[] availableFoods)
        {
            AvailableFoods = availableFoods;
        }

        public void SelectIngredient(IngredientData ingredientData)
        {
            if (_selectedIngredients.Contains(ingredientData))
            {
                DeselectIngredient(ingredientData);
                return;
            }

            _selectedIngredients.Add(ingredientData);
            OnIngredientSelected?.Invoke(ingredientData);
            TryAddFood();
        }

        public void RemoveFood(FoodBase selectedFood)
        {
            _foods[selectedFood]--;
            if (_foods[selectedFood] == 0)
            {
                _foods.Remove(selectedFood);
            }
        }

        private void DeselectIngredient(IngredientData ingredientData)
        {
            _selectedIngredients.Remove(ingredientData);
            OnIngredientDeselected?.Invoke(ingredientData);
        }

        private void DeselectAll()
        {
            foreach (IngredientData ingredient in _selectedIngredients)
            {
                OnIngredientDeselected?.Invoke(ingredient);
            }

            _selectedIngredients.Clear();
        }

        private void TryAddFood()
        {
            foreach (FoodBase availableFood in AvailableFoods)
            {
                if (IsFoodValid(availableFood))
                {
                    AddFood(availableFood);
                    break;
                }
            }
        }

        private bool IsFoodValid(FoodBase availableFood)
        {
            foreach (var ingredient in availableFood.Ingredients)
            {
                if (!_selectedIngredients.Contains(ingredient))
                {
                    return false;
                }
            }

            return true;
        }

        private void AddFood(FoodBase food)
        {
            DeselectAll();
            if (_foods.ContainsKey(food))
            {
                _foods[food]++;
            }
            else
            {
                _foods.Add(food, 1);
            }
            OnFoodAdded?.Invoke(food);
        }
    }
}