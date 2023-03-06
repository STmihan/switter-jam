using System.Collections.Generic;
using Data.Ingredients;
using UnityEngine;

namespace Data.Foods
{
    public abstract class FoodBase : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public List<IngredientData> Ingredients { get; private set; } = new();
        [field: SerializeField]
        public Sprite Sprite { get; private set; }
    }
}