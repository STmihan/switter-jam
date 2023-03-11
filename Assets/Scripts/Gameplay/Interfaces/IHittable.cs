using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface IHittable
    {
        public Transform Transform { get; }
        public bool IsDead { get; }
        public void Hit(int damage);
    }
    
    public interface IEnemyTarget : IHittable
    {
    }
    
    public interface ITowerTarget : IHittable
    {
    }
}