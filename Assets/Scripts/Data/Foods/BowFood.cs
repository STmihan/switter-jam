using Data.Foods.Shared;
using Gameplay.Interfaces;
using Gameplay.Views;
using Gameplay.Views.Projectiles;
using Gameplay.Views.Towers;
using UnityEngine;

namespace Data.Foods
{
    [CreateAssetMenu(menuName = "Foods/Create BowFood", fileName = "BowFood", order = 0)]
    public class BowFood : FoodTowerBase, IAttackable
    {
        [field: SerializeField]
        public float AttackRange { get; private set; }

        [field: SerializeField]
        public float AttackInterval { get; private set; }

        [field: SerializeField]
        public int AttackDamage { get; private set; }

        [SerializeField]
        private BowProjectileView _projectilePrefab;

        [SerializeField]
        private float _projectileSpeed;

        public void Attack(TowerView view, IHittable target)
        {
            var projectile = Instantiate(_projectilePrefab, view.Muzzle.position, Quaternion.identity);
            projectile.Setup(target, view.Muzzle.position, _projectileSpeed, AttackDamage);
            view.AudioSource.pitch = Random.Range(0.6f, 0.8f);
            view.AudioSource.Play();
        }
    }
}