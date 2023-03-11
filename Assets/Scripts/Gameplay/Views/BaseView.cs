using System;
using Gameplay.Interfaces;
using Global;
using UnityEngine;

namespace Gameplay.Views
{
    public class BaseView : MonoBehaviour, IEnemyTarget
    {
        public bool IsStunned { get; set; }
        private int _health;

        public GameObject GameObject
        {
            get
            {
                try
                {
                    return gameObject == null ? null : gameObject;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool IsDead => _health <= 0;

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