using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Views.Projectiles
{
    public abstract class TargetProjectileBase : MonoBehaviour
    {
        protected IHittable Target;
        protected float Speed;
        protected int Damage;
        public virtual void Setup(IHittable target, Vector3 start, float projectileSpeed, int damage)
        {
            transform.position = start;
            Speed = projectileSpeed;
            Target = target;
            Damage = damage;
        }
    }
}