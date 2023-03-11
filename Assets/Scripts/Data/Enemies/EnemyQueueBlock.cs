using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Enemies
{
	[Serializable]
    public class EnemyQueueBlock
    {
	    [field: SerializeField]
	    [ListDrawerSettings(ShowIndexLabels = true)]
	    public List<EnemyData> EnemyDatas { get; private set; }
    }
}