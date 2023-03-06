using Gameplay.Defence.Enemies;
using Gameplay.Defence.Views;
using UnityEngine;

namespace Data.Foods
{
    [CreateAssetMenu(menuName = "Foods/Create RangeFood", fileName = "RangeFood", order = 0)]
    public class RangeFood : FoodBase, IAttackable
    {
        [field: SerializeField]
        public float AttackRange { get; private set; }

        [field: SerializeField]
        public float AttackInterval { get; private set; }
        
        [field: SerializeField]
        public int AttackDamage { get; private set; }

        [SerializeField]
        private ProjectileView _projectilePrefab;

        [SerializeField]
        private float _projectileSpeed;

        public void Attack(Transform transform, IHittable target)
        {
            ProjectileView projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            projectile.Setup(target, transform.position, _projectileSpeed, AttackDamage);
        }
    }
}