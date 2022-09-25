using _Project.Core;
using UnityEngine;
using Zenject;

namespace _Project.Installer
{
    public sealed class BehaviourInstaller : MonoInstaller
    {
        [SerializeField] private BattleBehaviour _battleBehaviour;
        
        public override void InstallBindings() => 
            BattleBehaviourBind();

        private void BattleBehaviourBind() =>
            Container
                .Bind<BattleBehaviour>()
                .FromInstance(_battleBehaviour)
                .AsSingle();
    }
}