using _Project.Core;
using UnityEngine;
using Zenject;

namespace _Project.Installer
{
    public sealed class DiceInstaller : MonoInstaller
    {
        [SerializeField] private Dice _dice;
        [SerializeField] private DiceRay _diceRay;
        [SerializeField] private DiceButton _diceButton;
        
        public override void InstallBindings()
        {
            DiceBind();
            DiceRayBind();
            DiceButtonBind();
        }

        private void DiceButtonBind()
        {
            Container
                .Bind<DiceButton>()
                .FromInstance(_diceButton)
                .AsSingle();
        }

        private void DiceRayBind() =>
            Container
                .Bind<DiceRay>()
                .FromInstance(_diceRay)
                .AsSingle();

        private void DiceBind() =>
            Container
                .Bind<Dice>()
                .FromInstance(_dice)
                .AsSingle();
    }
}