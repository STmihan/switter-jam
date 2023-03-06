namespace Utility
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance;
        public static T Instance => _instance ??= new T();
        public static bool IsInitialized => Instance != null;

        public void CreateInstance()
        {
            _instance = new T();
        }
    }
}