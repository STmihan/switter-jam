using DG.Tweening;
using Gameplay.Controllers;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Views.Enemies
{
    public class BigEnemyView : EnemyView
    {
        [SerializeField] private GameObject _vfxPrefab;
        private Sequence _sequence;

        public override void Attack(IEnemyTarget target, int damage)
        {
            Vector2 startPosition = transform.position;
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOMove(target.GameObject.transform.position, 0.2f).SetEase(Ease.InQuart));
            _sequence.AppendCallback(() =>
            {
                target.Hit(damage);
                Instantiate(_vfxPrefab, target.GameObject.transform.position, Quaternion.identity);
                GameplayController.Instance.CameraController.Shake(0.2f, .2f);
            });
            _sequence.Append(transform.DOMove(startPosition, 0.2f).SetEase(Ease.OutQuint));
        }
        
        private void LateUpdate()
        {
            if (IsStunned)
            {
                _sequence.Kill();
            }
        }
    }
}