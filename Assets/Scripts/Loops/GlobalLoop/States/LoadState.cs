using System.Collections;
using Global;
using StateManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loops.GlobalLoop.States
{
    public class LoadState : StateBase<GlobalData>
    {
        public const string LoadSceneName = "Load";
        
        private string _sceneName;
        private StateBase<GlobalData> _nextState;

        public LoadState(string sceneName, StateBase<GlobalData> nextState)
        {
            _sceneName = sceneName;
            _nextState = nextState;
        }

        public override void Enter(StateMachine<GlobalData> sm)
        {
            GameManager.Instance.StartCoroutine(LoadScene(sm));
        }

        private IEnumerator LoadScene(StateMachine<GlobalData> sm)
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