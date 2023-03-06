using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLoop
{
    public class AutoLoad : MonoBehaviour
    {
        [SerializeField] private string _overrideSceneName = "";
        public static string SceneName { get; private set; } = "";

        private void Awake()
        {
#if UNITY_EDITOR
            if (GameManager.Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            LoadManger();
#else
            Destroy(gameObject);
#endif
        }

        private void LoadManger()
        {
            SceneName = _overrideSceneName.IsNullOrWhitespace()
                ? SceneManager.GetActiveScene().name
                : _overrideSceneName;
            SceneManager.LoadScene("Application");
        }
    }
}