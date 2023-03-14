using Data.Enemies.Shared;
using Gameplay.Views;
using Gameplay.Views.Enemies;
using Gameplay.Views.Enemies.Shared;
using UnityEngine;

namespace Data.Enemies
{
    [CreateAssetMenu(menuName = "Enemies/Create SmallEnemyData", fileName = "SmallEnemyData", order = 0)]
    public class SmallEnemyData : EnemyData
    {
        [field: SerializeField] public SmallEnemyView CtxEnemyViewPrefab { get; private set; }
        
        public override EnemyView EnemyViewPrefab => CtxEnemyViewPrefab;
    }
}