using System;
using Loops.GlobalLoop;
using Loops.GlobalLoop.States;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseUI;
        
        public bool IsPaused { get; private set; }

        private void Start()
        {
            _pauseUI.SetActive(false);
        }

        public void Interact()
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
        public void GoToMenu()
        {
            Time.timeScale = 1;
            GlobalLoop.Instance.GlobalStateMachine.ChangeState(new LoadState(MenuState.SceneName, new MenuState()));
        }
        
        private void Pause()
        {
            _pauseUI.SetActive(true);
            Time.timeScale = 0;
            IsPaused = true;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                Interact();
            }
        }

        private void Resume()
        {
            _pauseUI.SetActive(false);
            Time.timeScale = 1;
            IsPaused = false;
        }
    }
}