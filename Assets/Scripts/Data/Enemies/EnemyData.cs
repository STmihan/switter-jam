using Gameplay.Views;
using UnityEngine;

namespace Data.Enemies
{
    [CreateAssetMenu(menuName = "Create EnemyData", fileName = "EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float AttacksInterval { get; private set; }
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public EnemyView EnemyViewPrefab { get; private set; }
    }
}