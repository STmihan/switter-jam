using UnityEngine;

namespace Data.Foods
{
    public interface IHittable
    {
        public Transform Transform { get; }
        public bool IsDead { get; }
        public void Hit(int damage);
    }
}