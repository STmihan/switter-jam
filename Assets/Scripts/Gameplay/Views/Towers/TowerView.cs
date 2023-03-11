using System;
using Data.Foods.Shared;
using Gameplay.Controllers;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Views.Towers
{
    public class TowerView : MonoBehaviour, IEnemyTarget
    {
        [field: SerializeField] public Transform Muzzle { get; private set; }
        public bool IsStunned { get; set; }
        public event Action<TowerView> OnDead;

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

        protected FoodBase Food;
        protected EnemyView Target;

        protected float LastAttackTime;

        protected int Health;


        public void Setup(FoodTowerBase food)
        {
            Food = food;
            Health = food.Health;
        }

        private void Update()
        {
            if (Food is IAttackable attackable)
            {
                if (Target == null || Target.IsDead)
                {
                    UpdateTarget(attackable);
                }
                else
                {
                    if (Vector3.Distance(transform.position, Target.transform.position) > attackable.AttackRange)
                    {
                        UpdateTarget(attackable);
                    }
                    else
                    {
                        RotateTo(Target.transform.position);

                        if (Time.time - LastAttackTime < attackable.AttackInterval)
                        {
                            return;
                        }

                        attackable.Attack(this, Target);
                        LastAttackTime = Time.time;
                    }
                }
            }
        }

        private void UpdateTarget(IAttackable attackable)
        {
            EnemyController enemyController = GameplayController.Instance.EnemyController;
            Target = enemyController.GetNearestEnemy(transform.position, attackable.AttackRange);
        }

        private void RotateTo(Vector3 target)
        {
            float multiplier = target.x > transform.position.x ? 1 : -1;
            transform.localScale = new Vector3(multiplier, 1, 1);
        }

        public void Hit(int damage)
        {
            Health -= damage;

            if (Health <= 0)
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