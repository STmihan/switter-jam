using System;
using Data.Foods;
using DG.Tweening;
using GameLoop;
using Gameplay.Defence.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay.UI.Defence
{
    public class AvailableFoodListItem : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _countText;

        private FoodBase _food;
        private int _count;

        private FoodTowersController FoodTowersController =>
            DefenceController.Instance.DefenceData.FoodTowersController;

        private void Start()
        {
            FoodTowersController.OnSelectedFoodChanged += OnSelectedFoodChanged;
            FoodTowersController.OnFoodCountChanged += OnFoodCountChanged;
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
            Debug.Log(availableFood.Name);
            _image.sprite = availableFood.Sprite;
            _food = availableFood;
            _count = count;
            _countText.text = count.ToString();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_count > 0)
            {
                FoodTowersController.SelectedFood = FoodTowersController.SelectedFood == _food ? null : _food;
            }
        }
    }
}