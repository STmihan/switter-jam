using System;
using Data.Enemies;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Defence.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        [field: SerializeField]
        public EnemyData EnemyData { get; private set; }

        [ShowInInspector]
        [ReadOnly]
        public int Helth { get; private set; }

        public event Action<EnemyData> OnEnemyDied;

        private void Update()
        {
            transform.Translate(Vector3.left * (EnemyData.Speed * Time.deltaTime));
        }

        public void SetEnemyData(EnemyData enemyData)
        {
            EnemyData = enemyData;
            Helth = enemyData.Health;
        }

        private void OnMouseDown()
        {
            Hit(EnemyData.Health);
        }

        public void Hit(int damage)
        {
            Helth -= damage;
            if (Helth <= 0)
            {
                OnEnemyDied?.Invoke(EnemyData);
                Destroy(gameObject);
            }
        }
    }
}