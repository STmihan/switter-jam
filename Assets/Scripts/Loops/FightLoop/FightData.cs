﻿using System.Collections.Generic;
using Data.Enemies;
using Gameplay.Controllers;

namespace Loops.FightLoop
{
    public class FightData
    {
        public TowersController TowersController { get; }
        public EnemyController EnemyController { get; }
        public Queue<EnemyWave> WavesQueue { get; }
        public int MaxWave { get; set; } = 1;
        public int CurrentWave { get; set; } = 1;
        public float TimerToStartBattle { get; }
        
        public int Score { get; set; }

        public FightData(float timerToStartBattle, Queue<EnemyWave> wavesQueue, TowersController towersController, EnemyController enemyController)
        {
            TimerToStartBattle = timerToStartBattle;
            WavesQueue = wavesQueue;
            TowersController = towersController;
            EnemyController = enemyController;
        }
    }
}