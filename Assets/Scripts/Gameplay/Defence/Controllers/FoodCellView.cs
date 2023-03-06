using Data.Foods;
using UnityEngine;

namespace Gameplay.Defence.Controllers
{
    public class FoodCellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void UpdateView(FoodBase food)
        {
            if (food == null)
            {
                _spriteRenderer.sprite = null;
                return;
            }
            _spriteRenderer.sprite = food.Sprite;
        }
    }
}