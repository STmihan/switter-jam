using System;
using UnityEngine;

namespace Gameplay.Views.Projectiles
{
    public class LaserProjectileView : TargetProjectileBase
    {
        [SerializeField] private LineRenderer _lineRenderer;

        private AudioSource _audioSource;
        
        public void ExtSetup(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }
        
        private void Update()
        {
            if (Target == null || Target.IsDead)
            {
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, transform.position);
                if (_audioSource.isPlaying)
                    _audioSource.Stop();
                return;
            }
            Vector2 targetPosition = Target.GameObject.transform.position;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, targetPosition);

            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }
    }
}