using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Enemies
{
    [Serializable]
    public class EnemyWave
    {
        [field: SerializeField]
        public float TimeBetweenBlocks { get; private set; }
        [ListDrawerSettings(ShowIndexLabels = true)]
        [SerializeField] private List<EnemyQueueBlock> _enemyQueueBlocks = new();
        public Queue<EnemyQueueBlock> EnemyQueueBlocks => new(_enemyQueueBlocks);
    }
}