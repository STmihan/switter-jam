using StateManagement;
using UnityEngine;

namespace Loops.GameplayLoop.States
{
    public class FightState : StateBase<GameplayData>
    {
        public override void Enter(StateMachine<GameplayData> sm)
        {
            sm.Data.FightUI.SetActive(true);
            Camera.main.transform.position = sm.Data.FightCameraPosition.position;
        }
        
        public override void Exit(StateMachine<GameplayData> sm)
        {
            sm.Data.FightUI.SetActive(false);
        }
    }
}