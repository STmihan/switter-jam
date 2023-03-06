using UnityEngine;

namespace Data.Ingredients
{
    [CreateAssetMenu(menuName = "Create Ingredient Data", fileName = "IngredientData", order = 0)]
    public class IngredientData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public Sprite Sprite { get; private set; }
    }
}