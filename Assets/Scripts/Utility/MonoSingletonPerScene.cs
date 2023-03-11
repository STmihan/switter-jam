using System;
using UnityEngine;

namespace Utility
{
    public abstract class MonoSingletonPerScene<T> : MonoBehaviour where T : MonoSingletonPerScene<T>
    {
        public static T Instance { get; private set; }
        public static bool IsInitialized => Instance != null;

        private void Awake()
        {
            Instance = (T)this;
            OnCreate();
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        protected virtual void OnCreate() { }
    }
}