using Music;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Sprite _soundOnSprite;
        [SerializeField] private Sprite _soundOffSprite;
        private Button _button;
        private bool _isSoundOn = true;
        
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _isSoundOn = !_isSoundOn;
            _button.image.sprite = _isSoundOn ? _soundOnSprite : _soundOffSprite;
            AudioManager.Instance.Mute(!_isSoundOn);
        }
    }
}