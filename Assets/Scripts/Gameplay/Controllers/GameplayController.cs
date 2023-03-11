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
        [SerializeField] private TowersController _towersController;
        [SerializeField] private EnemyController _enemyController;
        [Space]
        [SerializeField] private BaseView _baseView;
        
        public FoodController FoodController { get; private set; }
        public FightLoop FightLoop { get; private set; }
        public GameplayLoop GameplayLoop { get; private set; }
        public TowersController TowersController => _towersController;
        public EnemyController EnemyController => _enemyController;
        
        
        protected override void OnCreate()
        {
            if (!GameManager.IsInitialized) return;
            
            _prepareUI.SetActive(false);
            _fightUI.SetActive(false);
            _gameOverUI.SetActive(false);
            
            FoodController = new FoodController(GameManager.Instance.Config.Foods);
            FightLoop = new FightLoop(_towersController, _enemyController);
            GameplayLoop = new GameplayLoop(
                _prepareUI, 
                _fightUI, _gameOverUI, 
                _prepareCameraPosition, 
                _fightCameraPosition,
                _baseView
                );
        }

        private void Update()
        {
            FightLoop.Update();
            GameplayLoop.Update();
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
            FightLoop?.OnDestroy();
            GameplayLoop?.OnDestroy();
        }
    }
}