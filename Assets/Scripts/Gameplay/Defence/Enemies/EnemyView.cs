using System;
using Data.Enemies;
using Data.Foods;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Defence.Enemies
{
    public class EnemyView : MonoBehaviour, IHittable
    {
        [field: SerializeField]
        public EnemyData EnemyData { get; private set; }

        [ShowInInspector]
        [ReadOnly]
        public int Helth { get; private set; }
        
        public bool IsDead => Helth <= 0;

        public event Action<EnemyView> OnEnemyDied;
        
        public Transform Transform
        {
            get
            {
                try
                {
                    return transform;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private void Update()
        {
            if (!IsDead)
            {
                transform.Translate(Vector3.left * (EnemyData.Speed * Time.deltaTime));
            }
        }

        public void SetEnemyData(EnemyData enemyData)
        {
            EnemyData = enemyData;
            Helth = enemyData.Health;
        }
        
        public void Hit(int damage)
        {
            Helth -= damage;
            if (Helth <= 0)
            {
                OnEnemyDied?.Invoke(this);
                Die();
            }
        }

        private void Die()
        {
            DOTween.Sequence()
                .AppendCallback(() => gameObject.SetActive(false))
                .AppendInterval(5f)
                .AppendCallback(() => Destroy(gameObject));
        }
    }
}