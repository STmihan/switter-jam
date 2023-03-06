using System.Collections;
using GameLoop;
using StateManagement;
using UnityEngine;

namespace Gameplay.Defence.States
{
    public class SetupState : StateBase<DefenceData>
    {
        public override void Enter(StateMachine<DefenceData> sm)
        {
            GameManager.Instance.StartCoroutine(StartTimer(sm));
        }

        private IEnumerator StartTimer(StateMachine<DefenceData> sm)
        {
            yield return new WaitForSeconds(sm.Data.TimerToStartBattle);
            sm.ChangeState(new FightState());
        }
    }
}