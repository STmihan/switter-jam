using System;
using Data.Foods;
using Gameplay.Controllers;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Views
{
    public class TowerView : MonoBehaviour, IEnemyTarget
    {
        public event Action<TowerView> OnDead;
        public Transform Transform { get; }
        public bool IsDead { get; }
        
        private FoodBase _food;
        private EnemyView _target;
        
        private float _lastAttackTime;
        
        private int _health;
        

        public void Setup(FoodTowerBase food)
        {
            _food = food;
            _health = food.Health;
        }

        private void Update()
        {
            if (_food is IAttackable attackable)
            {
                if (_target == null || _target.IsDead)
                {
                    UpdateTarget(attackable);
                }
                else
                {
                    if (Vector3.Distance(transform.position, _target.transform.position) > attackable.AttackRange)
                    {
                        UpdateTarget(attackable);
                    }
                    else
                    {
                        RotateTo(_target.transform.position);
                        
                        if (Time.time - _lastAttackTime < attackable.AttackInterval)
                        {
                            return;
                        }
                        
                        attackable.Attack(transform, _target);
                        _lastAttackTime = Time.time;
                    }
                }
            }
        }

        private void UpdateTarget(IAttackable attackable)
        {
            EnemyController enemyController = GameplayController.Instance.EnemyController;
            _target = enemyController.GetNearestEnemy(transform.position, attackable.AttackRange);
        }
        
        private void RotateTo(Vector3 target)
        {
            Vector2 diff = target - transform.position;
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
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
            gameObject.SetActive(false);
            OnDead?.Invoke(this);
            Destroy(gameObject, 5f);
        }
    }
}