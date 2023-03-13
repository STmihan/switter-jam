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
        public float TimeBetweenBlocks { get; set; }

        [ListDrawerSettings(ShowIndexLabels = true)]
        public List<EnemyQueueBlock> EnemyQueueBlocks { get; set; }
    }
}