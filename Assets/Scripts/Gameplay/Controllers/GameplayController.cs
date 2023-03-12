using System;
using Gameplay.Views;
using Global;
using Loops.FightLoop;
using Loops.GameplayLoop;
using UnityEngine;
using Utility;

namespace Gameplay.Controllers
{
    public class GameplayController : MonoSingletonPerScene<GameplayController>
    {
        [SerializeField] private GameObject _prepareUI;
        [SerializeField] private GameObject _fightUI;
        [SerializeField] private GameObject _gameOverUI;

        [Space]
        [SerializeField] private Transform _prepareCameraPosition;

        [SerializeField] private Transform _fightCameraPosition;

        [Space]
        [SerializeField] private BaseView _baseView;

        [field: Space]
        [field: SerializeField] public TowersController TowersController { get; private set; }

        [field: SerializeField] public EnemyController EnemyController { get; private set; }
        public FoodController FoodController { get; private set; }
        public FightLoop FightLoop { get; private set; }
        public GameplayLoop GameplayLoop { get; private set; }
        public CameraController CameraController { get; private set; }

        public int Score { get; private set; }
        public float Time { get; private set; }


        protected override void OnCreate()
        {
            if (!GameManager.IsInitialized) return;

            _prepareUI.SetActive(false);
            _fightUI.SetActive(false);
            _gameOverUI.SetActive(false);

            FoodController = new FoodController(GameManager.Instance.Config.Foods);
            FightLoop = new FightLoop(TowersController, EnemyController);
            GameplayLoop = new GameplayLoop(
                _prepareUI,
                _fightUI, _gameOverUI,
                _prepareCameraPosition,
                _fightCameraPosition,
                _baseView
            );
            CameraController = new CameraController(Camera.main);
            EnemyController.OnEnemyDied += OnEnemyDied;
        }

        private void OnEnemyDied(EnemyView obj)
        {
            Score += 1;
        }

        private void Update()
        {
            FightLoop.Update();
            GameplayLoop.Update();
            Time += UnityEngine.Time.deltaTime;
        }

        private void FixedUpdate()
        {
            FightLoop.FixedUpdate();
            GameplayLoop.FixedUpdate();
        }

        private void LateUpdate()
        {
            FightLoop.LateUpdate();
            GameplayLoop.LateUpdate();
        }

        private void OnDestroy()
        {
            SaveData oldSaveData = GameManager.Load();
            int saveScore = Score > oldSaveData.Score ? Score : oldSaveData.Score;
            int saveTime = Time > oldSaveData.Time ? Mathf.FloorToInt(Time) : oldSaveData.Time;
            GameManager.Save(new SaveData { Time = saveTime, Score = saveScore });

            FightLoop?.OnDestroy();
            GameplayLoop?.OnDestroy();
        }
    }
}