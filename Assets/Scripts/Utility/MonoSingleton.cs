using UnityEngine;

namespace Utility
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }
        public static bool IsInitialized => Instance != null;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = (T)this;
            DontDestroyOnLoad(gameObject);
            OnCreate();
        }

        protected virtual void OnCreate() { }

        public void SetInstance()
        {
            Destroy(Instance.gameObject);
            Instance = (T)this;
        }
    }
}