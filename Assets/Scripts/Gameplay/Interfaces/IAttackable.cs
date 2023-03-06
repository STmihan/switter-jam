using Gameplay.Defence.Enemies;
using UnityEngine;

namespace Data.Foods
{
    public interface IAttackable
    {
        float AttackRange { get; }
        float AttackInterval { get; }
        int AttackDamage { get; }
        void Attack(Transform transform, IHittable target);
    }
}