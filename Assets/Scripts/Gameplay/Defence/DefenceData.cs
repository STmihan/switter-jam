using System.Collections.Generic;
using Gameplay.Defence.Controllers;
using Gameplay.Defence.Enemies;

namespace Gameplay.Defence
{
    public class DefenceData
    {
        public FoodTowersController FoodTowersController { get; }
        public FightController FightController { get; }
        public Queue<EnemyWave> WavesQueue { get; }
        public int MaxWave { get; set; } = 1;
        public int CurrentWave { get; set; } = 1;
        public float TimerToStartBattle { get; }
        
        public int Score { get; set; }

        public DefenceData(float timerToStartBattle, Queue<EnemyWave> wavesQueue, FoodTowersController foodTowersController, FightController fightController)
        {
            TimerToStartBattle = timerToStartBattle;
            WavesQueue = wavesQueue;
            FoodTowersController = foodTowersController;
            FightController = fightController;
        }
    }
}