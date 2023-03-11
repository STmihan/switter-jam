using System;
using UnityEngine;

namespace Gameplay.Views.Projectiles
{
    public class LaserProjectileView : TargetProjectileBase
    {
        [SerializeField] private LineRenderer _lineRenderer;

        private void Update()
        {
            if (Target == null || Target.IsDead)
            {
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, transform.position);
                return;
            }
            Vector2 targetPosition = Target.GameObject.transform.position;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, targetPosition);
        }
    }
}