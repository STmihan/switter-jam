using Data;
using Gameplay.Controllers;
using UnityEngine;
using Utility;

namespace Global
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private Config _config;

        public Config Config => _config;

        public static void Save(SaveData data)
        {
            PlayerPrefs.SetInt(SaveData.ScoreKey, data.Score);
            PlayerPrefs.GetInt(SaveData.TimeKey, data.Time);
        }
        
        public static SaveData Load()
        {
            return new SaveData
            {
                Score = PlayerPrefs.GetInt(SaveData.ScoreKey, 0),
                Time = PlayerPrefs.GetInt(SaveData.TimeKey, 0)
            };
        }
    }

    public struct SaveData
    {
        public const string ScoreKey = "Score";
        public const string TimeKey = "Time";
        
        public int Score;
        public int Time;
    }
}