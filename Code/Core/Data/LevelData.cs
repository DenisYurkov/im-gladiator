using _Project.Extensions;
using System.Collections.Generic;
using EasyButtons;
using Gadget.Core;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace _Project.Core
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "SO/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        [Header("Default Prefab")] [EnableIf("ChangeDefault")] 
        public GameObject PlayerPrefab;
        
        [EnableIf("ChangeDefault")] 
        public GameObject EnemyPrefab;
        
        [EnableIf("ChangeDefault")] 
        public GameObject SkinDefault;

        public List<Enemy> Enemies = new();

        [Header("Level Settings")] 
        public int MoneyPerLevel = 3;
        public bool ChangeDefault;
        
        [Header("Boss Settings")]
        public bool IsBossFight;

        private void InitPrefab()
        {
            #if UNITY_EDITOR
                PlayerPrefab = (GameObject) AssetDatabase.LoadAssetAtPath(Constants.PlayerPath, typeof(GameObject));
                EnemyPrefab = (GameObject) AssetDatabase.LoadAssetAtPath(Constants.EnemyPath, typeof(GameObject));
                SkinDefault = (GameObject) AssetDatabase.LoadAssetAtPath(Constants.SkinDefault, typeof(GameObject));
            #endif
        }

        [Button]
        private void ResetEnemies()
        {
            InitPrefab();
            foreach (var enemy in Enemies)
            {
                enemy.Scale = EnemyPrefab.transform.localScale;
                enemy.Skin = SkinDefault;
                enemy.Rotation = new Vector3(0, 180, 0);
            }
        }
        
        private void OnValidate()
        {
            foreach (var enemy in Enemies)
            {
                enemy.IsBossFight = IsBossFight;

                #if UNITY_EDITOR
                if (enemy.Skin != AssetDatabase.GetAssetPath(enemy.Skin).Contains(Constants.SkinPath))
                {
                    enemy.Skin = SkinDefault;
                    Debug.LogWarning("You choice Asset which is not in Resources/Skin folder. Prefab value reset to default!");
                }
                #endif
            }
        }
        
        private void Reset()
        {
            InitPrefab();
            Enemies.Add(new Enemy(EnemyPrefab));
        }
    }
}
