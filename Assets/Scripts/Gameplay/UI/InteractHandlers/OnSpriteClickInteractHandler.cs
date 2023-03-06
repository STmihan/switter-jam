using Gameplay.UI.Interactable;
using UnityEngine;

namespace Gameplay.UI.InteractHandlers
{
    public class OnSpriteClickInteractHandler : MonoBehaviour
    {
        private void OnMouseDown()
        {
            var interactable = GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
}