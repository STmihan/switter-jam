using System;
using Data.Foods;
using DG.Tweening;
using Gameplay.Defence.Controllers;
using Gameplay.Defence.Enemies;
using UnityEngine;

namespace Gameplay.Defence.Views
{
    public class FoodTowerView : MonoBehaviour
    {
        private FoodBase _food;
        private EnemyView _target;
        
        private float _lastAttackTime;

        public void Setup(FoodBase food)
        {
            _food = food;
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
            FightController fightController = DefenceController.Instance.DefenceData.FightController;
            _target = fightController.GetNearestEnemy(transform.position, attackable.AttackRange);
        }
        
        private void RotateTo(Vector3 target)
        {
            Vector2 diff = target - transform.position;
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }
    }
}