using Gameplay.Controllers;
using Loops.GameplayLoop.States;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Fight
{
    [RequireComponent(typeof(Button))]
    public class GoToPrepareButton : MonoBehaviour
    {
        private Button _button;
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(GoToPrepare);
        }

        private void GoToPrepare()
        {
            GameplayController.Instance.GameplayLoop.StateMachine.ChangeState(new PrepareState());
        }
    }
}