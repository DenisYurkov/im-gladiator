using _Project.Extensions;
using System.Collections.Generic;
using EasyButtons;
using UnityEngine;

namespace _Project.Core
{
    public class LevelBehaviour : MonoBehaviour
    {
        [SerializeField] private List<LevelData> _levelsData;
        [SerializeField] private Loading _loading;
        private readonly Scene _scene = new ();

        public LevelData CurrentLevel { get; private set; }

        private void Awake()
        {
            PlayerPref.Init(Constants.LevelID, 0);
            
            if (PlayerPref.Get<int>(Constants.LevelID) == _levelsData.Count) 
                PlayerPref.ResetPlayerHp();

            CurrentLevel = _levelsData[PlayerPref.Get<int>(Constants.LevelID)];
        }

        [Button]
        public void NextLevel()
        {
            PlayerPref.Increase(Constants.LevelID, 1);
            _loading.LoadAdditive(_scene.GameScene);
        }

        [Button]
        public void ResetLevel()
        {
            PlayerPref.ResetPlayerHp();
            _loading.LoadAdditive(_scene.GameScene);
        }
        
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus) 
                PlayerPref.ResetPlayerHp();
        }

        private void OnApplicationQuit() =>
            PlayerPref.ResetPlayerHp();
    }
}