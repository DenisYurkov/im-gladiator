using System;
using _Project.Extensions;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public class PlayButton : IPanelButton
    {
        [SerializeField] private Loading _loading;
        private readonly Scene _scene = new();

        public void Press() => 
           _loading.LoadMultiple(_scene.GameScene, _scene.MusicScene);
    }
}