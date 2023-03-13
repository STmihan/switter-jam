using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class AreaEnable : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private CanvasGroup _target;
        [SerializeField] private float _duration = 3f;

        private Sequence _sequence;
        private Button _button;
        
        private void Start()
        {
            _target.alpha = 0;
            _button = _target.GetComponentInChildren<Button>();
            _button.interactable = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _sequence?.Kill();
            _button.interactable = true;
            _sequence = DOTween.Sequence()
                .Append(_target.DOFade(1, .2f))
                .AppendInterval(_duration)
                .Append(_target.DOFade(0, .2f))
                .AppendCallback(() => _button.interactable = false);
        }
    }
}