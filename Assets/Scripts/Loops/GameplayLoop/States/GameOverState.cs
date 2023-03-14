using Music;
using StateManagement;
using UnityEngine;

namespace Loops.GameplayLoop.States
{
    public class GameOverState : StateBase<GameplayData>
    {
        public override void Enter(StateMachine<GameplayData> sm)
        {
            sm.Data.GameOverUI.SetActive(true);
            Time.timeScale = 0;
            AudioManager.Instance.PlayGameOverMusic();
        }

        public override void Exit(StateMachine<GameplayData> sm)
        {
            Time.timeScale = 1;
        }
    }
}