using System;
using System.Collections.Generic;
using Data.Enemies.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Enemies.Waves
{
    [CreateAssetMenu(menuName = "Defence/Create DefenceOptions", fileName = "DefenceOptions", order = 0)]
    public class DefenceOptions : SerializedScriptableObject
    {
        public float TimeBetweenBlocks = 5f;
        public int Count = 5;
        [TableList]
        public List<DefenceOption> DefenceOptionsList;

        public EnemyWave GenerateWave(int currentWave)
        {
            var queueBlocks = new List<EnemyQueueBlock>();
            for (int i = 0; i < Count; i++)
            {
                EnemyQueueBlock enemyQueueBlock = new EnemyQueueBlock();
                enemyQueueBlock.EnemyDatas = new List<EnemyData>();
                foreach (DefenceOption option in DefenceOptionsList)
                {
                    int enemyCount = Mathf.CeilToInt(option.Count * option.Multiplier * currentWave);
                    Debug.Log(enemyCount);
                    for (int j = 0; j < enemyCount; j++)
                    {
                        enemyQueueBlock.EnemyDatas.Add(option.EnemyData);
                    }
                }
                queueBlocks.Add(enemyQueueBlock);
            }
            
            Debug.Log($"Generated wave with {queueBlocks.Count} blocks");
            Debug.Log($"Generated wave with {queueBlocks[0].EnemyDatas.Count} enemies");
            
            EnemyWave enemyWave = new EnemyWave
            {
                TimeBetweenBlocks = TimeBetweenBlocks,
                EnemyQueueBlocks = queueBlocks
            };

            return enemyWave;
        }
    }
    
    [Serializable]
    public class DefenceOption
    {
        public EnemyData EnemyData;
        public float Multiplier;
        public int Count;
    }
}