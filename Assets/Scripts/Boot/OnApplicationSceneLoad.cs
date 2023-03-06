using GameLoop;
using GameLoop.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boot
{
    public class OnApplicationSceneLoad : MonoBehaviour
    {
        private void Start()
        {
            string sceneName = MenuState.SceneName;
#if UNITY_EDITOR
            if (AutoLoad.SceneName != "")
            {
                sceneName = AutoLoad.SceneName;
            }
#endif
            SceneManager.LoadScene(sceneName);
        }
    }
}