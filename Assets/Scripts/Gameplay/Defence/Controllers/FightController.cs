﻿using System;
using System.Collections;
using System.Collections.Generic;
using Data.Enemies;
using Gameplay.Defence.Enemies;
using UnityEngine;

namespace Gameplay.Defence.Controllers
{
    public class FightController : MonoBehaviour
    {
        [SerializeField] private Transform[] _enemySpawnPoints;
        [SerializeField] private float _timeBetweenEnemies = .4f;

        public event Action<EnemyData> OnEnemySpawned;
        public event Action<EnemyData> OnEnemyDied;
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
            foreach (EnemyQueueBlock waveEnemyQueueBlock in wave.EnemyQueueBlocks)
            {
                foreach (EnemyData enemyData in waveEnemyQueueBlock.EnemyDatas)
                {
                    Transform randomSpawnPoint =
                        _enemySpawnPoints[UnityEngine.Random.Range(0, _enemySpawnPoints.Length)];
                    EnemyView enemyView = Instantiate(enemyData.EnemyViewPrefab);
                    enemyView.SetEnemyData(enemyData);
                    enemyView.transform.position = randomSpawnPoint.position;
                    enemyView.OnEnemyDied += EnemyDied;
                    _enemies.Add(enemyView);
                    OnEnemySpawned?.Invoke(enemyData);
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

        private void EnemyDied(EnemyData enemyData)
        {
            OnEnemyDied?.Invoke(enemyData);
            _enemies.Remove(_enemies.Find(enemy => enemy.EnemyData == enemyData));
        }
    }
}