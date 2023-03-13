using UnityEngine;

namespace Gameplay.Views.Bogacheva
{
    public class BogachevaListItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Vector3 _targetPosition;
        private float _speed;

        public void SetData(Sprite sprite, float speed)
        {
            _spriteRenderer.sprite = sprite;
            _speed = speed;
        }
        
        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);
        }
    }
}