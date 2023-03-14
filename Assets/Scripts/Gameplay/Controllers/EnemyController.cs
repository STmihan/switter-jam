using System;
using System.Collections;
using System.Collections.Generic;
using Data.Enemies;
using Data.Enemies.Shared;
using Data.Enemies.Waves;
using Gameplay.Views;
using Gameplay.Views.Enemies.Shared;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        public int CurrentWave { get; private set; } = 1;
        
        [SerializeField] private Transform[] _enemySpawnPoints;
        [SerializeField] private float _timeBetweenEnemies = .4f;

        public event Action<EnemyView> OnEnemySpawned;
        public event Action<EnemyView> OnEnemyDied;
        public event Action<EnemyWave> OnWaveEnded;

        private List<EnemyView> _enemies = new();
        private EnemyWave _currentWave;
        private int _currentWaveBlockIndex;

        public void StartWave(EnemyWave wave)
        {
            _currentWave = wave;
            StartCoroutine(SpawnWave(wave));
        }

        private IEnumerator SpawnWave(EnemyWave wave)
        {
            CurrentWave++;
            foreach (EnemyQueueBlock waveEnemyQueueBlock in wave.EnemyQueueBlocks)
            {
                foreach (EnemyData enemyData in waveEnemyQueueBlock.EnemyDatas)
                {
                    int i = UnityEngine.Random.Range(0, _enemySpawnPoints.Length);
                    Transform randomSpawnPoint =
                        _enemySpawnPoints[i];
                    EnemyView enemyView = Instantiate(enemyData.EnemyViewPrefab);
                    enemyView.SetEnemyData(enemyData);
                    Vector3 position = randomSpawnPoint.position;
                    position.z = i;
                    enemyView.transform.position = position;
                    enemyView.transform.localScale = Vector3.one * GameplayController.Instance.TowersController.Grid.CellSize;
                    enemyView.OnEnemyDied += EnemyDied;
                    _enemies.Add(enemyView);
                    OnEnemySpawned?.Invoke(enemyView);
                    yield return new WaitForSeconds(_timeBetweenEnemies);
                }

                _currentWaveBlockIndex++;
                yield return new WaitForSeconds(wave.TimeBetweenBlocks);
            }

            while (_enemies.Count > 0)
            {
                yield return null;
            }

            OnWaveEnded?.Invoke(wave);
        }

        private void EnemyDied(EnemyView enemyData)
        {
            OnEnemyDied?.Invoke(enemyData);
            _enemies.Remove(_enemies.Find(enemy => enemy == enemyData));
        }

        public EnemyView GetNearestEnemy(Vector3 transformPosition, float attackRange)
        {
            EnemyView nearestEnemy = null;
            float nearestDistance = attackRange;
            foreach (EnemyView enemy in _enemies)
            {
                float distance = Vector3.Distance(transformPosition, enemy.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }
    }
}