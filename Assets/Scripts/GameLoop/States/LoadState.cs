using System.Collections;
using StateManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLoop.States
{
    public class LoadState : StateBase<GameStateData>
    {
        public const string LoadSceneName = "Load";
        
        private string _sceneName;
        private StateBase<GameStateData> _nextState;

        public LoadState(string sceneName, StateBase<GameStateData> nextState)
        {
            _sceneName = sceneName;
            _nextState = nextState;
        }

        public override void Enter(StateMachine<GameStateData> sm)
        {
            GameManager.Instance.StartCoroutine(LoadScene(sm));
        }

        private IEnumerator LoadScene(StateMachine<GameStateData> sm)
        {
            var currentScene = SceneManager.GetActiveScene();
            AsyncOperation loadScene = SceneManager.LoadSceneAsync(LoadSceneName, LoadSceneMode.Additive);
            yield return loadScene;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(LoadSceneName));
            AsyncOperation unloadSceneAsync = SceneManager.UnloadSceneAsync(currentScene);
            yield return unloadSceneAsync;
            yield return new WaitForSeconds(1f);
            loadScene = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            yield return loadScene;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneName));
            sm.ChangeState(_nextState);
            SceneManager.UnloadSceneAsync(LoadSceneName);
        }
    }
}