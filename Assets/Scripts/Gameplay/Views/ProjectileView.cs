using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Views
{
    public class ProjectileView : MonoBehaviour
    {
        private IHittable _target;
        private float _speed;
        private int _damage;
        public void Setup(IHittable target, Vector3 start, float projectileSpeed, int damage)
        {
            transform.position = start;
            _speed = projectileSpeed;
            _target = target;
            _damage = damage;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.Transform.position, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _target.Transform.position) < 0.05f)
            {
                Destroy(gameObject);
                _target.Hit(_damage);
            }
        }
    }
}