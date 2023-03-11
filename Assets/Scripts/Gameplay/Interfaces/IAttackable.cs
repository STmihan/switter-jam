using Gameplay.Views;
using Gameplay.Views.Towers;
using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface IAttackable
    {
        float AttackRange { get; }
        float AttackInterval { get; }
        int AttackDamage { get; }
        void Attack(TowerView view, IHittable target);
    }
}