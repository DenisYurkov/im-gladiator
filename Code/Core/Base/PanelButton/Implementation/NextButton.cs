using System;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public class NextButton : IPanelButton
    {
        [SerializeField] private LevelBehaviour _levelBehaviour;

        public void Press() => 
            _levelBehaviour.NextLevel();
    }
}