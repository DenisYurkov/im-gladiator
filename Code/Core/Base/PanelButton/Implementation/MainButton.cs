using System;
using _Project.Extensions;
using UnityEngine;
using static _Project.Extensions.Constants;

namespace _Project.Core
{
    [Serializable]
    public class MainButton : IPanelButton
    {
        [SerializeField] private Loading _loading;
        private readonly Scene _scene = new();

        public void Press()
        {
            PlayerPref.Set((PlayerHp, PlayerPref.Get<int>(PlayerMaxHp)), (LevelID, 0));
            _loading.LoadSingle(_scene.MainScene);
        }
    }
}