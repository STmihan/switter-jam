using System;
using System.Collections.Generic;
using Data.Enemies.Shared;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Enemies
{
	[Serializable]
    public struct EnemyQueueBlock
    {
	    [field: SerializeField]
	    [ListDrawerSettings(ShowIndexLabels = true)]
	    public List<EnemyData> EnemyDatas { get; set; }
    }
}