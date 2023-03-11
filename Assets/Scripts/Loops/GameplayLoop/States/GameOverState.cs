using DG.Tweening;
using StateManagement;
using UnityEngine;

namespace Loops.GameplayLoop.States
{
    public class GameOverState : StateBase<GameplayData>
    {
        private const float Duration = 0.5f;
        
        public override void Enter(StateMachine<GameplayData> sm)
        {
            sm.Data.GameOverUI.SetActive(true);
            Time.timeScale = 0;
        }

        public override void Exit(StateMachine<GameplayData> sm)
        {
            Time.timeScale = 1;
        }
    }
}