using System.Collections.Generic;
using GameLoop;
using Gameplay.Defence.Enemies;
using Gameplay.Defence.States;
using Sirenix.OdinInspector;
using StateManagement;
using UnityEngine;
using Utility;

namespace Gameplay.Defence.Controllers
{
    public class DefenceController : MonoSingletonPerScene<DefenceController>
    {
        [ShowInInspector]
        private string StateName => Application.isPlaying ? _battleStateMachine.CurrentState.GetType().Name : "";

        [SerializeField] private float _timerToStartBattle = 5f;
        [SerializeField] private FoodTowersController _foodTowersController;
        [SerializeField] private FightController _fightController;

        private StateMachine<DefenceData> _battleStateMachine;
        public DefenceData DefenceData { get; private set; }

        protected override void OnCreate()
        {
            if (!GameManager.IsInitialized) return;

            DefenceData = new DefenceData(
                _timerToStartBattle,
                new Queue<EnemyWave>(GameManager.Instance.Config.DefenceOptions[0].EnemyWaves),
                _foodTowersController,
                _fightController
            );

            _battleStateMachine = new StateMachine<DefenceData>(DefenceData, new SetupState());
        }

        private void Update() => _battleStateMachine.Update();
        private void FixedUpdate() => _battleStateMachine.FixedUpdate();
        private void LateUpdate() => _battleStateMachine.LateUpdate();
    }
}