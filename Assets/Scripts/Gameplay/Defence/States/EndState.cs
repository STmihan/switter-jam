using System.Collections;
using GameLoop;
using GameLoop.States;
using StateManagement;
using UnityEngine;

namespace Gameplay.Defence.States
{
    public class EndState : StateBase<DefenceData>
    {
        public override void Enter(StateMachine<DefenceData> sm)
        {
            GameManager.Instance.StartCoroutine(GoToMenu());
        }

        private IEnumerator GoToMenu()
        {
            yield return new WaitForSeconds(1f);
            GameManager
                .Instance
                .GlobalStateMachine
                .ChangeState(new LoadState(PrepareState.SceneName, new PrepareState()));
        }
    }
}