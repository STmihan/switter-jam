using System.Collections.Generic;
using Data.Enemies;
using Gameplay.Controllers;
using Global;
using Loops.FightLoop.States;
using Sirenix.OdinInspector;
using StateManagement;
using UnityEngine;

namespace Loops.FightLoop
{
    public class FightLoop
    {
        private readonly StateMachine<FightData> _battleStateMachine;
        public FightData FightData { get; private set; }

        public FightLoop(TowersController towersController, EnemyController enemyController)
        {
            if (!GameManager.IsInitialized) return;

            FightData = new FightData(
                GameManager.Instance.Config.TimeBetweenWaves,
                new Queue<EnemyWave>(GameManager.Instance.Config.DefenceOptions[0].EnemyWaves),
                towersController,
                enemyController
            );

            _battleStateMachine = new StateMachine<FightData>(FightData, new SetupState());
        }
        
        

        public void Update() => _battleStateMachine.Update();
        public void FixedUpdate() => _battleStateMachine.FixedUpdate();
        public void LateUpdate() => _battleStateMachine.LateUpdate();
        public void OnDestroy() => _battleStateMachine.OnDestroy();
    }
}