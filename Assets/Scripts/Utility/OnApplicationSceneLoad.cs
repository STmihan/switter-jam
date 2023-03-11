using Loops.GlobalLoop.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
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