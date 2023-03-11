using Loops.GlobalLoop.States;
using Sirenix.OdinInspector;
using StateManagement;
using UnityEngine;
using Utility;

namespace Loops.GlobalLoop
{
    public class GlobalLoop : MonoSingleton<GlobalLoop>
    {
        
        [ShowInInspector] 
        private string SceneName => Application.isPlaying ? GlobalStateMachine.CurrentState.GetType().Name : "";

        public StateMachine<GlobalData> GlobalStateMachine { get; private set; }

        protected override void OnCreate()
        {
            var data = new GlobalData();
            GlobalStateMachine = new StateMachine<GlobalData>(data, new MenuState());
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