using System;
using Data.Foods;
using GameLoop;
using Gameplay.Defence.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.UI.Defence
{
    public class AvailableFoodListItem : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Image _image;

        private FoodBase _food;

        private FoodTowersController FoodTowersController => DefenceController.Instance.DefenceData.FoodTowersController;

        private void Start()
        {
            FoodTowersController.OnSelectedFoodChanged += OnSelectedFoodChanged;
        }

        private void OnSelectedFoodChanged(FoodBase obj)
        {
            if (obj == _food)
            {
                _image.color = Color.green;
            }
            else
            {
                _image.color = Color.white;
            }
        }

        public void SetFoodItem(FoodBase availableFood)
        {
            Debug.Log(availableFood.Name);
            _image.sprite = availableFood.Sprite;
            _food = availableFood;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            FoodTowersController.SelectedFood = FoodTowersController.SelectedFood == _food ? null : _food;
        }
    }
}