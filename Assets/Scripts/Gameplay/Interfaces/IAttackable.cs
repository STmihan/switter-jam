using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface IAttackable
    {
        float AttackRange { get; }
        float AttackInterval { get; }
        int AttackDamage { get; }
        void Attack(Transform transform, IHittable target);
    }
}