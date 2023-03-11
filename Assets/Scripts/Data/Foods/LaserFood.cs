using System;
using System.Collections.Generic;
using Data.Foods.Shared;
using Gameplay.Interfaces;
using Gameplay.Views;
using Gameplay.Views.Projectiles;
using Gameplay.Views.Towers;
using UnityEngine;

namespace Data.Foods
{
    [CreateAssetMenu(menuName = "Foods/Create LaserFood", fileName = "LaserFood", order = 0)]
    public class LaserFood : FoodTowerBase, IAttackable
    {
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackInterval { get; private set; }
        [field: SerializeField] public int AttackDamage { get; private set; }
        [SerializeField] private LaserProjectileView _laserProjectilePrefab;

        public void Attack(TowerView view, IHittable target)
        {
            ((LaserTowerView)view).Attack(target, AttackDamage, _laserProjectilePrefab, view.Muzzle.position);
            target.Hit(AttackDamage);
        }
    }
}