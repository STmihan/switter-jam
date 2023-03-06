using Data.Foods;
using Gameplay.Defence.Enemies;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameLoop
{
    [CreateAssetMenu(menuName = "Create Config", fileName = "Config", order = 0)]
    public class Config : ScriptableObject
    {
        [field: SerializeField]
        public FoodBase[] Foods { get; private set; }

        [ListDrawerSettings(ShowIndexLabels = true)]
        [field: SerializeField]
        public DefenceOptions[] DefenceOptions { get; private set; }
    }
}