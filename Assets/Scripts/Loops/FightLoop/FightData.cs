using System.Collections.Generic;
using Data.Enemies;
using Data.Enemies.Waves;
using Gameplay.Controllers;

namespace Loops.FightLoop
{
    public class FightData
    {
        public TowersController TowersController { get; }
        public EnemyController EnemyController { get; }
        public DefenceOptions DefenceOptions { get; }
        public int MaxWave { get; set; } = 1;
        public int CurrentWave { get; set; } = 1;
        public float TimerToStartBattle { get; }
        
        public int Score { get; set; }

        public FightData(float timerToStartBattle, DefenceOptions defenceOptions, TowersController towersController, EnemyController enemyController)
        {
            TimerToStartBattle = timerToStartBattle;
            DefenceOptions = defenceOptions;
            TowersController = towersController;
            EnemyController = enemyController;
        }
    }
}