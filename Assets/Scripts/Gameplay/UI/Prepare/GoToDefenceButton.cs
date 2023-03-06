using GameLoop;
using GameLoop.States;
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
            GameManager
                .Instance
                .GlobalStateMachine
                .ChangeState(new LoadState(DefenceState.SceneName, new DefenceState()));
        }
    }
}