using System;
using _Project.Extensions;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public abstract class Product
    {
        [Header("Product Settings: ")]
        public Money Money;
        public int Cost;

        protected bool IsEnoughMoney() => 
            PlayerPref.Get<int>(Constants.Money) >= Cost;
    }
}