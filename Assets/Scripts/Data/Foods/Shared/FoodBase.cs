using System.Collections.Generic;
using Data.Ingredients;
using Gameplay.Views;
using Gameplay.Views.Towers;
using UnityEngine;

namespace Data.Foods.Shared
{
    public abstract class FoodBase : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public List<IngredientData> Ingredients { get; private set; } = new();
        [field: SerializeField]
        public Sprite Sprite { get; private set; }
        [field: SerializeField]
        public TowerView Prefab { get; private set; }
    }
}