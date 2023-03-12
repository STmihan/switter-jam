using Data.Enemies.Shared;
using Gameplay.Views;
using Gameplay.Views.Enemies;
using UnityEngine;

namespace Data.Enemies
{
    [CreateAssetMenu(menuName = "Enemies/Create BigEnemyData", fileName = "BigEnemyData", order = 0)]
    public class BigEnemyData : EnemyData
    {
        [field: SerializeField] public BigEnemyView CtxEnemyViewPrefab { get; private set; }

        public override EnemyView EnemyViewPrefab => CtxEnemyViewPrefab;
    }
}