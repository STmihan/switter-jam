using Data.Foods.Shared;
using DG.Tweening;
using Gameplay.Controllers;
using UnityEngine;

namespace Gameplay.Views.Bogacheva
{
    public class BogachevaList : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private BogachevaListItem _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _targetPoint;
        [SerializeField] private Transform _endPoint;
        [SerializeField] private float _speed = 2f;

        private FoodController FoodController => GameplayController.Instance.FoodController;
        private BogachevaListItem _currentItem;
        
        private void Start()
        {
            _currentItem = Instantiate(_prefab, transform);
            _currentItem.SetData(_sprites[Random.Range(0, _sprites.Length)], _speed);
            _currentItem.transform.position = _spawnPoint.position;
            _currentItem.SetTargetPosition(_targetPoint.position);
            FoodController.OnFoodAdded += OnFoodAdded;
        }

        private void OnFoodAdded(FoodBase obj)
        {
            Done();
        }

        private void Done()
        {
            _currentItem.SetTargetPosition(_endPoint.position);
            Destroy(_currentItem, 5f);
            var nextItem = Instantiate(_prefab, transform);
            nextItem.SetData(_sprites[Random.Range(0, _sprites.Length)], _speed);
            nextItem.transform.position = _spawnPoint.position;
            _currentItem = nextItem; 
            _currentItem.SetTargetPosition(_targetPoint.position);
        }
    }
}