using System;
using System.Collections.Generic;
using Data.Enemies;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Defence.Enemies
{
	[Serializable]
    public class EnemyQueueBlock
    {
	    [field: SerializeField]
	    [ListDrawerSettings(ShowIndexLabels = true)]
	    public List<EnemyData> EnemyDatas { get; private set; }
    }
}