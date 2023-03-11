using System;
using Data.Foods;
using DG.Tweening;
using Gameplay.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.UI.Fight
{
    public class AvailableFoodListItem : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _countText;

        private FoodBase _food;
        private int _count;

        private TowersController TowersController =>
            GameplayController.Instance.TowersController;

        private void OnEnable()
        {
            TowersController.OnSelectedFoodChanged += OnSelectedFoodChanged;
            TowersController.OnFoodCountChanged += OnFoodCountChanged;
        }

        private void OnFoodCountChanged(FoodBase obj)
        {
            if (obj == _food)
            {
                _count--;
                _countText.text = _count.ToString();
                if (_count == 0)
                {
                    _image.DOFade(.5f, .5f);
                }
            }
        }

        private void OnSelectedFoodChanged(FoodBase obj)
        {
            if (obj == _food)
            {
                _image.color = Color.green;
            }
            else
            {
                _image.color = _count > 0 ? Color.white : new Color(1, 1, 1, .5f);
            }
        }

        public void SetFoodItem(FoodBase availableFood, int count)
        {
            _image.sprite = availableFood.Sprite;
            _food = availableFood;
            _count = count;
            _countText.text = count.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_count > 0)
            {
                TowersController.SelectedFood = TowersController.SelectedFood == _food ? null : _food;
            }
        }

        private void OnDisable()
        {
            if (TowersController != null)
            {
                TowersController.OnSelectedFoodChanged -= OnSelectedFoodChanged;
                TowersController.OnFoodCountChanged -= OnFoodCountChanged;
            }
        }
    }
}