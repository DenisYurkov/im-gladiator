using System;
using _Project.Extensions;
using EasyButtons;
using TMPro;
using UnityEngine;

namespace _Project.Core
{
    public class Money : MonoBehaviour
    {
        public Action<int> OnIncrease;
        public Action<int> OnDecrease;
        private TextMeshProUGUI _money;
    
        private void Awake() =>
            _money = GetComponent<TextMeshProUGUI>();
        
        private void OnEnable()
        {
            OnIncrease += IncreaseMoney;
            OnDecrease += DecreaseMoney;
        }

        private void Start()
        {
            PlayerPref.Init(Constants.Money, 0);
            _money.text = PlayerPref.Get<int>(Constants.Money).ToString();
        }

        private void IncreaseMoney(int value)
        {
            PlayerPref.Increase(Constants.Money, value);
            _money.text = PlayerPref.Get<int>(Constants.Money).ToString();
        }

        [Button]
        private void SetMoney(int value) => 
            PlayerPref.Set((Constants.Money, value));

        private void DecreaseMoney(int value)
        {
            PlayerPref.Decrease(Constants.Money, value);
            _money.text = PlayerPref.Get<int>(Constants.Money).ToString();
        }

        private void OnDisable()
        {
            OnIncrease -= IncreaseMoney;
            OnDecrease -= DecreaseMoney;
        }
    }
}