using StateManagement;
using UnityEngine;

namespace Loops.GameplayLoop.States
{
    public class PrepareState : StateBase<GameplayData>
    {
        public override void Enter(StateMachine<GameplayData> sm)
        {
            sm.Data.PrepareUI.SetActive(true);
            Camera.main.transform.position = sm.Data.PrepareCameraPosition.position;
        }

        public override void Exit(StateMachine<GameplayData> sm)
        {
            sm.Data.PrepareUI.SetActive(false);
        }
    }
}