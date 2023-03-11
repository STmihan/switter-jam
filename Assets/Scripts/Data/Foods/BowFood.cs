using Data.Foods.Shared;
using Gameplay.Interfaces;
using Gameplay.Views.Projectiles;
using UnityEngine;

namespace Data.Foods
{
    [CreateAssetMenu(menuName = "Foods/Create BowFood", fileName = "BowFood", order = 0)]
    public class BowFood : FoodTowerBase, IAttackable
    {
        [field: SerializeField] 
        public float AttackRange { get; private set;}
        [field: SerializeField] 
        public float AttackInterval { get; private set;}
        [field: SerializeField] 
        public int AttackDamage { get; private set;}
        [SerializeField]
        private BowProjectileView _projectilePrefab;
        public void Attack(Transform transform, IHittable target)
        {
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            projectile.Setup(target, transform.position, AttackRange, AttackDamage);
        }
    }
}