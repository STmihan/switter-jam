using Loops.GlobalLoop;
using Loops.GlobalLoop.States;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    [RequireComponent(typeof(Button))]
    public class PlayButtonUI : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Play);
        }

        private void Play()
        {
            GlobalLoop
                .Instance
                .GlobalStateMachine
                .ChangeState(new LoadState(GameplayState.SceneName, new GameplayState()));
        }
    }
}