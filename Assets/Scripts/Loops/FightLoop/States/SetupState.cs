using System.Collections;
using Global;
using StateManagement;
using UnityEngine;

namespace Loops.FightLoop.States
{
    public class SetupState : StateBase<FightData>
    {
        public override void Enter(StateMachine<FightData> sm)
        {
            GameManager.Instance.StartCoroutine(StartTimer(sm));
        }

        private IEnumerator StartTimer(StateMachine<FightData> sm)
        {
            yield return new WaitForSeconds(sm.Data.TimerToStartBattle);
            sm.ChangeState(new FightState());
        }
    }
}