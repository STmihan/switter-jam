using System;
using Gameplay.Interfaces;
using Global;
using UnityEngine;

namespace Gameplay.Views
{
    public class BaseView : MonoBehaviour, IEnemyTarget
    {
        private int _health;
        public Transform Transform { get; }
        public bool IsDead { get; }
        
        public event Action<BaseView> OnBaseDied;

        private void Awake()
        {
            if (!GameManager.IsInitialized) return;
            
            _health = GameManager.Instance.Config.BaseHealth;
        }

        public void Hit(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnBaseDied?.Invoke(this);
        }
    }
}