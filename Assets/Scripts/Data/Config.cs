using Data.Enemies;
using Data.Foods;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Create Config", fileName = "Config", order = 0)]
    public class Config : ScriptableObject
    {
        [field: SerializeField]
        public FoodBase[] Foods { get; private set; }

        [ListDrawerSettings(ShowIndexLabels = true)]
        [field: SerializeField]
        public DefenceOptions[] DefenceOptions { get; private set; }
        [field: SerializeField]
        public int BaseHealth { get; private set; }

        [field: SerializeField]
        public float TimeBetweenWaves = 5f;
    }
}