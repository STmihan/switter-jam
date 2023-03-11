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

        public void Attack(IHittable target, int damage, LaserProjectileView laser, Vector3 muzzlePos)
        {
            if (_laser == null)
            {
                _laser = Instantiate(laser, transform.position, Quaternion.identity);
            }
            _laser.Setup(target, muzzlePos, 0, damage);
        }
    }
}