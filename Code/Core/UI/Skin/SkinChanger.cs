using System.Collections.Generic;
using _Project.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Core
{
    public class SkinChanger : MonoBehaviour
    {
        [SerializeField] private List<Image> skins;
        [SerializeField] private SkinData _skinData;
        [SerializeField] private Color _defaulColor;
        [SerializeField] private Color _selectColor;
        
        private void Awake()
        {
            if (!PlayerPrefs.HasKey(Constants.PlayerSkin))
                PlayerPref.Init(Constants.IsSkinBuying + PlayerPref.Get<int>(Constants.PlayerSkin), 1);

            skins[PlayerPref.Get<int>(Constants.PlayerSkin)].color = _selectColor;
        }

        public void SelectSkin(int id)
        {
            _skinData.CurrentSkin = _skinData.Skins[id];
            skins[PlayerPref.Get<int>(Constants.PlayerSkin)].color = _defaulColor;
            
            PlayerPref.Set((Constants.PlayerSkin, id));
            skins[id].color = _selectColor;
        }
    }
}