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
    }
}