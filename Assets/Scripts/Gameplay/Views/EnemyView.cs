using System;
using Data.Enemies;
using Gameplay.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Views
{
    public class EnemyView : MonoBehaviour, ITowerTarget
    {
        public bool IsStunned { get; set; }
        public EnemyData EnemyData { get; private set; }

        [ShowInInspector]
        [ReadOnly]
        public int Health { get; private set; }

        public bool IsDead => Health <= 0;

        public event Action<EnemyView> OnEnemyDied;


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

        private float _attackTimer;


        private void Update()
        {
            if (IsDead || IsStunned) return;

            FindNextTarget();

            if (_attackTimer > 0)
            {
                _attackTimer -= Time.deltaTime;
            }
        }

        public void SetEnemyData(EnemyData enemyData)
        {
            EnemyData = enemyData;
            Health = enemyData.Health;
        }

        public void Hit(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                OnEnemyDied?.Invoke(this);
                Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 5f);
        }

        private void FindNextTarget()
        {
            Vector2 direction = Vector2.left;

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, EnemyData.AttackRange);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.TryGetComponent(out IEnemyTarget hittable))
                    {
                        if (_attackTimer <= 0)
                        {
                            hittable.Hit(EnemyData.Damage);
                            _attackTimer = EnemyData.AttacksInterval;
                        }
                        return;
                    }
                }
            }
            
            Vector2 nextPoint = Vector2.MoveTowards(transform.position, new Vector2(-1, transform.position.y),
                EnemyData.Speed * Time.deltaTime);
            transform.position = nextPoint;
        }
    }
}