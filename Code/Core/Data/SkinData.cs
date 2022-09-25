using System.Collections.Generic;
using _Project.Extensions;
using UnityEngine;

namespace _Project.Core
{
    [CreateAssetMenu(fileName = "SkinData", menuName = "SO/SkinData", order = 0)]
    public class SkinData : ScriptableObject
    {
        public GameObject CurrentSkin;
        public List<GameObject> Skins;

        private void OnEnable() => 
            CurrentSkin = Skins[PlayerPref.Get<int>(Constants.PlayerSkin)];
    }
}