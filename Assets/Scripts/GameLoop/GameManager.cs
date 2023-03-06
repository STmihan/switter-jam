using System.Collections.Generic;
using GameLoop.States;
using Gameplay.Controllers;
using Sirenix.OdinInspector;
using StateManagement;
using UnityEngine;
using Utility;

namespace GameLoop
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private Config _config;

        [ShowInInspector] 
        private string SceneName => Application.isPlaying ? GlobalStateMachine.CurrentState.GetType().Name : "";

        public Config Config => _config;


        public StateMachine<GameStateData> GlobalStateMachine { get; private set; }

        protected override void OnCreate()
        {
            var data = new GameStateData(
                new FoodController(_config.Foods)
            );
            GlobalStateMachine = new StateMachine<GameStateData>(data, new MenuState());
        }

        private void Update()
        {
            GlobalStateMachine.Update();
        }

        private void FixedUpdate()
        {
            GlobalStateMachine.FixedUpdate();
        }

        private void LateUpdate()
        {
            GlobalStateMachine.LateUpdate();
        }
    }
}