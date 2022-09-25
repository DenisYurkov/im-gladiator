using _Project.Feature;
using UnityEngine;
using Zenject;

namespace _Project.Installer
{
    public class SoundInstaller : MonoInstaller
    {
        [SerializeField] private SoundControl soundControl;

        public override void InstallBindings() => 
            BindSoundControl();

        private void BindSoundControl() =>
            Container
                .Bind<SoundControl>()
                .FromInstance(soundControl).AsSingle();
    }
}