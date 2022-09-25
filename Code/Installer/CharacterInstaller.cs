using _Project.Core;
using UnityEngine;
using Zenject;
 
namespace _Project.Installer
{
    public class CharacterInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private LevelBehaviour _levelBehaviour;

        [Header("Skins")] 
        [SerializeField] private SkinData _playerSkin;
        
        [Header("Positions")] 
        [SerializeField] private Transform _playerPoint;
        [SerializeField] private Transform _enemyPoint;
        [SerializeField] private Transform _parentObject;
        
        public override void InstallBindings()
        {
            BindInstallerInterfaces();
            BindEnemyFactory();
        }

        private void BindInstallerInterfaces()
        {
            Container
                .BindInterfacesTo<CharacterInstaller>()
                .FromInstance(this);
        }

        private void BindEnemyFactory() =>
            Container
                .BindInterfacesAndSelfTo<CharacterFactory>()
                .AsSingle();

        public void Initialize()
        {
            ICharacterFactory characterFactory = Container.Resolve<ICharacterFactory>();
            CreatePlayer(characterFactory);

            foreach (var enemies in _levelBehaviour.CurrentLevel.Enemies)
                CreateEnemy(characterFactory, enemies);
        }
        
        private void CreatePlayer(ICharacterFactory characterFactory)
        {
            GameObject player = _levelBehaviour.CurrentLevel.PlayerPrefab;
            Vector3 localScale = player.transform.localScale;
            
            characterFactory.Load(player, _playerSkin.CurrentSkin);
            characterFactory.Create(_playerPoint.position, localScale, _parentObject);
        }
        
        private void CreateEnemy(ICharacterFactory characterFactory, Enemy enemies)
        {
            var enemy = _levelBehaviour.CurrentLevel.EnemyPrefab;
            
            characterFactory.Load(enemy, enemies.Skin);
            characterFactory.Create(_enemyPoint.position + enemies.SpawnOffset,
                enemies.Scale, _parentObject, enemies.Hp, enemies.Rotation);
        }
    }
}