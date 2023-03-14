using Music;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.UI
{
    public class PlayUISound : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData) => AudioManager.Instance.PlayUIClickSound();
    }
}