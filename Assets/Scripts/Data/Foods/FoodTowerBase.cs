using UnityEngine;

namespace Data.Foods
{
    public abstract class FoodTowerBase : FoodBase
    {
        [field: SerializeField]
        public int Health { get; private set; }
    }
}