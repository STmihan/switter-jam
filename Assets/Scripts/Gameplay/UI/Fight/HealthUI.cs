using Gameplay.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Fight
{
    [RequireComponent(typeof(Image))]
    public class HealthUI : MonoBehaviour
    {
        private Image _slider;
        private CanvasGroup _canvasGroup;
        private IHealth _health;

        private int _maxHealth;

        private void Start()
        {
            _health = GetComponentInParent<IHealth>();
            _slider = GetComponent<Image>();
            _canvasGroup = GetComponentInParent<CanvasGroup>();
            _maxHealth = _health.Health;
            _canvasGroup.alpha = 0;
        }

        private void Update()
        {
            _canvasGroup.alpha = _health.Health == 0 || _health.Health == _maxHealth ? 0 : 1;
            _slider.fillAmount = (float)_health.Health / _maxHealth;
        }
    }
}