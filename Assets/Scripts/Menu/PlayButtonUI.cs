using GameLoop;
using GameLoop.States;
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
            GameManager
                .Instance
                .GlobalStateMachine
                .ChangeState(new LoadState(PrepareState.SceneName, new PrepareState()));
        }
    }
}