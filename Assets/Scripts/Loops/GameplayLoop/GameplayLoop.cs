using Gameplay.Views;
using Loops.GameplayLoop.States;
using StateManagement;
using UnityEngine;

namespace Loops.GameplayLoop
{
    public class GameplayLoop
    {
        public StateMachine<GameplayData> StateMachine { get; }

        public GameplayLoop(
            GameObject prepareUI,
            GameObject fightUI,
            GameObject gameOverUI,
            Transform prepareCameraPosition,
            Transform fightCameraPosition,
            BaseView baseView
        )
        {
            var gameplayData =
                new GameplayData(prepareUI, fightUI, gameOverUI, prepareCameraPosition, fightCameraPosition);
            StateMachine = new StateMachine<GameplayData>(gameplayData, new PrepareState());
            baseView.OnBaseDied += OnBaseDied;
        }

        private void OnBaseDied(BaseView baseView)
        {
            StateMachine.ChangeState(new GameOverState());
            baseView.OnBaseDied -= OnBaseDied;
        }

        public void Update() => StateMachine.Update();
        public void FixedUpdate() => StateMachine.FixedUpdate();
        public void LateUpdate() => StateMachine.LateUpdate();
    }

    public class GameplayData
    {
        public GameObject PrepareUI { get; }

        public GameObject FightUI { get; }
        public GameObject GameOverUI { get; }

        public Transform PrepareCameraPosition { get; }
        public Transform FightCameraPosition { get; }

        public GameplayData(GameObject prepareUI, GameObject fightUI, GameObject gameOverUI,
            Transform prepareCameraPosition, Transform fightCameraPosition)
        {
            PrepareUI = prepareUI;
            FightUI = fightUI;
            GameOverUI = gameOverUI;
            PrepareCameraPosition = prepareCameraPosition;
            FightCameraPosition = fightCameraPosition;
        }
    }
}