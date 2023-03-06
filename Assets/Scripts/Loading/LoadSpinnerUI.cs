using UnityEngine;

namespace Loading
{
    public class LoadSpinnerUI : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 360f;

        private void Update()
        {
            transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
        }
    }
}