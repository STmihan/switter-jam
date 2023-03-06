using Gameplay.UI.Interactable;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.InteractHandlers
{
    [RequireComponent(typeof(Button))]
    public class ButtonInteractHandler : MonoBehaviour
    {
        private Button _button;
        private IInteractable _interactable;

        private void Start()
        {
            _button = GetComponent<Button>();
            _interactable = GetComponent<IInteractable>();
            _button.onClick.AddListener(_interactable.Interact);
        }
    }
}