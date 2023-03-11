using Gameplay.Controllers;
using Global;
using Loops.GameplayLoop.States;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.Prepare
{
    [RequireComponent(typeof(Button))]
    public class GoToDefenceButton : MonoBehaviour
    {
        private Button _button;
        
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(GoToDefence);
        }

        private void GoToDefence()
        {
            GameplayController.Instance.GameplayLoop.StateMachine.ChangeState(new FightState());
        }
    }
}