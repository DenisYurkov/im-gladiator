using UnityEngine;

namespace _Project.Core
{
    public interface ICharacterFactory
    {
        void Create(Vector3 spawnPos, Vector3 scale, Transform parent, int health = 0, Vector3 rotation = default);
        void Load(GameObject prefab, GameObject skin);
    }
}