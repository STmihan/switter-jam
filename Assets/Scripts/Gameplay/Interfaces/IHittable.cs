using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface IHittable
    {
        public GameObject GameObject { get; }
        public bool IsDead { get; }
        public void Hit(int damage);
        public bool IsStunned { get; set; }
    }
    
    public interface IEnemyTarget : IHittable
    {
    }
    
    public interface ITowerTarget : IHittable
    {
    }
}