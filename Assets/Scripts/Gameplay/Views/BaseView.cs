using System;
using Gameplay.Controllers;
using Gameplay.Interfaces;
using Global;
using UnityEngine;

namespace Gameplay.Views
{
    public class BaseView : MonoBehaviour, IEnemyTarget, IHealth
    {
        public bool IsStunned { get; set; }
        public int Health { get; private set; }

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

        public bool IsDead => Health <= 0;

        public event Action<BaseView> OnBaseDied;


        private void Awake()
        {
            if (!GameManager.IsInitialized) return;
            
            Health = GameManager.Instance.Config.BaseHealth;
        }

        public void Hit(int damage)
        {
            if (IsDead) return;
            GameplayController.Instance.CameraController.Shake(0.2f, .4f);
            Health -= damage;
            if (Health <= 0)
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