using UnityEngine;

namespace Gameplay.Views.Projectiles
{
    public class AutoProjectileView : TargetProjectileBase
    {
        private void Update()
        {
            if (Target == null)
            {
                Destroy(gameObject);
                return;
            }
            
            transform.position = Vector3.MoveTowards(transform.position, Target.GameObject.transform.position, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Target.GameObject.transform.position) < 0.05f)
            {
                Destroy(gameObject);
                Target.Hit(Damage);
            }
        }
    }
}