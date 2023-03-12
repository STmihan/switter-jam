using System;
using DG.Tweening;
using Gameplay.Controllers;
using Loops.GlobalLoop;
using Loops.GlobalLoop.States;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.UI.GameOver
{
    public class GameOverUI : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _timeText;
        
        private void OnEnable()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(1, .5f).SetUpdate(true);
            _scoreText.text = $"Score: {GameplayController.Instance.Score}";
            _timeText.text = $"Time: {Mathf.FloorToInt(GameplayController.Instance.Time)}";
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnGameOverButtonClick();
        }

        private void OnGameOverButtonClick()
        {
            GlobalLoop.Instance.GlobalStateMachine.ChangeState(new LoadState(MenuState.SceneName, new MenuState()));
        }
    }
}