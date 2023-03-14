using System;
using DG.Tweening;
using Gameplay.Interfaces;
using Gameplay.Views.Enemies.Shared;
using UnityEngine;

namespace Gameplay.Views.Enemies
{
    public class SmallEnemyView : EnemyView
    {
        [SerializeField] private GameObject _vfxPrefab;
        private Sequence _sequence;

        public override void Attack(IEnemyTarget target, int damage)
        {
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = target.GameObject.transform.position;
            _sequence = DOTween.Sequence();
            _sequence
                .Append(transform
                    .DOMoveX(targetPosition.x, 0.2f)
                    .SetEase(Ease.InQuart))
                .AppendCallback(() =>
                {
                    Instantiate(_vfxPrefab, targetPosition, Quaternion.identity);
                    target.Hit(damage);
                })
                .Append(transform
                    .DOMoveX(startPosition.x, 0.2f)
                    .SetEase(Ease.OutQuint));
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