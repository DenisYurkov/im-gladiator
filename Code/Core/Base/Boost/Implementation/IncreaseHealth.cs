using System;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public class IncreaseHealth : Boost
    {
        [Header("Increase Health: ")]
        [SerializeField] private BattleBehaviour _battleBehaviour;
        [SerializeField] private int _increaseValue;

        private Health Health =>
            _battleBehaviour.Characters[0].HealthObject;

        protected override void Apply()
        {
            if (!Health.CanIncreased(_increaseValue)) return;
            
            Money.OnDecrease.Invoke(Cost);
            Health.Increase(_increaseValue);
        }
    }
}