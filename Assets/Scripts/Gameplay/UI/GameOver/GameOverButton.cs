using Loops.GlobalLoop;
using Loops.GlobalLoop.States;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.GameOver
{
    [RequireComponent(typeof(Button))]
    public class GameOverButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnGameOverButtonClick);
        }

        private void OnGameOverButtonClick()
        {
            GlobalLoop.Instance.GlobalStateMachine.ChangeState(new LoadState(MenuState.SceneName, new MenuState()));
        }
    }
}