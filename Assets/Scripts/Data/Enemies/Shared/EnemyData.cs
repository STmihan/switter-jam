using Gameplay.Views;
using Unity.VisualScripting;
using UnityEngine;

namespace Data.Enemies.Shared
{
    public abstract class EnemyData : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float AttacksInterval { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        public abstract EnemyView EnemyViewPrefab { get; }
    }
}
