using System;
using _Project.Extensions;
using UnityEngine;
using static _Project.Extensions.Constants;

namespace _Project.Core
{
    [Serializable]
    public class IncreaseMaxHp : Boost
    {
        [Header("Increase Max Health: ")]
        [SerializeField] private int _increaseValue;
        
        protected override void Apply()
        {
            Money.OnDecrease.Invoke(Cost);
            
            PlayerPref.Init(PlayerMaxHp, 100);
            PlayerPref.Increase(PlayerMaxHp, _increaseValue);
            PlayerPref.Set((PlayerHp, PlayerPref.Get<int>(PlayerMaxHp)));
        }
    }
}