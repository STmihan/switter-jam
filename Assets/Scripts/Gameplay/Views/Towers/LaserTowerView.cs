using System;
using Data.Foods;
using Gameplay.Interfaces;
using Gameplay.Views.Projectiles;
using UnityEngine;

namespace Gameplay.Views.Towers
{
    public class LaserTowerView : TowerView
    {
        private LaserProjectileView _laser;

        private void Start()
        {
            OnDead += Die;
        }

        private void Die(TowerView obj)
        {
            Destroy(_laser.gameObject);
        }

        public void Attack(IHittable target, int damage, LaserProjectileView laser, Vector3 muzzlePos)
        {
            if (IsDead) return;
            if (_laser == null)
            {
                _laser = Instantiate(laser, transform.position, Quaternion.identity);
            }

            _laser.Setup(target, muzzlePos, 0, damage);
        }
    }
}