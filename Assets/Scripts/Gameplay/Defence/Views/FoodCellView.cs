using Data.Foods;
using UnityEngine;

namespace Gameplay.Defence.Views
{
    public class FoodCellView : MonoBehaviour
    {
        private FoodTowerView _view;
        
        public void UpdateView(FoodBase food)
        {
            if (food == null)
            {
                Destroy(_view.gameObject);
                _view = null;
                return;
            }
            _view = Instantiate(food.Prefab, transform);
            _view.Setup(food);
        }
    }
}