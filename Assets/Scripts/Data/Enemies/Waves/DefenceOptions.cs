using System.Collections.Generic;
using UnityEngine;

namespace Data.Enemies
{
    [CreateAssetMenu(menuName = "Defence/Create DefenceOptions", fileName = "DefenceOptions", order = 0)]
    public class DefenceOptions : ScriptableObject
    {
        [field: SerializeField]
        public List<EnemyWave> EnemyWaves { get; private set; } = new();
    }
}