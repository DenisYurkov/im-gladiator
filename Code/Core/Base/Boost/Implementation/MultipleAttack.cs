using System;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public class MultipleAttack : Boost
    {
        [Header("Multiple Attack: ")]
        [SerializeField] private BattleBehaviour _battleBehaviour;
        [SerializeField] private int _multiplier;
        
        private Character Player =>
            _battleBehaviour.Characters[0];

        protected override void Apply()
        {
            Money.OnDecrease.Invoke(Cost);
            Player.AttackMultiplier += Player.AttackMultiplier == 1 ? _multiplier-1 : _multiplier;
        }
    }
}