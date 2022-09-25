using _Project.Extensions;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly DiContainer _diContainer;
        private Character _characterObject;
        private GameObject _skin;

        public CharacterFactory(DiContainer diContainer) =>
            _diContainer = diContainer;

        public void Create(Vector3 pos, Vector3 scale, Transform parent, int health = 0, Vector3 rotation = default)
        {
            _characterObject.Health = health;
            
            GameObject character = _diContainer.InstantiatePrefab(_characterObject, pos, Quaternion.identity, parent);
            GameObject skin =_diContainer.InstantiatePrefab(_skin, pos, _skin.transform.rotation, null);
            skin.transform.SetParent(character.transform);
            
            if (!_characterObject.IsPlayer)
            {
                character.transform.rotation = Quaternion.Euler(rotation);
                character.transform.localScale = scale;
            }
        }

        public void Load(GameObject prefab, GameObject skin)
        {
            _characterObject = Resources.Load<Character>(Constants.CharacterFolder + prefab.name);
            _skin = Resources.Load<GameObject>(Constants.SkinsFolder + skin.name);
        }
    }
}