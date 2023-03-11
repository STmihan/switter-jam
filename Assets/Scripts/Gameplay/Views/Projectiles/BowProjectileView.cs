using DG.Tweening;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Views.Projectiles
{
    public class BowProjectileView : TargetProjectileBase
    {
        private bool _isHitFirstTime;
        private Vector2 _direction;

        private void Start()
        {
            _direction = (Target.GameObject.transform.position - transform.position).normalized;
        }

        private void Update()
        {
            if (Target == null || Target.GameObject == null)
            {
                Destroy(gameObject);
                return;
            }
            
            if (!_isHitFirstTime && !Target.IsDead)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position,
                        Target.GameObject.transform.position,
                        Speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    (Vector2)transform.position + _direction,
                    Speed * Time.deltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ITowerTarget target))
            {
                if (!_isHitFirstTime)
                {
                    _isHitFirstTime = true;
                    var direction = (target.GameObject.transform.position - transform.position).normalized;
                    Vector2 positionAfterHit = new Vector2(
                        target.GameObject.transform.position.x + direction.x,
                        target.GameObject.transform.position.y
                    );
                    
                    target.IsStunned = true;
                    target.GameObject.transform
                        .DOMove(positionAfterHit, 0.3f)
                        .OnComplete(() => target.IsStunned = false);
                }
                target.Hit(Damage);
                Destroy(gameObject, 5f);
            }
        }
    }
}