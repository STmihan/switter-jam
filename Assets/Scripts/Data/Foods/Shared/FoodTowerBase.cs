using UnityEngine;

namespace Data.Foods.Shared
{
    public abstract class FoodTowerBase : FoodBase
    {
        [field: SerializeField]
        public int Health { get; private set; }
    }
}