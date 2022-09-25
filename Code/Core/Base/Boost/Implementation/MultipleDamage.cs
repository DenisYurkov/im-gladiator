using System;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public class MultipleDamage : Boost
    {
        [Header("Multiple Damage: ")]
        [SerializeField] private DiceRay _diceRay;
        [SerializeField] private int _multiplier;

        protected override void Apply()
        {
            Money.OnDecrease.Invoke(Cost);
            _diceRay.Multiplier += _diceRay.Multiplier == 1 ? _multiplier-1 : _multiplier;
        }
    }
}