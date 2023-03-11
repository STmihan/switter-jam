﻿using Gameplay.Interfaces;
using Gameplay.Views;
using Gameplay.Views.Projectiles;
using UnityEngine;

namespace Data.Foods
{
    [CreateAssetMenu(menuName = "Foods/Create RangeFood", fileName = "RangeFood", order = 0)]
    public class RangeFood : FoodTowerBase, IAttackable
    {
        [field: SerializeField]
        public float AttackRange { get; private set; }

        [field: SerializeField]
        public float AttackInterval { get; private set; }
        
        [field: SerializeField]
        public int AttackDamage { get; private set; }

        [SerializeField]
        private AutoProjectileView _autoProjectilePrefab;

        [SerializeField]
        private float _projectileSpeed;

        public void Attack(Transform transform, IHittable target)
        {
            AutoProjectileView autoProjectile = Instantiate(_autoProjectilePrefab, transform.position, Quaternion.identity);
            autoProjectile.Setup(target, transform.position, _projectileSpeed, AttackDamage);
        }
    }
}