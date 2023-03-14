using Data.Foods.Shared;
using DG.Tweening;
using Gameplay.Interfaces;
using Gameplay.Views;
using Gameplay.Views.Projectiles;
using Gameplay.Views.Towers;
using UnityEngine;

namespace Data.Foods
{
    [CreateAssetMenu(menuName = "Foods/Create DoubleShotFood", fileName = "DoubleShotFood", order = 0)]
    public class DoubleShotFood : FoodTowerBase, IAttackable
    {
        [field: SerializeField] public float AttackRange { get; private set; }
        [field: SerializeField] public float AttackInterval { get; private set; }
        [field: SerializeField] public int AttackDamage { get; private set; }
        [SerializeField] private float _attackIntervalBetweenShots;
        [SerializeField] private AutoProjectileView _autoProjectilePrefab;

        [SerializeField]
        private float _projectileSpeed;

        public void Attack(TowerView view, IHittable target)
        {
            DOTween.Sequence()
                .AppendCallback(() => Shot(view.Muzzle, target, view.AudioSource))
                .AppendInterval(_attackIntervalBetweenShots)
                .AppendCallback(() => Shot(view.Muzzle, target, view.AudioSource));
        }

        private void Shot(Transform transform, IHittable target, AudioSource viewAudioSource)
        {
            Instantiate(_autoProjectilePrefab, transform.position, Quaternion.identity)
                .Setup(target, transform.position, _projectileSpeed, AttackDamage);
            viewAudioSource.pitch = Random.Range(0.7f, 1.3f);
            viewAudioSource.PlayOneShot(viewAudioSource.clip);
        }
    }
}