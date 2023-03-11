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
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0, Duration);
        }

        public override void Exit(StateMachine<GameplayData> sm)
        {
            sm.Data.GameOverUI.SetActive(false);
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1, Duration);
        }
    }
}