using DG.Tweening;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class CameraController
    {
        private readonly Camera _camera;

        public CameraController(Camera camera)
        {
            _camera = camera;
        }
        
        public void Shake(float duration, float magnitude)
        {
            _camera.DOShakePosition(duration, magnitude).SetUpdate(true);
        }
    }
}